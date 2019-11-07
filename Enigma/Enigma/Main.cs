using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class EnigmaMain
    {
        public static void Main(string[] args)
        {
            // スクランブラリストを生成する。
            // 既存のオブジェクトがあればそれを、なければ新たに生成する。
            List<Scrambler> scramblerList = new List<Scrambler>();
            for (int i = 0; i < 3; i++)
            {
                string path = System.IO.Path.GetFullPath("./build/scrambler" + (i + 1));
                Scrambler scrambler;
                if (System.IO.File.Exists(path))
                {
                    scrambler = Scrambler.Load(path);
                }　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
                {
                    scrambler = Scrambler.NewInstance(new Random());
                    scrambler.Store(path);
                }
                scramblerList.Add(scrambler);
            }

            Scrambler firstScrambler = scramblerList[0];
            Scrambler secondScrambler = scramblerList[1];
            Scrambler thirdScrambler = scramblerList[2];

            // エニグマインスタンス生成
            Enigma encryption = Enigma.NewInstance(Key.D, firstScrambler, Key.K, secondScrambler, Key.F, thirdScrambler, InitializePlugboard);

            string encrypted = encryption.Input("helloxxworld");

            Console.WriteLine(encrypted);

            Enigma decryption = Enigma.NewInstance(Key.D, firstScrambler, Key.K, secondScrambler, Key.F, thirdScrambler, InitializePlugboard);

            string plainText = decryption.Input(encrypted);

            Console.WriteLine(plainText.Replace("XX", " "));

            Console.ReadLine();
        }


        private static void InitializePlugboard(Plugboard plugboard)
        {
            plugboard.Exchange(Key.A, Key.R);
            plugboard.Exchange(Key.E, Key.K);
            plugboard.Exchange(Key.O, Key.T);
            plugboard.Exchange(Key.P, Key.Q);
            plugboard.Exchange(Key.Z, Key.M);
            plugboard.Exchange(Key.Y, Key.C);
        }
    }
}