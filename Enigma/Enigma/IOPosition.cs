using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    /// <summary>
    /// 入出力位置クラス
    /// </summary>
    [Serializable]public class IOPosition
    {
        private Modulo26 value;

        // コンストラクタを呼び出す変換メソッド
        public static IOPosition Generate(int value)
        {
            return new IOPosition(Modulo26.Generate(value));
        }

        // コンストラクタを呼び出す変換メソッド
        public static IOPosition Generate(Modulo26 value)
        {
            return new IOPosition(value);
        }
        
        // コンストラクタ
        private IOPosition(Modulo26 value)
        {
            this.value = value;
        }

        public Modulo26 GetValue()
        {
            return this.value;
        }

        public IOPosition Plus(int n)
        {
            return new IOPosition(this.value.Plus(n));
        }

        public IOPosition Plus(Offset offset, RotateAmount rotateAmount)
        {
            return new IOPosition(this.value.Plus(offset.GetValue()).Plus(rotateAmount.GetValue()));
        }

        public IOPosition Minus(Offset offset, RotateAmount rotateAmount)
        {
            return new IOPosition(this.value.Minus(offset.GetValue()).Minus(rotateAmount.GetValue()));
        }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (o == null || GetType() == o.GetType()) return false;
            IOPosition that = (IOPosition)o;
            return Equals(value, that.value);
        }

        public int HashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return "IOPosition{value=" + value + "}";
        }
    }
}
