using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniZork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are standing in an open field west of a white house,");
            Console.WriteLine("With a boarded front door.");
            Console.WriteLine("There is a small mailbox here.");
            Console.Write("Go to the house, or open the mailbox? ");

            String action = Console.ReadLine();

            if (action.Equals("open the mailbox"))
            {
                Console.WriteLine("You open the mailbox.");
                Console.WriteLine("It's really dark in there.");
                Console.Write("Look inside or stick your hand in? ");
                action = Console.ReadLine();

                if (action.Equals("look inside"))
                {
                    Console.WriteLine("You peer inside the mailbox.");
                    Console.WriteLine("It's really very dark. So ... so very dark.");
                    Console.Write("Run away or keep looking? ");
                    action = Console.ReadLine();

                    if (action.Equals("keep looking"))
                    {
                        Console.WriteLine("Turns out, hanging out around dark places isn't a good idea.");
                        Console.WriteLine("You've been eaten by a grue.");
                    }
                    else if (action.Equals("run away"))
                    {
                        Console.WriteLine("You run away screaming across the fields - looking very foolish.");
                        Console.WriteLine("But you alive. Possibly a wise choice.");
                    }
                }
                else if (action.Equals("stick your hand in")) { }
            }
            else if (action.Equals("go to the house"))
            {
                Console.WriteLine("You walk up the steps to the door");
                Console.WriteLine("The door looks like it is unlocked");
                Console.WriteLine("open the door or walk around the back?");
                action = Console.ReadLine();

                
                if (action.Equals("open the door"))
                {
                    Console.WriteLine("You walk in side the house.");
                    Console.WriteLine("You see stairs leading up and a door going downstair.");
                    Console.Write("go upstair or go downstair? ");
                    action = Console.ReadLine();

                    if (action.Equals("go upstair"))
                    {
                        Console.WriteLine("You see a shadow at the end of the hallway.");
                        Console.WriteLine("It motions for you to come closer");
                        Console.Write("go to the shadow or run away? ");
                        action = Console.ReadLine();

                        if(action.Equals("go to the shadow"))
                        {
                            Console.WriteLine("The shadow eats you up.");
                            Console.ReadKey();
                        }
                        else if (action.Equals("run away"))
                        {
                            Console.WriteLine("As you run, the shadow runs after you.");
                            Console.WriteLine("You run out of the house and far away and not longer see the shadow or house.");
                            Console.ReadKey();
                        }

                    } else if (action.Equals("go downstair"))
                    {
                        
                    }

                }
                else if (action.Equals("walk around the back"))
                {
                    Console.WriteLine("After getting to the back of the house, you see a shed with the lights on.");
                    Console.WriteLine("The door looks unlocked.");
                    Console.Write("open the door or go somewhere else? ");
                    action = Console.ReadLine();

                    if (action.Equals("open the door"))
                    {
                        Console.WriteLine("A creature from another dimension grabs you then a flash of light shines the doorway.");
                        Console.WriteLine("You are now missing and nowhere to be found.");
                        Console.ReadKey();
                    }
                    else if (action.Equals("go somewhere else")) { }
                }
            }
        }
    }
}
