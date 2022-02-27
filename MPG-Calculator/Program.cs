using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPG_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double miles, kilometers, gallons, litres, mpg;
            string option, unit;
            string keepgoing = "y";

            while (keepgoing == "y")
            {
                //I would have declared these here and set to 0 at the same time, but
                // it was mentioned for the exam to delcare all variables together at the top
                // I did it the long way just in case.
                //they are set to 0 inside the loop becuase having 0 values is a critical part 
                // of the logic later in the program.
                miles = 0;
                kilometers = 0;
                gallons = 0;
                litres = 0;

                Console.WriteLine("Hello! Please select your unit of measurement:");
                Console.WriteLine("1. Miles");
                Console.WriteLine("2. Kilometers");
                option = CheckOption();
                Console.Clear();

                if (option == "2")
                {
                    unit = "kilometers";
                    kilometers = InputDistance(unit);
                }
                else // option 1 (miles), miles is default according to brief
                {
                    unit = "miles";
                    miles = InputDistance(unit);
                }

                Console.Clear();
                Console.WriteLine("Thank you! Please select your unit of measurement:");
                Console.WriteLine("1. Gallons");
                Console.WriteLine("2. Litres");
                option = CheckOption();
                Console.Clear();

                if (option == "2")
                {
                    unit = "litres";
                    litres = InputPetrolUsed(unit);
                }
                else // option 1 (gallons), gallons is default according to brief
                {
                    unit = "gallons";
                    gallons = InputPetrolUsed(unit);
                }

                //conversions if necessary
                if (kilometers > 0)
                {
                    miles = kilometers * 0.621;
                }

                if (litres > 0)
                {
                    gallons = litres * 0.264;
                }

                mpg = CalculateMPG(miles, gallons);
                Console.Clear();

                //conversions above and if statements below are why setting the variables to 0 at the beginning is important,
                //if the user has selected a differnt option the program will know by the values being greater than 0
                //accroding to the error checking in method CheckDouble, the if selected the values must be greater than 0.
                if (kilometers > 0 && litres > 0)
                {
                    Console.WriteLine($"You drove {kilometers} kilometers, using {litres} litres of petrol.");
                    Console.WriteLine($"The kilometers per litre is {Math.Round((kilometers / litres), 3)}.");
                }
                else if (kilometers > 0)
                {
                    Console.WriteLine($"You drove {kilometers} kilometers, using {gallons} gallons of petrol.");
                    Console.WriteLine($"The kilometers per gallon is {Math.Round((kilometers / gallons), 3)}.");
                }
                else if (litres > 0)
                {
                    Console.WriteLine($"You drove {miles} miles, using {litres} litres of petrol.");
                    Console.WriteLine($"The miles per litre is {Math.Round((miles / litres), 3)}.");
                }
                else
                {
                    Console.WriteLine($"You drove {miles} miles, using {gallons} gallons of petrol.");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"The resulting miles per gallon is {mpg}.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
                do
                {
                    if (keepgoing != "y" && keepgoing != "n")
                    {
                        Console.WriteLine("That is not a valid input.");
                    }
                    Console.WriteLine("Would you like to start over? y/n");
                    keepgoing = Console.ReadLine().ToLower();
                }
                while (keepgoing != "n" && keepgoing != "y");
                Console.Clear();
            }
            Console.WriteLine("Thank you for using the program. Goodbye!");
        }

        private static double CalculateMPG(double miles, double gallons)
        {
            double mpg;
            mpg = Math.Round((miles / gallons), 3);
            return mpg;
        }

        private static double InputPetrolUsed(string unit)
        {
            double petrolused;
            string message = $"Please enter the {unit} of petrol used";

            Console.WriteLine(message);
            petrolused = CheckDouble(message);
            return petrolused;
        }

        private static double InputDistance(string unit)
        {
            double distance;
            string message = $"Please enter the {unit} driven";

            Console.WriteLine(message);
            distance = CheckDouble(message);

            return distance;
        }

        private static double CheckDouble(string message)
        {
            bool success = false;
            double num;

            success = Double.TryParse(Console.ReadLine(), out num);
            while (!success || num <= 0)
            {
                Console.WriteLine("That is not a valid input. You must enter a number greater than 0.");
                Console.WriteLine(message);
                success = Double.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }
        private static string CheckOption()
        {
            string option;

            option = Console.ReadLine();
            while (option != "1" && option != "2")
            {
                Console.WriteLine("That is not a valid input.");
                Console.WriteLine("Please enter 1 or 2.");
                option = Console.ReadLine();
            }
            return option;
        }
    }
}
