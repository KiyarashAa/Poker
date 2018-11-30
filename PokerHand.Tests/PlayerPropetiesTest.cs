using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHand.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerHand.Tests
{
    [TestClass]
    public class PlayerPropetiesTest
    {
        [Fact]
        public void FlushReturnsHighestCard()
        {
            var p1 = new Player("p1")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(8,CardPlaySuit.Club),
                    new CardPlay(14,CardPlaySuit.Club),
                    new CardPlay(5,CardPlaySuit.Club),
                    new CardPlay(9,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Club),
                }
            };
            var expected = 14;
            var actual = p1.Flush;
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeOfKindReturnsHighestCard()
        {
            var p1 = new Player("p1")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(8,CardPlaySuit.Club),
                    new CardPlay(14,CardPlaySuit.Club),
                    new CardPlay(4,CardPlaySuit.Heart),
                    new CardPlay(4,CardPlaySuit.Club),
                    new CardPlay(4,CardPlaySuit.Spade),
                }
            };
            var expected = 4;
            var actual = p1.ThreeOfKind;
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnePairReturnsHighestCard()
        {
            var p1 = new Player("p1")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(8,CardPlaySuit.Club),
                    new CardPlay(14,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Heart),
                    new CardPlay(4,CardPlaySuit.Club),
                    new CardPlay(4,CardPlaySuit.Spade),
                }
            };
            var expected = 4;
            var actual = p1.OnePair;
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighCardReturnsHighestCard()
        {
            var p1 = new Player("p1")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(8,CardPlaySuit.Club),
                    new CardPlay(14,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Heart),
                    new CardPlay(4,CardPlaySuit.Club),
                    new CardPlay(6,CardPlaySuit.Heart),
                }
            };
            var expected = 14;
            var actual = p1.HighCard;
            Xunit.Assert.Equal(expected, actual);
        }
    }
}
