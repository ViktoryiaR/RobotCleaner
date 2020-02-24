using Xunit;

namespace RobotCleaner.Tests
{
    public class RobotCleanerTests
    {
        [Fact]
        public void TestZeroCommands()
        {
            var result = RobotCleaner.Clean((x: 0, y: 0), new (char c, int s)[0]);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestNotOverlappingCommands()
        {
            var result = RobotCleaner.Clean((x: 0, y: 0), new []
            {
                (c: 'E', s: 2),
                (c: 'N', s: 1)
            });
            Assert.Equal(4, result);
        }

        [Fact]
        public void TestOverlappingCommands()
        {
            var result = RobotCleaner.Clean((x: 0, y: 0), new[]
            {
                (c: 'E', s: 2),
                (c: 'W', s: 1)
            });
            Assert.Equal(3, result);
        }
    }
}
