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
    public class PlayerConstructorTest
    {
        [Fact]
        public void ConstructorSetsName()
        {
            string expectedName = "Test Player";
            var player = new Player(expectedName);
            Xunit.Assert.Equal(expectedName, player.Name);
        }
        [Fact]
        public void ConstructorSetsCards()
        {
            var player = new Player("");
            Xunit.Assert.NotNull(player.Cards);
        }
    }
}
