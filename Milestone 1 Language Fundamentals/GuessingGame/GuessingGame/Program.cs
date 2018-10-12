using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess, intMode;
            int intAmountGuessedCounter = 0;
            string playerInput, strPlayerName, strGameMode;

            Console.WriteLine("1 - Easy mode");
            Console.WriteLine("2 - Normal mode");
            Console.WriteLine("3 - Hard mode");
            Console.Write("Which mode do you want [1, 2, or 3]: ");
            strGameMode = Console.ReadLine();
            if (strGameMode == "3")
            {
                intMode = 50;
            }
            else if (strGameMode == "1")
            {
                intMode = 5;
            }
            else
            {
                intMode = 20;
            }

            Random r = new Random();
            theAnswer = r.Next(1, intMode + 1);

            Console.WriteLine("Please Enter in your name: ");
            strPlayerName = Console.ReadLine();

            do
            {

                // get player input
                Console.Write($"{strPlayerName}, Enter your guess (1-{intMode}) or Press Q to end the game: ");
                playerInput = Console.ReadLine();

                if (playerInput == "Q" || playerInput == "q")
                {
                    break;
                }

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    if (playerGuess > 0 && playerGuess <= intMode)
                    {
                        intAmountGuessedCounter++;
                        if (playerGuess == theAnswer)
                        {
                            if (intAmountGuessedCounter == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{strPlayerName}, {theAnswer} was the number.  That's AMAZING. You win a MILLION DOLLARS!!!!!");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{strPlayerName}, {theAnswer} was the number.  You Win!");
                            }
                            Console.WriteLine($"{strPlayerName}'s guess(es) attempted: {intAmountGuessedCounter}");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            if (playerGuess > theAnswer)
                            {
                                Console.WriteLine($"{strPlayerName}, Your guess was too High!");
                            }
                            else
                            {
                                Console.WriteLine($"{strPlayerName}, Your guess was too low!");
                            }
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{strPlayerName}, Your number is not between 1-{intMode}, try again.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{strPlayerName}, That wasn't a number!");
                    Console.ResetColor();
                }

            } while (true);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
