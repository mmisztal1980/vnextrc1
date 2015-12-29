using System;
using Hive.TestKit;
using Xunit;

namespace Hive.Core.UnitTests
{
    public class ConditionTests
    {
        private const string TestMessage = "test message";

        [Fact]
        public void Require_True_DoesNotThrow()
        {
            // Act
            Condition.Require<TestException>(true);
        }

        [Fact]
        public void Require_False_Throws()
        {
            // Assert
            Assert.Throws<TestException>(() =>
            {
                Condition.Require<TestException>(false);
            });
        }

        [Fact]
        public void Require_FalseAndMessage_ThrowsWithMessage()
        {
            // Assert
            Assert.Throws<TestException>(() =>
            {
                Condition.Require<TestException>(false, TestMessage);
            }).Message.ShouldEqual(TestMessage);
        }

        [Fact]
        public void ArgumentNotNull_NotNull_DoesNotThrow()
        {
            // Act
            Condition.ArgumentNotNull(new object(), TestMessage);
        }

        [Fact]
        public void ArgumentNotNull_Null_ThrowsArgumentNullExceptionWithMessage()
        {
            // Arrange
            object o = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.ArgumentNotNull(o, TestMessage);
            }).Message.ShouldContain(TestMessage);
        }

        [Fact]
        public void ArgumentNotNullOrEmpty_String_DoesNotThrow()
        {
            // Act
            Condition.ArgumentNotNullOrEmpty("test", TestMessage);
        }

        [Fact]
        public void ArgumentNotNullOrEmpty_Null_ThrowsArgumentExceptionWithMessage()
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.ArgumentNotNullOrEmpty(null, TestMessage);
            }).Message.ShouldEqual(TestMessage);
        }

        [Fact]
        public void ArgumentNotNullOrEmpty_Empty_ThrowsArgumentExceptionWithMessage()
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.ArgumentNotNullOrEmpty(string.Empty, TestMessage);
            }).Message.ShouldEqual(TestMessage);
        }

        private class TestException : Exception
        {
            public TestException()
                : base()
            { }

            public TestException(string message)
                : base(message)
            {
            }
        }
    }
}