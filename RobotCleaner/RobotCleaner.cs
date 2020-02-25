using System.Collections.Generic;

namespace RobotCleaner
{
    public static class RobotCleaner
    {
        public static int Clean((int x, int y) startingPoint, (char c, int s)[] commands)
        {
            var cleanedPlaces = new HashSet<(int x, int y)>
            {
                startingPoint
            };

            var currentPoint = startingPoint;
            foreach (var command in commands)
            {
                var getNextPointFunc = CommandHelper.ResolveMoveFunc(command.c);

                for (var i = 0; i < command.s; i++)
                {
                    currentPoint = getNextPointFunc(currentPoint);
                    cleanedPlaces.Add(currentPoint);
                }
            }

            return cleanedPlaces.Count;
        }
    }
}
