using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteGame.Legacy;

namespace RouletteGame.Test.Unit.Fakes
{
    class StubField:IField
    {
        public uint Color { get; set; }
        public bool Even { get; set; }
        public uint Number { get; set; }
    }
}
