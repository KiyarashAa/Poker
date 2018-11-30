using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHand.Tests
{
    [TestClass]
    public class GameWinnerTest
    {
        [TestMethod]
        public void SupportMultiWinner()
        {
            var p1 = new Player("p1")
            {
                Cards = new List<CardPlay>
                    {
                        new CardPlay(2,Enums.CardPlaySuit.Club),
                        new CardPlay(3,Enums.CardPlaySuit.Club),
                        new CardPlay(4,Enums.CardPlaySuit.Club),
                        new CardPlay(5,Enums.CardPlaySuit.Club),
                        new CardPlay(6,Enums.CardPlaySuit.Club),
                    }
            };
            var p2 = new Player("p2")
            {
                Cards = new List<CardPlay>
                    {
                        new CardPlay(2,Enums.CardPlaySuit.Heart),
                        new CardPlay(3,Enums.CardPlaySuit.Heart),
                        new CardPlay(4,Enums.CardPlaySuit.Heart),
                        new CardPlay(5,Enums.CardPlaySuit.Heart),
                        new CardPlay(6,Enums.CardPlaySuit.Heart),
                    }
            };
            var p3 = new Player("p3")
            {
                Cards = new List<CardPlay>
                    {
                        new CardPlay(2,Enums.CardPlaySuit.Club),
                        new CardPlay(3,Enums.CardPlaySuit.Club),
                        new CardPlay(4,Enums.CardPlaySuit.Club),
                        new CardPlay(5,Enums.CardPlaySuit.Club),
                        new CardPlay(6,Enums.CardPlaySuit.Diamond)
                    }
            };
            Game.Instance.Players = new List<Player> { p1, p2, p3 };
            var expected = new List<Player> { p1, p2 };
            var actual = Game.Instance.Winners;
            Xunit.Assert.Equal(expected, actual);
        }
    }
}
