using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Key
    {
        public static Key A = new Key('a');
        public static Key B = new Key('b');
        public static Key C = new Key('c');
        public static Key D = new Key('d');
        public static Key E = new Key('e');
        public static Key F = new Key('f');
        public static Key G = new Key('g');
        public static Key H = new Key('h');
        public static Key I = new Key('i');
        public static Key J = new Key('j');
        public static Key K = new Key('k');
        public static Key L = new Key('l');
        public static Key M = new Key('m');
        public static Key N = new Key('n');
        public static Key O = new Key('o');
        public static Key P = new Key('p');
        public static Key Q = new Key('q');
        public static Key R = new Key('r');
        public static Key S = new Key('s');
        public static Key T = new Key('t');
        public static Key U = new Key('u');
        public static Key V = new Key('v');
        public static Key W = new Key('w');
        public static Key X = new Key('x');
        public static Key Y = new Key('y');
        public static Key Z = new Key('z');

        public static Key Generate(char c)
        {
            return new Key(c);
        }

        public static Key Generate(Modulo26 value)
        {
            char key = (char)(value.GetValue() + 'a');
            return new Key(key);
        }

        private char value;

        private Key(char value)
        {
            if (!('a' <= value && value <= 'z'))
            {
                throw new Exception("valueはa-zのいずれかでなければならない");
            }
            this.value = value;
        }

        public char GetChar()
        {
            return this.value;
        }

        public Modulo26 ToNumber()
        {
            return Modulo26.Generate(this.value - 'a');
        }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Key key = (Key)o;
            return value == key.value;
        }

        public int HashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return "Key{value=" + value + "}";
        }
    }
}
