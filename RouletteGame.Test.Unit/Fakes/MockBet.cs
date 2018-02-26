using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteGame.Legacy;

namespace RouletteGame.Test.Unit
{
    class MockBet : IBet
    {
        public MockBet()
        {
            WonAmountCalled = false;
        }
        public IField Field { get; private set; }
        public bool WonAmountCalled { get; private set; } // bliver mocken kaldt? 

        public uint Amount { get; set; }
        public string PlayerName { get; set; }

        public uint WonAmount(IField field)
        {
            WonAmountCalled = true;
            Field = field;
            return 0;
        }
    }
}
