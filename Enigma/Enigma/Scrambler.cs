using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    /// <summary>
    /// スクランブラ―
    /// </summary>
    [Serializable]
    public class Scrambler
    {
        private Dictionary<IOPosition, IOPosition> map;
        private Dictionary<IOPosition, IOPosition> reverseMap;

        public static Scrambler NewInstance(Random random)
        {
            List<int> randomIndexes = Enumerable.Range(0, 26).ToList();
            randomIndexes = randomIndexes.OrderBy(x => Guid.NewGuid()).ToList();

            Dictionary<IOPosition, IOPosition> map = new Dictionary<IOPosition, IOPosition>();

            for (int i = 0; i < 26; i++)
            {
                IOPosition one = IOPosition.Generate(i);
                IOPosition other = IOPosition.Generate(randomIndexes[i]);
                map[one] = other;
            }

            return new Scrambler(map);
        }

        public Scrambler() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="map"></param>
        public Scrambler(Dictionary<IOPosition, IOPosition> map)
        {
            this.map = map;
            Dictionary<IOPosition, IOPosition> reversed = new Dictionary<IOPosition, IOPosition>();
            foreach (var item in map)
            {
                reversed[item.Key] = item.Value;
            }
            this.reverseMap = reversed;
        }

        public IOPosition Scramble(IOPosition input, Offset offset, RotateAmount rotateAmount)
        {
            IOPosition shifted = input.Minus(offset, rotateAmount);
            IOPosition scrambled = this.map[shifted];
            return scrambled.Plus(offset, rotateAmount);
        }

        public IOPosition Reverse(IOPosition input, Offset offset, RotateAmount rotateAmount)
        {
            IOPosition shifted = input.Minus(offset, rotateAmount);
            IOPosition reversed = this.reverseMap[shifted];
            return reversed.Plus(offset, rotateAmount);
        }

        /// <summary>
        /// スクランブラを書き出す
        /// </summary>
        /// <param name="path"></param>
        public void Store(string path)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Scrambler));
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, new System.Text.UTF8Encoding(false)))
            {
                try
                {
                    serializer.Serialize(sw, this);
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// スクランブラを読み込む
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Scrambler Load(string path)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Scrambler));
            
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path,new System.Text.UTF8Encoding(false)))
            {
                try
                {
                    return (Scrambler)serializer.Deserialize(sr);
                }
                finally
                {
                    sr.Close();
                }
            }
        
        }
    }
}
