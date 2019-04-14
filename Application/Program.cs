using System;
using System.Collections.Generic;

namespace Application {
    class Program {
        static void Main (string[] args) {
            List<string> directions;
            string actions;
            string intitialPostition;
            GetRobotInputs (out directions, out actions, out intitialPostition);
            RobotCleaner.Robot robot = new RobotCleaner.Robot (int.Parse (actions));
            robot.Boot (directions, int.Parse (actions), intitialPostition);
            robot.Clean ();
            Console.WriteLine (robot.Summary ());
        }

        private static void GetRobotInputs (out List<string> directions, out string actions, out string intitialPostition) {
            directions = new List<string> ();
            Console.WriteLine ("how many actions should be done until finish?");
            actions = Console.ReadLine ();
            Console.WriteLine ("Where should I start?");
            intitialPostition = Console.ReadLine ();
            Console.WriteLine ("Where should I go next?");
            Console.WriteLine ("Press ESC to exit new directions and start cleaning");
            while (Console.ReadKey (true).Key != ConsoleKey.Escape) {

                directions.Add (Console.ReadLine ());

            }
        }
    }
}