using System;
using Office;

namespace RobotCleaner
{
    internal class CoordinateCalculator
    {
        internal static void Increase(Coordinate newCoordinate, string direction)
        {
             
            switch (direction)
            {
                case "N":
                newCoordinate =  new Coordinate(newCoordinate.X,newCoordinate.Y+1);
                break;
                case "S":
                newCoordinate =  new Coordinate(newCoordinate.X,newCoordinate.Y-1);
                break;
                case "E":
                newCoordinate =  new Coordinate(newCoordinate.X-1,newCoordinate.Y);
                break;
                case "W":
                newCoordinate =  new Coordinate(newCoordinate.X+1,newCoordinate.Y);
                break;
                default:
                break;                
            }
        }
    }
}