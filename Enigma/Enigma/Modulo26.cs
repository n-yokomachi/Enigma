using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    [Serializable]public class Modulo26
    {
        private int value;

        // 与えられた数値Modulo26クラスに変換する
        public static Modulo26 Generate(int value)
        {
            return new Modulo26(value);
        }

        // フロア・モデュラスを返す
        private Modulo26(int value)
        {
            this.value = (Math.Abs(value * 26) + value) % 26;
        }

        // ゼロ判定
        public bool IsZero()
        {
            return this.value == 0;
        }

        // 値の取得
        public int GetValue()
        {
            return this.value;
        }

        // 加算
        public Modulo26 Plus(Modulo26 other)
        {
            return this.Plus(other.value);
        }

        // 減算
        public Modulo26 Minus(Modulo26 other)
        {
            return this.Plus(-1 * other.value);
        }

        // 加算ベース処理
        public Modulo26 Plus(int n)
        {
            return new Modulo26(this.value + n);
        }


        public override string ToString()
        {
            return "Modulo26{value=" + value + "}";
        }

        public bool Equeals(Object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Modulo26 modulo26 = (Modulo26)o;
            return value == modulo26.value;
        }

        public int HashCode()
        {
            return value.GetHashCode();
        }
    }
}
