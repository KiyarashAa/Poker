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
    public class PlayerCompareToTest
    {
        [Fact]
        public void CompareToHighCards()
        {
            var winner = new Player("Winner")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(8,CardPlaySuit.Club),
                    new CardPlay(14,CardPlaySuit.Heart),
                    new CardPlay(5,CardPlaySuit.Diamond),
                    new CardPlay(9,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Club),
                }
            };
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(12,CardPlaySuit.Club),
                    new CardPlay(13,CardPlaySuit.Heart),
                    new CardPlay(10,CardPlaySuit.Diamond),
                    new CardPlay(9,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Club),
                }
            };
            var expected = -1;//because in compareTo is designed to sort list Descending
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
        }
        [Fact]
        public void CompareToFlushWinsThreeOfKind()
        {
            var winner = new Player("Winner")
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
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(14,CardPlaySuit.Club),
                    new CardPlay(14,CardPlaySuit.Heart),
                    new CardPlay(14,CardPlaySuit.Diamond),
                    new CardPlay(9,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Club),
                }
            };
            var expected = -1;
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
        }
        [Fact]
        public void CompareToThreeOfKindWinsOnePair()
        {
            var winner = new Player("Winner")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(5,CardPlaySuit.Club),
                    new CardPlay(5,CardPlaySuit.Heart),
                    new CardPlay(5,CardPlaySuit.Diamond),
                    new CardPlay(9,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Club),
                }
            };
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(14,CardPlaySuit.Club),
                    new CardPlay(14,CardPlaySuit.Heart),
                    new CardPlay(13,CardPlaySuit.Diamond),
                    new CardPlay(9,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Club),
                }
            };
            var expected = -1;
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
        }
        [Fact]
        public void CompareToOnePairWinsHighCards()
        {
            var winner = new Player("Winner")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(5,CardPlaySuit.Club),
                    new CardPlay(5,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Diamond),
                    new CardPlay(9,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Club),
                }
            };
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(14,CardPlaySuit.Club),
                    new CardPlay(7,CardPlaySuit.Heart),
                    new CardPlay(13,CardPlaySuit.Diamond),
                    new CardPlay(9,CardPlaySuit.Club),
                    new CardPlay(2,CardPlaySuit.Club),
                }
            };
            var expected = -1;
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void CompareTo2FlushHandHighestWins()
        {
            var winner = new Player("Winner")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(14,CardPlaySuit.Heart),
                    new CardPlay(10,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Heart),
                    new CardPlay(9,CardPlaySuit.Heart),
                    new CardPlay(2,CardPlaySuit.Heart),
                }
            };
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(12,CardPlaySuit.Diamond),
                    new CardPlay(7,CardPlaySuit.Diamond),
                    new CardPlay(13,CardPlaySuit.Diamond),
                    new CardPlay(9,CardPlaySuit.Diamond),
                    new CardPlay(2,CardPlaySuit.Diamond),
                }
            };
            var expected = -1;
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
            Xunit.Assert.True(winner.Flush > loser.Flush);
        }
        [Fact]
        public void CompareTo2FlushHandHighestCardIsSameAnotherKickerWins()
        {
            var winner = new Player("Winner")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(14,CardPlaySuit.Heart),
                    new CardPlay(10,CardPlaySuit.Heart),
                    new CardPlay(9,CardPlaySuit.Heart),
                    new CardPlay(3,CardPlaySuit.Heart),
                    new CardPlay(2,CardPlaySuit.Heart),
                }
            };
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(14,CardPlaySuit.Diamond),
                    new CardPlay(10,CardPlaySuit.Diamond),
                    new CardPlay(8,CardPlaySuit.Diamond),
                    new CardPlay(6,CardPlaySuit.Diamond),
                    new CardPlay(5,CardPlaySuit.Diamond),
                }
            };
            var expected = -1;
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
            Xunit.Assert.True(winner.Flush == loser.Flush);
        }
        [Fact]
        public void CompareTo2ThreeOfKindHandHighestWins()
        {
            var winner = new Player("Winner")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(3,CardPlaySuit.Heart),
                    new CardPlay(10,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Club),
                    new CardPlay(6,CardPlaySuit.Spade),
                }
            };
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(12,CardPlaySuit.Spade),
                    new CardPlay(7,CardPlaySuit.Heart),
                    new CardPlay(5,CardPlaySuit.Diamond),
                    new CardPlay(5,CardPlaySuit.Diamond),
                    new CardPlay(5,CardPlaySuit.Diamond),
                }
            };
            var expected = -1;
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
            Xunit.Assert.True(winner.ThreeOfKind > loser.ThreeOfKind);
        }

        [Fact]
        public void CompareTo2OnePairHandHighestWins()
        {
            var winner = new Player("Winner")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(3,CardPlaySuit.Heart),
                    new CardPlay(10,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Club),
                    new CardPlay(8,CardPlaySuit.Spade),
                }
            };
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(12,CardPlaySuit.Spade),
                    new CardPlay(7,CardPlaySuit.Heart),
                    new CardPlay(5,CardPlaySuit.Diamond),
                    new CardPlay(5,CardPlaySuit.Diamond),
                    new CardPlay(3,CardPlaySuit.Diamond),
                }
            };
            var expected = -1;
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
            Xunit.Assert.True(winner.OnePair > loser.OnePair);
        }
        [Fact]
        public void CompareTo2SameOnePairHandHighestWins()
        {
            var winner = new Player("Winner")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(3,CardPlaySuit.Heart),
                    new CardPlay(13,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Club),
                    new CardPlay(8,CardPlaySuit.Spade),
                }
            };
            var loser = new Player("Loser")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(12,CardPlaySuit.Spade),
                    new CardPlay(7,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Diamond),
                    new CardPlay(6,CardPlaySuit.Diamond),
                    new CardPlay(3,CardPlaySuit.Diamond),
                }
            };
            var expected = -1;
            var actual = winner.CompareTo(loser);
            Xunit.Assert.Equal(expected, actual);
            Xunit.Assert.True(winner.OnePair == loser.OnePair);
        }
        [Fact]
        public void CompareFlushToMultiWinnerSituation()
        {
            var p1 = new Player("p1")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(3,CardPlaySuit.Heart),
                    new CardPlay(10,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Heart),
                    new CardPlay(6,CardPlaySuit.Club),
                    new CardPlay(8,CardPlaySuit.Spade),
                }
            };
            var p2 = new Player("p2")
            {
                Cards = new List<CardPlay>
                {
                    new CardPlay(3,CardPlaySuit.Diamond),
                    new CardPlay(10,CardPlaySuit.Diamond),
                    new CardPlay(6,CardPlaySuit.Diamond),
                    new CardPlay(6,CardPlaySuit.Spade),
                    new CardPlay(8,CardPlaySuit.Club),
                }
            };
            var expected = 0;
            var actual = p1.CompareTo(p2);
            Xunit.Assert.Equal(expected, actual);
        }
    }
}
