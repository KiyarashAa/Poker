using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand.Enums;
using Xunit;

namespace PokerHand.Tests
{
    [TestClass]
    public class CardPlayCompareTo
    {
        [Fact]
        public void CompareToReturnMinus1IfIsHighest()
        {
            var higher = new CardPlay(5, CardPlaySuit.Heart);
            var lower = new CardPlay(4, CardPlaySuit.Club);
            var expected = -1;
            var actual = higher.CompareTo(lower);
            Xunit.Assert.Equal(expected.ToString(), actual.ToString());
        }
        [Fact]
        public void CompareToReturnZeroIfHaveSameValue()
        {
            var higher = new CardPlay(5, CardPlaySuit.Heart);
            var lower = new CardPlay(5, CardPlaySuit.Club);
            var expected = 0;
            var actual = higher.CompareTo(lower);
            Xunit.Assert.Equal(expected, actual);
        }
    }
}
