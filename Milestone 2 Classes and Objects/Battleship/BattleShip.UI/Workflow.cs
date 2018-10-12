using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;

namespace BattleShip.UI
{
    public class Workflow
    {
        Player player1, player2;
        ConsoleInput cInput = new ConsoleInput();
        ConsoleOutput cOutput = new ConsoleOutput();
        AsciiArt art = new AsciiArt();

        public void Run()
        {


            bool playAgain = false;

            do//loop that will start the game again if user wants to play again
            {
                //clear screen and print welcome message
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                art.Welcome();
                Console.WriteLine("\nWelcome to the game of Battleship");
                Console.WriteLine("\n\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();

                //players enter in their name
                player1 = new Player("What is your First name Player 1: ");
                player2 = new Player("What is your First name Player 2: ");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

                //have user place ship on the board
                SetupBoard(player1);
                SetupBoard(player2);

                //randomly decide who starts first and declare some variables
                Console.Clear();
                string winner = "";
                FireShotResponse victory = null;
                Random r = new Random();
                int goFirst;
                Console.WriteLine("Lets flip a coin to see who goes first.");
                Console.WriteLine($"{player1.Name.ToUpper()} is tails and {player2.Name.ToUpper()} is heads");
                Console.WriteLine("Press any key to flip the coin...");
                Console.ReadKey();
                goFirst = r.Next(0, 2);
                if (goFirst == 0)
                {
                    cOutput.WriteColor($"The coin landed on heads. {player2.Name.ToUpper()} goes first.", ConsoleColor.Cyan);
                }
                else if (goFirst == 1)
                {
                    cOutput.WriteColor($"The coin landed on tails. {player1.Name.ToUpper()} goes first.", ConsoleColor.Cyan);
                }


                do//start the attack
                {
                    if (goFirst == 0)
                    {
                        victory = Attack(player1, player2);
                        if (victory.ShotStatus == ShotStatus.Victory)
                        {
                            winner = player2.Name;
                            break;
                        }
                        goFirst++;
                    }
                    else if (goFirst == 1)
                    {
                        victory = Attack(player2, player1);
                        winner = player1.Name;
                        goFirst--;
                    }
                } while (victory.ShotStatus != ShotStatus.Victory);

                Console.Clear();

                //winning and losing message
                if (winner == player1.Name)
                {
                    art.WinMessage(player1.Name);
                    art.LoseMessage(player2.Name);
                }
                else
                {
                    art.WinMessage(player2.Name);
                    art.LoseMessage(player1.Name);
                }

                Console.WriteLine();

                //ask if user wants to play again
                while (true)
                {//loop until user correctly types in yes or no
                    Console.WriteLine("Do you want to play again, yes or no: ");
                    string input = Console.ReadLine();
                    if (input == "yes")
                    {
                        playAgain = true;
                        break;
                    }
                    else if (input == "no")
                    {
                        playAgain = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                }
            } while (playAgain);

            //thanks for playing message
            Console.Clear();
            art.EndGameMessage();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }//end of run

        //show board and ask user for input on where they want to attack
        private FireShotResponse Attack(Player playerDefend, Player playerAttack)
        {
            Coordinate coord;
            FireShotResponse result;
            bool completed = false;

            cOutput.DisplayUserAndEnemyBoard(playerDefend, playerAttack);

            do
            {
                //validation to make sure user's input are valid
                coord = cInput.GetUserCoord($"{playerAttack.Name}, Where do you want to attack: ");
                result = playerDefend.GetBoard.FireShot(coord);
                if (result.ShotStatus == ShotStatus.Miss)
                {
                    cOutput.DisplayUserAndEnemyBoard(playerDefend, playerAttack);

                    cOutput.WriteColor("You missed", ConsoleColor.Red);
                    completed = true;
                }
                else if (result.ShotStatus == ShotStatus.Hit)
                {
                    cOutput.DisplayUserAndEnemyBoard(playerDefend, playerAttack);

                    cOutput.WriteColor($"Nice one {playerAttack.Name}, you hit a ship.", ConsoleColor.Green);
                    completed = true;
                }
                else if (result.ShotStatus == ShotStatus.Invalid)
                {
                    cOutput.WriteColor("Invalid Shot. The shot was not inside the board.  Try again.", ConsoleColor.Red);
                    cOutput.DisplayUserAndEnemyBoard(playerDefend, playerAttack);
                }
                else if (result.ShotStatus == ShotStatus.HitAndSunk)
                {
                    cOutput.DisplayUserAndEnemyBoard(playerDefend, playerAttack);

                    cOutput.WriteColor($"Congrats, you destroyed {playerDefend.Name}'s {result.ShipImpacted}.", ConsoleColor.Green);
                    Console.ResetColor();
                    completed = true;
                }
                else if (result.ShotStatus == ShotStatus.Duplicate)
                {
                    cOutput.WriteColor("Already shot there, try again.", ConsoleColor.Cyan);
                    cOutput.DisplayUserAndEnemyBoard(playerDefend, playerAttack);
                }
                else if (result.ShotStatus == ShotStatus.Victory)
                {
                    completed = true;
                }
            } while (!completed);

            if (result.ShotStatus != ShotStatus.Victory)//message about whos turn is next as long as no one has won yet
            {
                Console.Clear();
                Console.Write($"Your Turn is over, ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(playerDefend.Name);
                Console.ResetColor();
                Console.Write("'s turn is next.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

            return result;
        }



        //get user input to place their ship on the board
        private void SetupBoard(Player player)
        {
            PlaceShipRequest placeShip = new PlaceShipRequest();
            ShipPlacement result = new ShipPlacement();
            ShipType shipType = new ShipType();
            int nextShip = 0;

            //clear screen and show the board layout
            Console.Clear();
            cOutput.DrawUserBoard(null);
            Console.WriteLine();
            Console.Write("Place your ships, ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(player.Name.ToUpper());
            Console.ResetColor();

            for (int i = 0; i < 5; i++)//loop through the five ships needed to be placed
            {

                do
                {
                    //start placing ship
                    Console.WriteLine();
                    placeShip.Coordinate = cInput.GetUserCoord($"{player.Name}, Where do you want to place the {shipType + nextShip}: ");
                    placeShip.Direction = cInput.GetShipDirection();
                    placeShip.ShipType = shipType + nextShip;
                    result = player.GetBoard.PlaceShip(placeShip);

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (result == ShipPlacement.NotEnoughSpace)

                    {

                        Console.WriteLine("Invalid placement. Not enough space.");

                    }

                    else if (result == ShipPlacement.Overlap)

                    {

                        Console.WriteLine("Invalid placement. There's already a ship there.");

                    }
                    Console.ResetColor();
                } while (result != ShipPlacement.Ok);

                nextShip++;//used to move to the next ship type to be placed on the board
                Console.Clear();
                cOutput.DrawShipOnBoard(player);

            }

            Console.Clear();
            cOutput.DrawShipOnBoard(player);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();


        }
    }
}
