using nanoFramework.TestFramework;
using System;

namespace CCSWE.nanoFramework.Collections.Concurrent.UnitTests
{
    [TestClass]
    public class ConcurrentQueueTests
    {
        // TODO: Clone
        // TODO: CopyTo

        [TestMethod]
        public void Clear_should_remove_all_items()
        {
            // Arrange
            var create = 10;
            var expected = 0;
            var sut = new ConcurrentQueue();

            for (var i = 0; i < create; i++)
            {
                sut.Enqueue(i);
            }

            // Act
            sut.Clear();

            // Assert
            Assert.AreEqual(expected, sut.Count);
        }

        [TestMethod]
        public void Contains_should_return_false_for_null()
        {
            // Arrange
            var expected = 10;
            var sut = new ConcurrentQueue();

            for (var i = 0; i < expected; i++)
            {
                sut.Enqueue(i);
            }

            // Act
            var contains = sut.Contains(null);

            // Assert
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Contains_should_return_true()
        {
            // Arrange
            var expected = 10;
            var sut = new ConcurrentQueue();

            for (var i = 0; i < expected; i++)
            {
                sut.Enqueue(i);
            }

            // Act
            var contains = sut.Contains(0);

            // Assert
            Assert.IsTrue(contains);
        }

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

        [TestMethod]
        public void Dequeue_should_remove_item()
        {
            // Arrange
            var expected = new object();
            var sut = new ConcurrentQueue();
            sut.Enqueue(expected);

            // Act
            var actual = sut.Dequeue();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(0, sut.Count);
        }

        [TestMethod]
        public void Enqueue_should_add_item()
        {
            // Arrange
            var expected = new object();
            var sut = new ConcurrentQueue();

            // Act
            sut.Enqueue(expected);

            // Assert
            Assert.AreEqual(1, sut.Count);
        }

        [TestMethod]
        public void IsSynchronized_should_be_true()
        {
            // Arrange
            var sut = new ConcurrentQueue();

            // Act


            // Assert
            Assert.IsTrue(sut.IsSynchronized);
        }

        [TestMethod]
        public void Peek_should_not_remove_item()
        {
            // Arrange
            var expected = new object();
            var sut = new ConcurrentQueue();
            sut.Enqueue(expected);

            // Act
            var actual = sut.Peek();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, sut.Count);
        }

        [TestMethod]
        public void TryDequeue_should_return_false()
        {
            // Arrange
            var expected = new object();
            var sut = new ConcurrentQueue();

            // Act
            var result = sut.TryDequeue(out var actual);

            // Assert
            Assert.IsFalse(result);
            Assert.AreNotEqual(expected, actual);
            Assert.AreEqual(0, sut.Count);
        }

        [TestMethod]
        public void TryDequeue_should_return_true()
        {
            // Arrange
            var expected = new object();
            var sut = new ConcurrentQueue();
            sut.Enqueue(expected);

            // Act
            var result = sut.TryDequeue(out var actual);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(0, sut.Count);
        }
    }
}
