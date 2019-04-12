using System;
using Office;
using Xunit;

namespace Test
{
    public class RobotCleanerTest

    {

        private const char V = ' ';
        [Fact]
        public void Should_move_only_if_a_place_is_clean()
        {
            var robot = new RobotCleaner.Robot(2);
            robot.Clean();

            var actual = robot.IsPlaceCleaned;

            Assert.True(actual);

        }

        [Fact]
        public void Cannot_move_to_an_out_of_bounds_place()
        {
            var office = new Office.OfficeMapGenerator(10, 10).Build();
            var robot = new RobotCleaner.Robot(2);
            robot.StartClean(office);
            var actual = new Coordinate(5, 12);

            robot.Move(actual);

            Assert.NotEqual(robot.currentPlace, actual);

        }
        [Fact]
        public void Given_a_set_of_directions_a_route_should_be_assembled()
        {

            RobotCleaner.Robot robot = SetupRobot();
            var actual = robot.Route.Count;
            var expected = 4;
            Assert.Equal(expected, actual);

        }

        // [Fact]
        // public void Given_Actions_Inital_Cordinate_and_Two_next_directions_The_Robot_should_clean_four_places_in_the_Office()
        // {

        //     RobotCleaner.Robot robot = SetupRobot();
        //     var expected = 4;

        //     var actual = robot.cleanedPlaces.Count;

        //     Assert.Equal(expected, actual);

        // }

        private RobotCleaner.Robot SetupRobot()
        {
            int actions = 2;
            string initalCoordinates = "10 22";
            string direction1 = "E 2";
            string direction2 = "N 1";

            var office = new Office.OfficeMapGenerator(10, 10).Build();
            var robot = new RobotCleaner.Robot(actions);
            robot.TurnOn(office);
            var coordinate = initalCoordinates.Split(V);
            robot.Move(new Coordinate(int.Parse(coordinate[0]), int.Parse(coordinate[1])));

            robot.AddCleaningDirections(direction1);
            robot.AddCleaningDirections(direction2);


            return robot;
        }
    }
}
