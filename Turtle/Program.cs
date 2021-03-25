using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Turtle.Classes;
using Turtle.Models;

namespace Turtle
{
    class Program
    {
        static void Main(string[] args)
        {

            var cor = new Coordinates();
            var pop = new Constants();

            string _dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string _file = _dir + "/TextFile.txt";

            //Read the file
            string[] lines = File.ReadAllLines(_file);

            //Populate Constants
            var coordinates = pop.populateCoordinates();

            //Set the coordinates
            var board = cor.BoardSize(lines[0]);

            var mines = cor.MineCounter(lines[1]);

            var exit = cor.ExitCoordinates(lines[2]);

            var turtle = cor.SetStartingPosition(lines[3], coordinates);

            var commandsList = new List<string>();
            for (int i = 4; i < lines.Length; i++)
            {
                commandsList.Add(lines[i]);
            }


            //Board Display
            for (int i = 0; i < board.BoardHeight; i++)
            {
                for (int j = 0; j < board.BoardWidth; j++)
                {
                    //Check for mines
                    if (mines.Any(mine => mine.Xindex == j && mine.Yindex == i))
                    {
                        Console.Write("M"+j);
                        Console.Write("M"+ i + "  ");
                    }
                    //Set the exit
                    if (exit.Xindex == j && exit.Yindex == i)
                    {
                        Console.Write("E"+j);
                        Console.Write("E"+ i + "  ");
                    }
                    //Tiny Turtle
                    if (turtle.StartX == j && turtle.StartY == i)
                    {
                        Console.Write(j + i);
                        Console.Write(turtle.Direction);
                        Console.Write(turtle.Direction + "  ");
                    }
                    if(!mines.Any(mine => mine.Xindex == j && mine.Yindex == i)
                        && !(exit.Xindex == j && exit.Yindex == i)
                        && !(turtle.StartX == j && turtle.StartY == i))
                    {
                        Console.Write("x" + j);
                        Console.Write("y" + i + "  ");

                    }

                }



                Console.WriteLine();
                Console.WriteLine();
            }

            //Play the Game. Execute Commands
            foreach (var item in commandsList)
            {
                Console.WriteLine(cor.ExecuteCommands(item, coordinates, board, mines, exit, turtle)); 
            }

        }
    }
}
