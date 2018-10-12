using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaNight
{
    class Program
    {
        static void Main(string[] args)
        {

            string strFirstQInput, strSecondQInput, strThirdQInput;
            int intCorrectAnswer, intFirstQInput, intSecondQInput, intThirdQInput;

            intCorrectAnswer = 0;


            Console.Write(@"It's TRIVIA NIGHT! Are you ready?!

FIRST QUESTION!
What is the Lowest Level Programming Language?
1) Source Code             2) Assembly Language
3) C#                      4) Machine Code

Your Answer? ");

            strFirstQInput = Console.ReadLine();
            intFirstQInput = int.Parse(strFirstQInput);
            if (intFirstQInput == 4)
            {
                intCorrectAnswer += 1;
            }

            Console.Write(@"
SECOND QUESTION!
Website Security CAPTCHA Forms Are Descended From the Work of?
1) Grace Hopper            2) Alan Turing<
3) Charles Babbage         4) Larry Page<

Your Answer? ");

            strSecondQInput = Console.ReadLine();
            intSecondQInput = int.Parse(strSecondQInput);
            if (intSecondQInput == 2)
            {
                intCorrectAnswer += 1;
            }

            Console.Write(@"
LAST QUESTION!
Which of These Sci-Fi Ships Was Once Slated for a Full-Size Replica in Las Vegas?
1) Serenity                2) The Battlestar Galactica
3) The USS Enterprise      4) The Millennium Falcon

Your Answer? ");

            strThirdQInput = Console.ReadLine();
            intThirdQInput = int.Parse(strThirdQInput);
            if (intThirdQInput == 3)
            {
                intCorrectAnswer += 1;
            }

            Console.WriteLine("You got {0} correct.", intCorrectAnswer);

            Console.ReadKey();
        }
    }
}
