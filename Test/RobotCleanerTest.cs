using System;
using System.Collections.Generic;
using Office;
using Xunit;

namespace Test {
    public class RobotCleanerTest {
        private const char V = ' ';

        [Fact]
        public void Given_a_few_directions_a_cleanning_Route_should_be_assembled () {

            RobotCleaner.Robot robot = SetupRobot ();
            var expected = 4;
            var actual = robot.Route.Count;
            Assert.Equal (expected, actual);

        }

        [Fact]
        public void Given_Actions_Inital_Cordinate_and_Two_next_directions_The_Robot_should_clean_four_places_in_the_Office () {

            RobotCleaner.Robot robot = SetupRobot ();
            var expected = 4;

            robot.Clean ();
            var actual = robot.CleanedPlaces.Count;

            Assert.Equal (expected, actual);

        }

        private RobotCleaner.Robot SetupRobot () {
            int actions = 2;
            string initalCoordinates = "10 22";
            List<string> directions = new List<string> ();
            directions.Add ("E 2");
            directions.Add ("N 1");

            var office = new Office.OfficeMapGenerator (40, 40).Build ();
            var robot = new RobotCleaner.Robot (actions);
            robot.Boot (directions, actions, initalCoordinates);

            return robot;
        }
    }
}