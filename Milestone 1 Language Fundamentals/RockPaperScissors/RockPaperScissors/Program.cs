using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            //declare variables
            int intComputerChoice, intUserInput, intUserWins, intComputerWins, intTies, intRounds;
            Random r = new Random();
            string strEndGame;
            bool boolEndGame = false;

            //keep playing until game quits, game ends if invaild round choice or user chooses to quit
            while (!boolEndGame)
            {
                Console.Clear();
                title();

                //assign variables
                intUserWins = 0;
                intComputerWins = 0;
                intTies = 0;

                //ask how many rounds to play
                Console.Write("How many rounds do you want to play [1-10]: ");

                //parse user input and end game immediately if incorrect round was selected
                if(int.TryParse(Console.ReadLine(), out intRounds))
                {
                    if (intRounds < 1 || intRounds > 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your choice was not between 1-10. Quiting Game.");
                        Console.ResetColor();
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input. Quitting Game");
                    Console.ResetColor();
                    break;
                }

                Console.Clear();
                title();

                //loop the game based on how many rounds the user wants
                for (int i = 0; i < intRounds; i++)
                {
                                        
                    //ask user to choose rock paper or scissor
                    Console.WriteLine($"Round {i + 1}:");
                    Console.WriteLine("1 - Rock");
                    Console.WriteLine("2 - Paper");
                    Console.WriteLine("3 - Scissor");
                    while (true)//keep asking if user does not choose correct response
                    {
                        Console.Write("Do you choose [1, 2, or 3]: ");
                        if (int.TryParse(Console.ReadLine(), out intUserInput))
                        {
                            if(intUserInput == 1 || intUserInput == 2 || intUserInput == 3)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You did not choose 1, 2, or 3. Try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input. Try again.");
                        }

                    }
                    Console.WriteLine();

                    //computer generate random rock, paper, or scissor
                    intComputerChoice = r.Next(1, 4);

                    //check to see who wins
                    if (intUserInput == intComputerChoice)
                    {        //tie
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        printRoundWinMessage(intUserInput, intComputerChoice);
                        Console.WriteLine("It's a TIE.");
                        Console.ResetColor();
                        intTies++;
                        Console.WriteLine();
                        Console.WriteLine("Press any key to Continue...");
                        Console.ReadKey();

                    }         //user win
                    //          rock vs scissor (rock wins)                              paper vs rock (paper wins)                  scissor vs paper (scissor wins)
                    else if ((intUserInput == 1 && intComputerChoice == 3) || (intUserInput == 2 && intComputerChoice == 1) || (intUserInput == 3 && intComputerChoice == 2))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        printRoundWinMessage(intUserInput, intComputerChoice);
                        Console.WriteLine("You WIN!!!...this round.");
                        Console.ResetColor();
                        intUserWins++;
                        Console.WriteLine();
                        Console.WriteLine("Press any key to Continue...");
                        Console.ReadKey();
                    }
                    else
                    {         //computer win
                        Console.ForegroundColor = ConsoleColor.Red;
                        printRoundWinMessage(intUserInput, intComputerChoice);
                        Console.WriteLine("Computer wins. You LOSE this round.");
                        Console.ResetColor();
                        intComputerWins++;
                        Console.WriteLine();
                        Console.WriteLine("Press any key to Continue...");
                        Console.ReadKey();
                    }
                    Console.Clear();
                    title();

                }

                //print out ending messages
                Console.WriteLine("Game End");
                Console.WriteLine($"Ties: {intTies}");
                Console.WriteLine($"Your Wins: {intUserWins}");
                Console.WriteLine($"Computer Wins: {intComputerWins}");
                if (intUserWins == intComputerWins)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine("It's a Tie.");
                    Console.ResetColor();
                }
                else if (intUserWins > intComputerWins)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("Congratulations. You are the Winner.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("The Computer wins. You Lose.");
                    Console.ResetColor();
                }

                //ask if user wants to keep playing
                Console.WriteLine();
                while (true)
                {
                    Console.Write("Do you want to keep playing? [yes or no]: ");
                    strEndGame = Console.ReadLine().ToLower();
                    if (strEndGame == "no")
                    {
                        boolEndGame = true;
                        Console.Clear();
                        endGameMessage();
                        break;
                    }
                    if(strEndGame == "yes")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input. Try again.");
                    }
                }
            }

            Console.ReadKey();
        }

        static string RockPaperScissor(int x)
        {
            //return string rock, paper, or scissor based on 1-3
            if(x == 1)
            {
                return "ROCK";
            }else if(x == 2)
            {
                return "PAPER";
            }
            else
            {
                return "SCISSOR";
            }
            
        }

        static void printRoundWinMessage(int userInput, int computerInput)
        {
            //print out round winning message
            Console.WriteLine($"{RockPaperScissor(userInput)} (your choice) vs {RockPaperScissor(computerInput)} (computer's choice)");
        }

        static void endGameMessage()
        {
            Console.Write(@"  _______ _                 _           __                   _             _             
 |__   __| |               | |         / _|                 | |           (_)            
    | |  | |__   __ _ _ __ | | _____  | |_ ___  _ __   _ __ | | __ _ _   _ _ _ __   __ _ 
    | |  | '_ \ / _` | '_ \| |/ / __| |  _/ _ \| '__| | '_ \| |/ _` | | | | | '_ \ / _` |
    | |  | | | | (_| | | | |   <\__ \ | || (_) | |    | |_) | | (_| | |_| | | | | | (_| |
    |_|  |_| |_|\__,_|_| |_|_|\_\___/ |_| \___/|_|    | .__/|_|\__,_|\__, |_|_| |_|\__, |
                                                      | |             __/ |         __/ |
                                                      |_|            |___/         |___/ 

");
        }

        static void title()
        {
            Console.Write(@" ___                  _            ___                                    ___                                      
|  _`\               ( )          (  _`\                                 (  _`\         _                          
| (_) )   _      ___ | |/')       | |_) )  _ _  _ _      __   _ __       | (_(_)   ___ (_)  ___   ___    _    _ __ 
| ,  /  /'_`\  /'___)| , <        | ,__/'/'_` )( '_`\  /'__`\( '__)      `\__ \  /'___)| |/',__)/',__) /'_`\ ( '__)
| |\ \ ( (_) )( (___ | |\`\  _    | |   ( (_| || (_) )(  ___/| |    _    ( )_) |( (___ | |\__, \\__, \( (_) )| |   
(_) (_)`\___/'`\____)(_) (_)( )   (_)   `\__,_)| ,__/'`\____)(_)   ( )   `\____)`\____)(_)(____/(____/`\___/'(_)   
                            |/                 | |                 |/                                              
                                               (_)                                                                 
===================================================================================================================");
            Console.WriteLine("\n\n\n");
        }
    }
}
