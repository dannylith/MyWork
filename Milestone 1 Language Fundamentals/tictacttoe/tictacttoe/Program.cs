using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictacttoe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] board = new int[9];
            int intUserRow, intComputerRow;
            bool boolContinue = true, boolComputerWins = false, boolUserWins = false;
           

            Random r = new Random();

            //for (int i = 0; i<25; i++)
            //{
            //    Console.WriteLine(r.Next(1, 3));
            //}

            while (boolContinue)
            {
                Console.WriteLine(boardName(board[0], "0") + " | " + boardName(board[1], "1") + " | " + boardName(board[2], "2"));
                Console.WriteLine(boardName(board[3], "3") + " | " + boardName(board[4], "4") + " | " + boardName(board[5], "5"));
                Console.WriteLine(boardName(board[6], "6") + " | " + boardName(board[7], "7") + " | " + boardName(board[8], "8"));

                while (true)
                {
                    //ask for user input
                    Console.Write("Which space: ");
                    intUserRow = int.Parse(Console.ReadLine());





                    //check to make sure the computer hasn't picked that spot or the user also hasn't pick that spot before
                    if (board[intUserRow] != 2 && board[intUserRow] != 1)
                    {
                        board[intUserRow] = 1;
                        if((board[0] == 1 && board[1]== 1 && board[2] == 1) || (board[3] == 1 && board[4] == 1 && board[5] == 1) || (board[6] == 1 && board[7] == 1 && board[8] == 1))
                        {
                            boolContinue = false;
                            boolUserWins = true;
                        } else if ((board[0] == 1 && board[3] == 1 && board[6] == 1) || (board[1] == 1 && board[4] == 1 && board[7] == 1) || (board[2] == 1 && board[5] == 1 && board[8] == 1))
                        {
                            boolContinue = false;
                            boolUserWins = true;
                        }
                        else if ((board[0] == 1 && board[4] == 1 && board[8] == 1) || (board[2] == 1 && board[4] == 1 && board[6] == 1))
                        {
                            boolContinue = false;
                            boolUserWins = true;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("space already taken");
                    }

                }


                //check see if the board is filled, if it is, end the game
                if(board[0] != 0 && board[1] != 0 && board[2] != 0 && board[3] != 0 && board[4] != 0 && board[5] != 0 && board[6] != 0 && board[7] != 0 && board[8] != 0)
                {
                    boolContinue = false;
                }

                if (boolContinue == false)
                {
                    break;
                }



                while (true)
                {
                    //computer random chooses 1-3
                    intComputerRow = r.Next(0, 9);


                    //check to make sure the computer hasn't picked that spot or the user also hasn't pick that spot before
                    if (board[intComputerRow] != 1 && board[intComputerRow] != 2)
                    {
                        //assign o to where computer wants it
                        board[intComputerRow] = 2;
                        if ((board[0] == 2 && board[1] == 2 && board[2] == 2) || (board[3] == 2 && board[4] == 2 && board[5] == 2) || (board[6] == 2 && board[7] == 2 && board[8] == 2))
                        {
                            boolContinue = false;
                            boolComputerWins = true;
                        }
                        else if ((board[0] == 2 && board[3] == 2 && board[6] == 2) || (board[1] == 2 && board[4] == 2 && board[7] == 2) || (board[2] == 2 && board[5] == 2 && board[8] == 2))
                        {
                            boolContinue = false;
                            boolComputerWins = true;
                        }
                        else if ((board[0] == 2 && board[4] == 2 && board[8] == 2) || (board[2] == 2 && board[4] == 2 && board[6] == 2))
                        {
                            boolContinue = false;
                            boolComputerWins = true;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("space already taken");
                    }
                }

                //check see if the board is filled, if it is, end the game
                if (board[0] != 0 && board[1] != 0 && board[2] != 0 && board[3] != 0 && board[4] != 0 && board[5] != 0 && board[6] != 0 && board[7] != 0 && board[8] != 0)
                {
                    boolContinue = false;
                }

            }



            Console.WriteLine("Array is fully filled;");
            Console.WriteLine(boardName(board[0], "0") + " | " + boardName(board[1], "1") + " | " + boardName(board[2], "2"));
            Console.WriteLine(boardName(board[3], "3") + " | " + boardName(board[4], "4") + " | " + boardName(board[5], "5"));
            Console.WriteLine(boardName(board[6], "6") + " | " + boardName(board[7], "7") + " | " + boardName(board[8], "8"));

            if (boolUserWins)
            {
                Console.WriteLine("You win the Game!!");
            }
            else if(boolComputerWins)
            {
                Console.WriteLine("The computer wins. You Lose!!");
            }
            else
            {
                Console.WriteLine("It's a Draw.");
            }



            Console.ReadKey();

        }

        static string boardName(int x, string position)
        {//change the board to x or o
            if(x == 1)
            {
                return "x";
            }
            if( x == 2)
            {
                return "o";
            }
            return position;
        }

    }
}
