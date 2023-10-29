using nanoFramework.TestFramework;
using System;

namespace CCSWE.nanoFramework.Collections.Concurrent.UnitTests
{
    [TestClass]
    public class ConcurrentQueueTests
    {
        [TestMethod]
        public void Count_should_return_correct_value()
        {
            // Arrange
            var expected = 10;
            var sut = new ConcurrentQueue();

            // Act
            for (var i = 0; i < expected; i++)
            {
                sut.Enqueue(i);
            }

            // Assert
            Assert.AreEqual(expected, sut.Count);
        }
    }
}
