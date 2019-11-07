using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Reflector : Rotor
    {
        public IOPosition Input(IOPosition position)
        {
            return position.Plus(13);
        }

        public void Rotate()
        {
            // Reflector does not rotate.
        }
    }
}
