using System;
using System.Collections.Generic;
using System.Linq;
using Turtle.Models;

namespace Turtle.Classes
{
    public class Coordinates
    {

        public List<Mine> MineCounter(string minesString)
        {
            var minesArray = minesString.Split(" ");

            var mineList = new List<Mine>();

            foreach (var m in minesArray)
            {
                var mine = new Mine();

                if (m.Contains(','))
                {
                    var splittedMine = m.Split(',');

                    mine.Xindex = int.Parse(splittedMine[0].Trim());
                    mine.Yindex = int.Parse(splittedMine[1].Trim());
                }


                mineList.Add(mine);
            }

            return mineList;
        }


        public Exit ExitCoordinates(string exitString)
        {
            var exit = new Exit();

            var cor = exitString.Trim().Split(" ");

            exit.Xindex = int.Parse(cor[0]);
            exit.Yindex = int.Parse(cor[1]);

            return exit;

        }

        public BoardGame BoardSize(string boardString)
        {
            var board = new BoardGame();

            var cor = boardString.Trim().Split(" ");

            board.BoardWidth = int.Parse(cor[0]);
            board.BoardHeight = int.Parse(cor[1]);

            return board;

        }

        public TinyTurtle SetStartingPosition(string startingPosition, List<Coordinate> coordinates)
        {
            var tt = new TinyTurtle();
            var coordinate = new Coordinate();

            var cor = startingPosition.Trim().Split(" ");
            //Starting Coordinates
            tt.StartX = int.Parse(cor[0]);
            tt.StartY = int.Parse(cor[1]);
            //XY Values
            tt.Xindex = int.Parse(cor[0]);
            tt.Yindex = int.Parse(cor[1]);
            //Direction
            tt.Direction = cor[2].Trim();

            coordinate = coordinates.Find(c => c.Description.ToLower().Equals(tt.Direction.ToLower()));
            tt.PositionValue = coordinate.PositionValue;

            return tt;
        }


        public string ExecuteCommands(string commands, List<Coordinate> coordinates,
            BoardGame board, List<Mine> mines, Exit exit, TinyTurtle turtle)
        {

            var result = new GameResult();
            
            var splittedCommands = commands.Split(" ");

            Console.WriteLine(commands); //Just Display of the current set of commands


            for (int i = 0; i < splittedCommands.Length; i++)
            {
                var coordinate = new Coordinate();

                //Check Position and Set 
                if (splittedCommands[i].ToLower() == "R".ToLower() || splittedCommands[i].ToLower() == "L".ToLower())
                {
                    coordinate = coordinates.Find(c => c.Description.ToLower().Equals(splittedCommands[i].ToLower()));
                    turtle.PositionValue = turtle.PositionValue + coordinate.PositionValue;
                }

                turtle.PositionValue = CalculateAngle(turtle.PositionValue);
                turtle.Direction = coordinates.FirstOrDefault(c => c.PositionValue == turtle.PositionValue).Description;



                if (splittedCommands[i].ToLower().Equals("M".ToLower()) && turtle.Direction.ToLower().Equals("N".ToLower()))
                {
                    turtle.Yindex--;
                }
                else if (splittedCommands[i].ToLower().Equals("M".ToLower()) && turtle.Direction.ToLower().Equals("W".ToLower()))
                {
                    turtle.Xindex--;
                }
                else if (splittedCommands[i].ToLower().Equals("M".ToLower()) && turtle.Direction.ToLower().Equals("S".ToLower()))
                {
                    turtle.Yindex++;
                }
                else if (splittedCommands[i].ToLower().Equals("M".ToLower()) && turtle.Direction.ToLower().Equals("E".ToLower()))
                {
                    turtle.Xindex++;
                }

                //check for board limits
                if (turtle.Xindex < 0 || turtle.Xindex > board.BoardWidth ||
                    turtle.Yindex < 0 || turtle.Yindex > board.BoardHeight)
                {


                    return result.Description = "The turtle is out from the board limits";

                }

                //check for mines
                if (mines.Any(m => m.Xindex == turtle.Xindex && m.Yindex == turtle.Yindex))
                {

                    return result.Description = "Mine Hit";
                }

                //Check for exit
                if (exit.Xindex == turtle.Xindex && exit.Yindex == turtle.Yindex)
                {
                    return result.Description = "Success";

                }

            }

            return result.Description = "Still in Danger";
        }

        private int CalculateAngle(int degree)
        {
            return (degree % 360 + 360) % 360;
        }

    }

}
