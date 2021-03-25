using System;
using System.Collections.Generic;
using Turtle.Models;

namespace Turtle.Classes
{
    public class Constants
    {
        public List<Coordinate> populateCoordinates()
        {
            var coordinates = new List<Coordinate>();

            var North = new Coordinate
            {
                Description = "N",
                PositionValue = 90
            };

            var South = new Coordinate
            {
                Description = "S",
                PositionValue = 270
            };

            var West = new Coordinate
            {
                Description = "W",
                PositionValue = 180
            };

            var East = new Coordinate
            {
                Description = "E",
                PositionValue = 0
            };

            var Right = new Coordinate
            {
                Description = "R",
                PositionValue = -90
            };

            var Left = new Coordinate
            {
                Description = "L",
                PositionValue = +90
            };

            var Move = new Coordinate
            {
                Description = "M",
                PositionValue = 1
            };

            coordinates.Add(North);
            coordinates.Add(South);
            coordinates.Add(West);
            coordinates.Add(East);
            coordinates.Add(Right);
            coordinates.Add(Left);
            coordinates.Add(Move);

            return coordinates;
        }
    }
}
