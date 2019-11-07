using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    // 回転量クラス
    public class RotateAmount
    {
        public static RotateAmount Zero = RotateAmount.Generate(0);
        private Modulo26 value;

        public static RotateAmount Generate(int value)
        {
            return new RotateAmount(Modulo26.Generate(value));
        }

        private RotateAmount(Modulo26 value)
        {
            if (value == null) throw new NullReferenceException();
            this.value = value;
        }

        public bool IsZero()
        {
            return this.value.IsZero();
        }

        public RotateAmount Rotate()
        {
            return new RotateAmount(this.value.Plus(1));
        }

        public Modulo26 GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return "RotateAmount{value=" + value + "}";
        }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (o == null || GetType() == o.GetType()) return false;
            RotateAmount that = (RotateAmount)o;
            return value == that.value;
        }

        public int HashCode()
        {
            return value.GetHashCode();
        }
    }
}
