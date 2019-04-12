using System;
using Xunit;

namespace Test
{
    public class RobotCleanerTest

    {
        [Fact]
        public void Should_move_only_if_a_place_is_clean()
        {
            var robot = new RobotCleaner.Robot(2);
            robot.Clean();
            Assert.True(robot.CanMoveToNextPlace);
        }

        
    }
}
