using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerHand.Tests
{
    [TestClass]
    public class GameAvailableCards
    {
        [Fact]
        public void ThereIsNoDuplicatedCard()
        {
            lock (Game.Instance.AvailableCards)
            {
                var expected = Game.Instance.AvailableCards.Count;
                var actual = (from card in Game.Instance.AvailableCards
                              group card by new { card.Value, card.Suit } into g
                              let count = g.Count()
                              orderby count descending
                              select new
                              {
                                  Count = count,
                                  Key = g.Key
                              }).Count();
                Xunit.Assert.Equal(expected, actual);
            }
        }
    }
}
