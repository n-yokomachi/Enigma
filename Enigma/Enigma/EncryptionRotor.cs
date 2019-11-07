using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    /// <summary>
    /// 暗号化ローター
    /// </summary>
    public class EncryptionRotor : Rotor
    {
        private Offset offset;
        private Scrambler scrambler;
        private Rotor nextRotor;
        private RotateAmount rotateAmount;

        public EncryptionRotor(Offset offset, Scrambler scrambler, Rotor nextRotor)
        {
            if (offset == null) throw new NullReferenceException();
            if (scrambler == null) throw new NullReferenceException();
            if (nextRotor == null) throw new NullReferenceException();

            this.offset = offset;
            this.scrambler = scrambler;
            this.nextRotor = nextRotor;
            this.rotateAmount = RotateAmount.Zero;
        }

        public IOPosition Input(IOPosition position)
        {
            IOPosition scrambled = this.scrambler.Scramble(position, this.offset, this.rotateAmount);
            IOPosition reflected = this.nextRotor.Input(scrambled);
            IOPosition reversed = this.scrambler.Reverse(reflected, this.offset, this.rotateAmount);

            this.Rotate();

            return reversed;
        }


        public void Rotate()
        {
            this.rotateAmount = this.rotateAmount.Rotate();

            if (this.rotateAmount.IsZero())
            {
                this.nextRotor.Rotate();
            }
        }
    }
}
