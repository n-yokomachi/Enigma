using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public interface Rotor
    {
        IOPosition Input(IOPosition position);

        void Rotate();
    }
}
