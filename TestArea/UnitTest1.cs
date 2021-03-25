using System.Collections.Generic;
using NUnit.Framework;
using Turtle.Classes;

namespace TestArea
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StillInDanger()
        {
            var cor = new Coordinates();
            var p = new Constants();
            var coordinates = p.populateCoordinates();
            var board = cor.BoardSize("5 4");
            var mines = cor.MineCounter("1,1 1,3 3,3 3,2");
            var exit = cor.ExitCoordinates("4 2");
            var turtle = cor.SetStartingPosition("0 1 N", coordinates);

            var commands = new List<string>()
            {
                "M R M M R M M M"
            };

            foreach (var item in commands)
            {
                var test = cor.ExecuteCommands(item, coordinates, board, mines, exit, turtle);

                StringAssert.AreEqualIgnoringCase("Still in Danger", test);
            }

        }


        [Test]
        public void OffLimits()
        {
            var cor = new Coordinates();
            var p = new Constants();
            var coordinates = p.populateCoordinates();
            var board = cor.BoardSize("5 4");
            var mines = cor.MineCounter("1,1 1,3 3,3 3,2");
            var exit = cor.ExitCoordinates("4 2");
            var turtle = cor.SetStartingPosition("0 1 N", coordinates);

            var commands = new List<string>()
            {
                "M M M M M M M M M M M M"
            };

            foreach (var item in commands)
            {
                var test = cor.ExecuteCommands(item, coordinates, board, mines, exit, turtle);

                StringAssert.AreEqualIgnoringCase("The turtle is out from the board limits", test);
            }

        }


        [Test]
        public void Success()
        {
            var cor = new Coordinates();
            var p = new Constants();
            var coordinates = p.populateCoordinates();
            var board = cor.BoardSize("5 4");
            var mines = cor.MineCounter("1,1 1,3 3,3 3,2");
            var exit = cor.ExitCoordinates("4 2");
            var turtle = cor.SetStartingPosition("0 1 N", coordinates);

            var commands = new List<string>()
            {
                "M R M M M M R M M"
            };

            foreach (var item in commands)
            {
                var test = cor.ExecuteCommands(item, coordinates, board, mines, exit, turtle);

                StringAssert.AreEqualIgnoringCase("Success", test);
            }

        }


        [Test]
        public void MineHit()
        {
            var cor = new Coordinates();
            var p = new Constants();
            var coordinates = p.populateCoordinates();
            var board = cor.BoardSize("5 4");
            var mines = cor.MineCounter("1,1 1,3 3,3 3,2");
            var exit = cor.ExitCoordinates("4 2");
            var turtle = cor.SetStartingPosition("0 1 N", coordinates);

            var commands = new List<string>()
            {
                "R M M M M R M M"
            };

            foreach (var item in commands)
            {
                var test = cor.ExecuteCommands(item, coordinates, board, mines, exit, turtle);

                StringAssert.AreEqualIgnoringCase("Mine Hit", test);
            }

        }
    }
}