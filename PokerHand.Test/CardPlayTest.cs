using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerHand.Test
{

    public class CardPlayTest
    {
        [Theory]
        //[InlineData("♥")]
        //[InlineData("♦")]
        //[InlineData("♣")]
        //[InlineData("♠")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData(null)]
        public void SetSignAndValue_CheckWrongInputForSign(string signValue)
        {
            var cardPlay = new CardPlay();
            cardPlay.SetSignAndValue(signValue);
            Assert.Throws<ArgumentNullException>(() =>
            {

            }
            );
        }
    }
}
