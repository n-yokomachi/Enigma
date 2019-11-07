using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Plugboard
    {
        private Rotor rotor;
        private Dictionary<Key, Key> exchangeMap = new Dictionary<Key, Key>();

        public Plugboard(Rotor rotor)
        {
            if (rotor == null) throw new NullReferenceException();
            this.rotor = rotor;
        }

        public void Exchange(Key one, Key other)
        {
            if (this.exchangeMap.Count / 2 == 6)
            {
                throw new Exception("交換を定義できるのは６つまでです");
            }
            if (one.Equals(other))
            {
                throw new Exception("同じキーは交換できません");
            }
            if (this.exchangeMap.ContainsKey(one))
            {
                throw new Exception(one.ToString() + "は交換済みです");
            }
            if (this.exchangeMap.ContainsKey(other))
            {
                throw new Exception(other.ToString() + "は交換済みです");
            }

            this.exchangeMap[one] = other;
            this.exchangeMap[other] = one;
        }

        public Key Input(Key inputKey)
        {
            Key exchanged = this.exchangeMap.GetOrDefault(inputKey, inputKey);
            IOPosition position = IOPosition.Generate(exchanged.ToNumber());

            IOPosition reversed = this.rotor.Input(position);

            Key reversedKey = Key.Generate(reversed.GetValue());
            return this.exchangeMap.GetOrDefault(reversedKey, reversedKey);
        }
    }
}
