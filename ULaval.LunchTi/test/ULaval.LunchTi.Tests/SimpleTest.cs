using Xunit;

namespace ULaval.LunchTi.Tests
{
    public class SimpleTest
    {
        [Fact]
        public void PassingTest()
        {
            //Arrange
            var expectedResult = 4;

            //Act
            var result = Add(2, 2);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void FailingTest()
        {
            //Arrange
            var unExpectedResult = 5;

            //Act
            var result = Add(2, 2);

            //Assert
            Assert.NotEqual(unExpectedResult, result);
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
