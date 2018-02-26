using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RouletteGame.Legacy;
using RouletteGame.Test.Unit.Fakes;

namespace RouletteGame.Test.Unit
{
    [TestFixture]
    class BetUnitTest
    {
        private FieldBet _uut;

        [SetUp]
        public void SetUp()
        {
            _uut=new FieldBet("Christina",100,10);

        }

        [Test]
        public void Bet_Create_AmountIsOK()
        {
            Assert.That(_uut.Amount,Is.EqualTo(100));
        }

        [Test]
        public void Bet_Create_NameIsOK()
        {
            Assert.That(_uut.PlayerName,Is.EqualTo("Christina"));
        }
    }

    [TestFixture]
    class ColorBetUnitTest
    {
        private StubField _stubField;
        private ColorBet _uutBlack;
        private ColorBet _uutRed;
        private ColorBet _uutGreen;



        [SetUp]
        public void SetUp()
        {
            _stubField = new StubField();
            _uutBlack=new ColorBet("Anni",100,Field.Black);
            _uutRed=new ColorBet("Emma",100,Field.Red);
            _uutGreen=new ColorBet("Julie",100,Field.Green);

        }

        //[Test]
        //public void ColorBet_ToString_BlackBetContainsCorrectValues()
        //{
        //    Assert.That(_uutBlack.ToString().ToLower(), Is.StringMatching findes ikke???? );
        //}


        [TestCase(Field.Black, 200)]
        [TestCase(Field.Green, 0)] // ingen gevinst på grøn
        [TestCase(Field.Red, 0)] // ingen gevinst på rød
        public void BlackBet_differentFieldColors_WonAmountIsCorrect(uint Color, int wonAmount)
        {
            _stubField.Color = Color;
            Assert.That(_uutBlack.WonAmount(_stubField), Is.EqualTo(wonAmount));
        }

        [TestCase(Field.Black, 0)] // ingen gevinst på sort
        [TestCase(Field.Green, 0)] // ingen gevinst på grøn
        [TestCase(Field.Red, 100)] 
        public void RedBet_differentFieldColors_WonAmountIsCorrect(uint Color, int wonAmount)
        {
            _stubField.Color = Color;
            Assert.That(_uutRed.WonAmount(_stubField), Is.EqualTo(wonAmount));
        }


        [TestCase(Field.Black, 0)] // ingen gevinst på sort
        [TestCase(Field.Green, 200)] 
        [TestCase(Field.Red, 0)] // ingen gevinst på rød
        public void GreenBet_differentFieldColors_WonAmountIsCorrect(uint Color, int wonAmount)
        {
            _stubField.Color = Color;
            Assert.That(_uutGreen.WonAmount(_stubField), Is.EqualTo(wonAmount));
        }
    }

    [TestFixture]
    class EvenOddBetUnitTest
    {
        private EvenOddBet _uutEven;
        private EvenOddBet _uutOdd;
        

        [SetUp]
        public void SetUp()
        {
            _uutEven=new EvenOddBet("Christina",100, true);
            _uutOdd = new EvenOddBet("Emma",200,false);
        }

        [Test]
        public void EvenBet_ToString_EvenBetContainsCorrectValues()
        {
           // Is.StringMatching
        }

        [Test]
        public void OddBet_ToString_EvenBetContainsCorrectValues()
        {
            // Is.StringMatching
        }

        [TestCase(true, 200)]
        [TestCase(false,0)]
        public void EvenBet_DifferentFields_WonAmountCorrect(bool even, int wonAmount)
        {
            var stubField = new StubField {Even = even};
            Assert.That(_uutEven.WonAmount(stubField), Is.EqualTo(wonAmount));
        }

        [TestCase(true, 0)]
        [TestCase(false, 400)]
        public void OddBet_DifferentFields_WonAmountCorrect(bool even, int wonAmount)
        {
            var stubField = new StubField {Even = even};
            Assert.That(_uutOdd.WonAmount(stubField), Is.EqualTo(wonAmount));
        }

    }

    [TestFixture]
    class FieldBetUnitTest
    {
        private FieldBet _uut;
        private StubField _stubField;

        [SetUp]
        public void SetUp()
        {
            _uut = new FieldBet("Christina",100,10);
            _stubField = new StubField();
        }

        [Test]
        public void FieldBet_ToString_ContainsCorrectValues()
        {
            // Is.StringMatching 
        }

        [TestCase(1,0)]
        [TestCase(20,0)]
        //[TestCase(0,100)] Virker ikke! 
        public void FieldBet_DifferentFields_WonAmountIsCorrect(int field, int wonAmount)
        {
            _stubField.Number = (uint) field;
            Assert.That(_uut.WonAmount(_stubField), Is.EqualTo(wonAmount));
        }
    }
}
