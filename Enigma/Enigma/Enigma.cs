using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Enigma
    {
        private Plugboard plugboard;

        public static Enigma NewInstance(
            Key firstKey,
            Scrambler firstScrambler,
            Key secondKey,
            Scrambler secondScrambler,
            Key thirdKey,
            Scrambler thirdScrambler,
            Action<Plugboard> plugboardInitializer)
        {
            Reflector reflector = new Reflector();

            EncryptionRotor thirdRotor = new EncryptionRotor(ToOffset(firstKey), firstScrambler, reflector);
            EncryptionRotor secondRotor = new EncryptionRotor(ToOffset(secondKey), secondScrambler, thirdRotor);
            EncryptionRotor firstRotor = new EncryptionRotor(ToOffset(thirdKey), thirdScrambler, secondRotor);

            Plugboard plugboard = new Plugboard(firstRotor);
            plugboardInitializer.Invoke(plugboard);

            return new Enigma(plugboard);
        }

        private static Offset ToOffset(Key key)
        {
            return Offset.Generate(key.ToNumber());
        }

        private Enigma(Plugboard plugboard)
        {
            if(plugboard == null) throw new NullReferenceException();
            this.plugboard = plugboard;
        }

        public string Input(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                Key key = Key.Generate(c);
                Key result = this.plugboard.Input(key);
                sb.Append(result.GetChar());
            }

            return sb.ToString();
        }
    }
}
