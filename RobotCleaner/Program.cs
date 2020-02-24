using System;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            var startingPoint = ParseStartingPoint(Console.ReadLine());

            var commands = new (char c, int s)[numberOfCommands];
            for (var i = 0; i < numberOfCommands; i++)
            {
                commands[i] = ParseCommand(Console.ReadLine());
            }

            var result = RobotCleaner.Clean(startingPoint, commands);
            Console.WriteLine($"=> Cleaned: {result}");
        }

        private static (int x, int y) ParseStartingPoint(string input)
        {
            var args = input.Split(' ');
            return (x: int.Parse(args[0]), y: int.Parse(args[1]));
        }

        private static (char c, int s) ParseCommand(string input)
        {
            var args = input.Split(' ');
            return (c: char.Parse(args[0]), s: int.Parse(args[1]));
        }
    }
}
