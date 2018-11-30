using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace PokerHand.Tests
{
    [TestClass]
    public class GameInstanceTest
    {
        [Fact]
        public void ThereIsAlwaysOneInstanceExists()
        {
            var instance1 = Game.Instance;
            var instance2 = Game.Instance;
            Xunit.Assert.Equal(instance1, instance2);
        }
    }
}
