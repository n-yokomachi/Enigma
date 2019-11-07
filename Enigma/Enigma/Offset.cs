using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    // オフセットクラス
    public class Offset
    {
        private Modulo26 value;

        public static Offset Generate(Modulo26 value)
        {
            return new Offset(value);
        }

        public static Offset Generate(int value)
        {
            return new Offset(Modulo26.Generate(value));
        }

        private Offset(Modulo26 value)
        {
            if(value == null) throw new NullReferenceException();
            this.value = value;
        }

        public Modulo26 GetValue()
        {
            return value;
        }

        public override string ToString()
        {
            return "Offset{value=" + value + "}";
        }

        public bool Equeals(Object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Offset offset = (Offset)o;
            return value == offset.value;
        }

        public int HashCode()
        {
            return value.GetHashCode();
        }
    }
}
