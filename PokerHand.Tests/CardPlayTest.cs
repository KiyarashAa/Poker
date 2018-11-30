using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand.Extenstions;
using PokerHand.Interfaces;
using Xunit;

namespace PokerHand.Tests
{
   
    [TestClass]
    public class CardPlaySuitAndValueMethodTest
    {
        [Theory]
        [InlineData("1f")]
        [InlineData(" 3m")]
        [InlineData("Av")]
        public void WrongInputForSuit(string suitValue)
        {
            var cardPlay = new CardPlay();
            var ex = Xunit.Assert.Throws<ArgumentOutOfRangeException>(() => cardPlay.SetSuitAndValue(suitValue));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData(null)]
        public void ArgumentNullException(string suitValue)
        {
            var cardPlay = new CardPlay();
            var ex = Xunit.Assert.Throws<ArgumentNullException>(() => cardPlay.SetSuitAndValue(suitValue));
        }

        [Theory]
        [InlineData("23D")]
        [InlineData("AJS")]
        [InlineData("KTH")]
        [InlineData("ASC")]
        public void WrongInputForValue(string suitValue)
        {
            var cardPlay = new CardPlay();
            var ex = Xunit.Assert.Throws<ArgumentOutOfRangeException>(() => cardPlay.SetSuitAndValue(suitValue));
            var expected = suitValue[suitValue.Length - 1].ToString();
            var actual = cardPlay.Suit.ToStringCode();
            Xunit.Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("a D")]
        [InlineData(" JS")]
        [InlineData(" 10  h ")]
        [InlineData("9c")]
        public void CanHandleWhiteSpaces(string suitValue)
        {
            var cardPlay = new CardPlay();
            cardPlay.SetSuitAndValue(suitValue);
            suitValue=suitValue.Trim();
            var expectedSuit = suitValue[suitValue.Length - 1].ToString().ToUpper();
            var expectedValue = suitValue.Trim().Substring(0, suitValue.Length - 1).Trim().ToUpper();
            var expected = expectedValue + expectedSuit;
            var actual = cardPlay.ToString();
            Xunit.Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("JD")]
        [InlineData("ks")]
        [InlineData("ah")]
        [InlineData("qc")]
        public void ValueAssuitedCorrectly(string suitValue)
        {
            var cardPlay = new CardPlay();
            cardPlay.SetSuitAndValue(suitValue);
            suitValue = suitValue.Trim();
            var expectedValue = suitValue.Trim().Substring(0, suitValue.Length - 1).Trim().ToUpper();
            int expected;
            switch (expectedValue)
            {
                case "A":
                    expected = 14;
                    break;
                case "K":
                    expected = 13;
                    break;
                case "Q":
                    expected = 12;
                    break;
                case "J":
                    expected = 11;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{expectedValue} is not a card value");
            }
            var actual = cardPlay.Value.ToString();
            Xunit.Assert.Equal(expected.ToString(), actual);
        }


    }
}
