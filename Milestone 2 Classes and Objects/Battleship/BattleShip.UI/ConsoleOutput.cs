using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
        public void DrawShipOnBoard(Player player)
        {
            Console.Write("   ");
            for (int i = 1; i < 11; i++)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();


            int x = 65;
            int ship = 0, boardPositionLenth = player.GetBoard.Ships[ship].BoardPositions.Length - 1;
            bool skip = false;
            for (int i = 1; i <= 10; i++)
            {
                Console.Write((char)x + " ");
                Console.Write("|");
                for (int j = 1; j <= 10; j++)//prints the board
                {
                    skip = false;

                    for (int b = 0; b < player.GetBoard.Ships.Length; b++)//loop through player's ship array to find any hits, misses, or ship position to put on the board
                    {
                        if (player.GetBoard.Ships[b] != null)
                        {


                            for (int a = 0; a < player.GetBoard.Ships[b].BoardPositions.Length; a++)
                            {
                                if (i == player.GetBoard.Ships[b].BoardPositions[a].XCoordinate && j == player.GetBoard.Ships[b].BoardPositions[a].YCoordinate)//checks ship's coordinates
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    if (player.GetBoard.Ships[b] == player.GetBoard.Ships[0])
                                    {
                                        if (player.GetBoard.CheckCoordinate(new Coordinate(i, j)) == ShotHistory.Hit)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("X");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                        }
                                        else
                                        {
                                            Console.Write("D");
                                        }
                                    }
                                    else if (player.GetBoard.Ships[b] == player.GetBoard.Ships[1])
                                    {
                                        if (player.GetBoard.CheckCoordinate(new Coordinate(i, j)) == ShotHistory.Hit)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("X");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                        }
                                        else
                                        {
                                            Console.Write("S");
                                        }
                                    }
                                    else if (player.GetBoard.Ships[b] == player.GetBoard.Ships[2])
                                    {
                                        if (player.GetBoard.CheckCoordinate(new Coordinate(i, j)) == ShotHistory.Hit)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("X");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                        }
                                        else
                                        {
                                            Console.Write("c");
                                        }
                                    }
                                    else if (player.GetBoard.Ships[b] == player.GetBoard.Ships[3])
                                    {
                                        if (player.GetBoard.CheckCoordinate(new Coordinate(i, j)) == ShotHistory.Hit)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("X");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                        }
                                        else
                                        {
                                            Console.Write("B");
                                        }
                                    }
                                    else
                                    {
                                        if (player.GetBoard.CheckCoordinate(new Coordinate(i, j)) == ShotHistory.Hit)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("X");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                        }
                                        else
                                        {
                                            Console.Write("C");
                                        }
                                    }
                                    Console.ResetColor();
                                    Console.Write(" |");
                                    skip = true;
                                }
                            }
                        }

                    }
                    if (!skip)
                    {
                        if (player.GetBoard.CheckCoordinate(new Coordinate(i, j)) == ShotHistory.Miss)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M");
                            Console.ResetColor();
                            Console.Write(" |");
                            if (i == 1 && j == 10)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($"{player.Name}'s Board");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            if (i == 1 && j == 10)
                            {
                                Console.Write("__| ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($"{player.Name}'s Board");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write("__|");
                            }
                        }
                    }
                }
                Console.WriteLine();
                x++;
            }
        }

        public void DrawUserBoard(Player player)
        {
            if (player != null) //null causes issues in the if statement, need a blank board for display purposes
            {
                Console.Write("   ");
                for (int i = 1; i < 11; i++)
                {
                    Console.Write(i + "  ");
                }
                Console.WriteLine();

                int x = 65;
                //prints out board with hits and misses
                for (int i = 1; i <= 10; i++)
                {
                    Console.Write((char)x + " ");
                    Console.Write("|");
                    for (int j = 1; j <= 10; j++)
                    {
                        if (player.GetBoard.CheckCoordinate(new Coordinate(i, j)) == ShotHistory.Miss)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M");
                            Console.ResetColor();
                            Console.Write(" |");
                            if (i == 1 && j == 10)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"{player.Name}'s Board");
                                Console.ResetColor();
                            }
                        }
                        else if (player.GetBoard.CheckCoordinate(new Coordinate(i, j)) == ShotHistory.Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                            Console.ResetColor();
                            Console.Write(" |");
                            if (i == 1 && j == 10)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"{player.Name}'s Board");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            if (i == 1 && j == 10)
                            {
                                Console.Write("__| ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"{player.Name}'s Board");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write("__|");
                            }
                        }
                    }
                    Console.WriteLine();
                    x++;
                }
            }
            else
            {//displays a blank board
                Console.Write("   ");
                for (int i = 1; i < 11; i++)
                {
                    Console.Write(i + "  ");
                }
                Console.WriteLine();
                int x = 65;
                for (int i = 0; i < 10; i++)
                {
                    Console.Write((char)x + " ");
                    Console.Write("|");
                    for (int j = 1; j <= 10; j++)
                    {

                        Console.Write("__|");
                    }
                    Console.WriteLine();
                    x++;
                }
            }
        }

        public void DisplayUserAndEnemyBoard(Player player, Player player2)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enemy's Board:");
            Console.ResetColor();
            DrawUserBoard(player);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Your Board: ");
            Console.ResetColor();
            DrawShipOnBoard(player2);

            Console.WriteLine();
        }

        public void WriteColor(string message, ConsoleColor color)
        {
            //text color changes was used a few times in Attack() method, created this to shorten that code up
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
