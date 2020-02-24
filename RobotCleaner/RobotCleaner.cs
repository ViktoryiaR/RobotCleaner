using System;
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
                Func<(int x, int y), (int x, int y)> getNextPointFunc;
                switch (command.c)
                {
                    case 'E':
                        getNextPointFunc = (p) => (x: p.x + 1, y: p.y);
                        break;

                    case 'W':
                        getNextPointFunc = (p) => (x: p.x - 1, y: p.y);
                        break;

                    case 'S':
                        getNextPointFunc = (p) => (x: p.x, y: p.y - 1);
                        break;;

                    case 'N':
                        getNextPointFunc = (p) => (x: p.x, y: p.y + 1);
                        break;

                    default:
                        throw new ArgumentException();
                }

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
