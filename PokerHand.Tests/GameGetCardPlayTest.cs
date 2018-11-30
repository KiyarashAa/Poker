using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace PokerHand.Tests
{
    [TestClass]
    public class GameGetCardPlayTest
    {
        //[Fact]
        public void PreventToGetSameCard()
        {
            var cardPlay1 = Game.Instance.GetCardPlay("7S");
            var cardPlay2 = Game.Instance.GetCardPlay("7S");
            Xunit.Assert.NotNull(cardPlay1);
            Xunit.Assert.Null(cardPlay2);
        }

    }
}
