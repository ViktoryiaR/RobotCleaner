using System;
namespace RobotCleaner
{
    public static class CommandHelper
    {
        public static Func<(int x, int y), (int x, int y)> ResolveMoveFunc(char c)
        {
            switch (c)
            {
                case 'E':
                    return MoveEast;

                case 'W':
                    return MoveWest;

                case 'S':
                    return MoveSouth;

                case 'N':
                    return MoveNorth;

                default:
                    throw new ArgumentException();
            }
        }

        private static (int x, int y) MoveEast((int x, int y) point)
        {
            return (x: point.x + 1, y: point.y);
        }

        private static (int x, int y) MoveWest((int x, int y) point)
        {
            return (x: point.x - 1, y: point.y);
        }

        private static (int x, int y) MoveSouth((int x, int y) point)
        {
            return (x: point.x, y: point.y - 1);
        }

        private static (int x, int y) MoveNorth((int x, int y) point)
        {
            return (x: point.x, y: point.y + 1);
        }
    }
}
