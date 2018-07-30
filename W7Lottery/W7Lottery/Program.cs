using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W7Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            //Number of Quickpicks
            Console.WriteLine("Enter the number of Quickpick numbers to generate:");
            int j = Convert.ToInt32(Console.ReadLine());

            //Counter
            int i;

            //Random number generators
            Random rnum = new Random();

            //List of Arrays(Lottery Numbers)
            List<int[]> picklist = new List<int[]>();
            List<int[]> winner = new List<int[]>();
            int bonus;
            Console.WriteLine("\nYour QuickPick numbers:");
            //Fill the List
            for (i = 0; i < j; i++)
            {
                int[] quickPicks = new int[6];

                for (int k = 0; k < 6; k++)
                {
                    int randnum = rnum.Next(1, 49);

                    while (quickPicks.Contains(randnum))
                    {
                        randnum = rnum.Next(1, 49);
                    }
                    quickPicks[k] = randnum;
                }
                Array.Sort(quickPicks);
                picklist.Add(quickPicks);
            }

            foreach (var array in picklist)
            {
                Console.WriteLine(string.Join(" ", array));
            }

            // Winning number
            Console.WriteLine("Do you want to generate winning number? (y/n)");
            string decide = Console.ReadLine();


            if (decide != "y")
            {
                Console.WriteLine("You'll never know if you won now.");
            }
            else
            {
                Console.WriteLine("\nThe Winning Number:");
                //Fill the List
                for (i = 0; i < 1; i++)
                {
                    int[] winNumber = new int[6];

                    for (int k = 0; k < 6; k++)
                    {
                        int randnum = rnum.Next(1, 49);

                        while (winNumber.Contains(randnum))
                        {
                            randnum = rnum.Next(1, 49);
                        }
                        winNumber[k] = randnum;
                    }
                    Array.Sort(winNumber);
                    winner.Add(winNumber);
                }

                foreach (var array in winner)
                {
                    Console.WriteLine(string.Join(" ", array));
                }

                int b = rnum.Next(1, 49);
                while (winner[0].Contains(b))
                {
                    b = rnum.Next(1, 49);
                }
                bonus = b;

                Console.WriteLine("Bonus Number: " + "\n" + bonus);

                //Compare Quickpicks and winning number
                Console.WriteLine("\nYour Lottery Results: ");
                for (int h = 0; h < j; h++)
                {

                    int count = picklist[h].Intersect(winner[0]).Count();

                    if (picklist[h].Contains(bonus))
                    {
                        Console.WriteLine("Matched Numbers: " + count + " + Bonus");
                    }
                    else
                    {
                        Console.WriteLine("Matched Numbers: " + count);
                    }

                    switch (count)
                    {
                        case 0:
                            Console.WriteLine("Not a Winner. Please try again!");
                            break;
                        case 1:
                            Console.WriteLine("Not a Winner. Please try again!");
                            break;
                        case 2:
                            if (count == 2 && picklist[h].Contains(bonus))
                            {
                                Console.WriteLine("Winner! $5 Prize");
                            }
                            else
                            {
                                Console.WriteLine("Not a Winner. Please try again!");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Winner! $10 Prize");
                            break;
                        case 4:
                            Console.WriteLine("Winner! Your prize is " + (30 * 0.009) + " Million");
                            break;
                        case 5:
                            if (count == 5 && picklist[h].Contains(bonus))
                            {
                                Console.WriteLine("Winner! Your prize is " + (30 * 0.0575) + " Million");
                            }
                            else
                            {
                                Console.WriteLine("Winner! Your prize is " + (30 * 0.0475) + " Million");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Congratulations! You won the jack pot! Your prize is " + (30 * 0.805) + " Million");
                            break;
                    }

                }
                Console.ReadLine();



            }
        }
    }
}
