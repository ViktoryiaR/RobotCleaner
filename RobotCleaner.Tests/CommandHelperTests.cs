using Xunit;

namespace RobotCleaner.Tests
{
    public class CommandHelperTests
    {
        private static readonly (int x, int y) initialPoint_ = (x: 0, y: 0);

        [Theory]
        [InlineData('E', 1, 0)]
        [InlineData('W', -1, 0)]
        [InlineData('S', 0, -1)]
        [InlineData('N', 0, 1)]
        public void TestMoveCommand(char c, int x, int y)
        {
            var moveFunc = CommandHelper.ResolveMoveFunc(c);
            var result = moveFunc(initialPoint_);
            Assert.Equal((x, y), result);
        }
    }
}
