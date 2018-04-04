using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Distribution
{
    class Program
    {
        
        static void Roll(int[] _dice)
        {
            Random rand = new Random();
            int total = 0;

            for(int i = 0; i < _dice[0]; i++)
            {
                total += rand.Next( 1, _dice[1] + 1);
            }

            Console.WriteLine("You rolled: {0}\n", total);
            
        }

        static void Dist(int[] _dice)
        {
            Random rand = new Random();
            int max_number = (_dice[0] * _dice[1]) + 1;
            int[] dist = new int[max_number];
            int roll_total = 0;
            int sample_size = 0;

            if(_dice.Length == 2)
            {
                Console.Write("Enter number of rolls: ");
                sample_size = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                sample_size = _dice[2];
            }

            for (int i = 0; i < sample_size; i++)
            {
                for(int j = 0; j < _dice[0]; j++)
                {
                    roll_total += rand.Next(1, _dice[1] + 1);
                }

                dist[roll_total]++;
                roll_total = 0;
            }

            Console.WriteLine("\n\t{0,4}{1,10}{2,10}", "Number", "Percent", "Count");
            for (int i = 0; i < max_number; i++)
            {
                if (dist[i] != 0)
                {
                    double percent = (dist[i] / (double)sample_size);
                    //Console.Write("\t{0}:\t{1}%\t\t{2}\t\t|", i, percent * 100, dist[i]);
                    Console.Write("\t{0,4}:{1,10:0.0%}{2,10}{3,10}", i, percent, dist[i], "|");
                    for (int j = 1; j <= 50; j++)
                    {
                        if (j <= percent*50)
                            Console.Write("-");
                        else
                            Console.Write(" ");
                    }
                    Console.Write("\n");
                }
            }

        }

        static void Main(string[] args)
        {
            bool quit = false;      //app quit condition
            string option = null;   //user input option
            int dice_mode = 0;
            string[] dice;

            //Define the help menu
            string help = 
            "---Help---\n " +
            "\n" +
            "Welcome to the Dice Distribution Program.\n" +
            "This program was created to solve a debate between my brother and I over the distribution of dice rolls.\n" +
            "Enjoy\n" +
            "\n" +
            "Upon startup the user needs to select a dice rolling mode, normal or distribution.\n" +
            "In normal rolling mode allows the user to roll any dice by first giving the number of dice to roll followed by 'd' and the number of side of each dice.\n" +
            "Example: 1d6 rolls one 6-sided dice\n" +
            "\n" +
            "Options:\n" +
            "\tr, roll -- Selects the normal dice rolling mode, for those who just want to roll dice\n" + 
            "\td, dist -- Selects the distribution dice rolling mode\n" +
            "\th, help -- Displays this help menu\n" +
            "\tc, clear -- Clears the console of text\n" +
            "\tq, quit -- Exits the program\n" +
            "\tb, back -- Returns to the start menu. This option is only valid once a rolling mode has been selected.\n" +
            "\n";


            Console.WriteLine("---Dice---");
            while (!quit)
            {
                try
                {
                    switch(dice_mode)
                    {

                        case 0:
                            {
                                Console.Write("> ");
                                option = Console.ReadLine();

                                switch (option)
                                {
                                    case "r":
                                    case "roll":
                                        {
                                            dice_mode = 1;
                                            Console.WriteLine("\n---Rolling Mode Enabled---");
                                            break;
                                        }

                                    case "d":
                                    case "dist":
                                        {
                                            dice_mode = 2;
                                            Console.WriteLine("\n---Distribution Mode Enabled---");
                                            break;
                                        }

                                    case "h":
                                    case "help":
                                        {
                                            Console.WriteLine(help);
                                            break;
                                        }

                                    case "c":
                                    case "clear":
                                        {
                                            Console.Clear();
                                            
                                            break;
                                        }

                                    case "quit":
                                    case "q":
                                        {
                                            quit = true;
                                            break;
                                        }

                                    case "b":
                                    case "": break;

                                    default: Console.WriteLine("Invalid Entry..."); break;
                                }
                                break;
                            }

                        case 1:     //Rolling mode
                            {
                                //
                                //
                                //
                                //ADD SUPPORT FOR DIFFERENT DICE TO BE COMBINED IN ONE ROLL EX "1d6+1d10"
                                //
                                //
                                //

                                Console.Write("> ");
                                option = Console.ReadLine();

                                switch (option)
                                {
                                    case "c"
                                    case "clear":
                                        {
                                            Console.Clear();
                                            
                                            break;
                                        }

                                    case "b":
                                    case "back":
                                        {
                                            dice_mode = 0;
                                            Console.WriteLine("---Dice---");
                                            break;
                                        }

                                    case "": break;

                                    default:
                                        {

                                            dice = option.Split('d');
                                            int[] t_dice = { Convert.ToInt32(dice[0]), Convert.ToInt32(dice[1]) };

                                            Roll(t_dice);

                                            break;
                                        }
                                }
                                break;
                            }

                        case 2:     //Distribution mode
                            {
                                //
                                //
                                //
                                //ADD SUPPORT FOR DIFFERENT DICE TO BE COMBINED IN ONE ROLL EX "1d6+1d10"
                                //
                                //
                                //

                                Console.Write("> ");
                                option = Console.ReadLine();

                                switch (option)
                                {
                                    case "c":
                                    case "clear":
                                        {
                                            Console.Clear();

                                            break;
                                        }

                                    case "b":
                                    case "back":
                                        {
                                            dice_mode = 0;
                                            Console.WriteLine("---Dice---");
                                            break;
                                        }

                                    case "": break;

                                    default:
                                        {
                                            int[] t_dice = new int[2];

                                            dice = option.Split(new char[2] { 'd', ' ' });
                                            if (dice.Length == 2)
                                                t_dice = new int[2] { Convert.ToInt32(dice[0]), Convert.ToInt32(dice[1]) };
                                            else
                                                t_dice = new int[3] { Convert.ToInt32(dice[0]), Convert.ToInt32(dice[1]), Convert.ToInt32(dice[2]) };

                                            Dist(t_dice);

                                            break;
                                        }
                                }
                                break;
                            }

                    }
                    
                }
                catch (Exception err)
                {
                    Console.WriteLine("\n****Error Occured****\n{0}\n\n*********************\n", err);
                }
            }


        }
    }
}
