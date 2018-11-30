using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace PokerHand.Tests
{
    [TestClass]
    public class GameClearSelectedCardsTest
    {
        //[Fact]
        public void CardsWillAddedToAvailableList()
        {
            var c1 = Game.Instance.GetCardPlay("2C");
            var c2 = Game.Instance.GetCardPlay("3C");
            var c3 = Game.Instance.GetCardPlay("4C");
            var c4 = Game.Instance.GetCardPlay("5C");
            var cards = new List<CardPlay>
            {
                c1,
                c2,
                c3,
                c4,
            };
            Game.Instance.ClearSelectedCards(cards);
            Xunit.Assert.Contains(Game.Instance.AvailableCards, c => c == c1);
            Xunit.Assert.Contains(Game.Instance.AvailableCards, c => c == c2);
            Xunit.Assert.Contains(Game.Instance.AvailableCards, c => c == c3);
            Xunit.Assert.Contains(Game.Instance.AvailableCards, c => c == c4);
        }

        //[Fact]
        public void CardsWillCleared()
        {
            var c1 = Game.Instance.GetCardPlay("2C");
            var c2 = Game.Instance.GetCardPlay("3C");
            var c3 = Game.Instance.GetCardPlay("4C");
            var c4 = Game.Instance.GetCardPlay("5C");
            var cards = new List<CardPlay>
            {
                c1,
                c2,
                c3,
                c4,
            };
            Game.Instance.ClearSelectedCards(cards);
            Xunit.Assert.False(cards.Any());
        }
    }
}
