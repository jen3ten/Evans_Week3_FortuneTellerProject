using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_ProjectFortuneTeller_01202016
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fortune Teller Console Application
            //Tell the user's fortune based on data received from the user

            Console.WriteLine("F O R T U N E   T E L L E R");
            Console.WriteLine();
            Console.WriteLine("Hello!  I am excited to read your fortune!\nBut first I have ask you a few questions.");
            Console.WriteLine();

            //Input includes user's first name, last name, age, birth month, favorite color, number of siblings
            //Fortune (Output) includes retirement age, living location, car, and money in bank

            Console.Write("What is your first name? ");
            string firstName = Console.ReadLine();
            Console.Write("What is your last name? ");
            string lastName = Console.ReadLine();
            Console.Write("What is your age? ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("What is your birth month? (Please enter by full name or abbreviation): ");
            string birthMonthByString = Console.ReadLine();

            //Embed ROYGBIV color question in a loop so that 'Help' can be pressed
            string favColor;
            do
            {
                Console.Write("What is your favorite ROYGBIV color? (Enter \"Help\" if you need a list of colors)");
                favColor = Console.ReadLine();
                if (favColor.ToUpper() == "HELP")
                {
                    Console.WriteLine("\tEnter \"R\" for the color Red");
                    Console.WriteLine("\tEnter \"O\" for the color Orange");
                    Console.WriteLine("\tEnter \"Y\" for the color Yellow");
                    Console.WriteLine("\tEnter \"G\" for the color Green");
                    Console.WriteLine("\tEnter \"B\" for the color Blue");
                    Console.WriteLine("\tEnter \"I\" for the color Indigo (Deep Blue)");
                    Console.WriteLine("\tEnter \"V\" for the color Violet (Purple)");
                    Console.WriteLine();
                }
            } while (favColor.ToUpper() == "HELP");

            //Allow user to enter letter or entire name of color, but...
            //Save only the first character of the color, in upper case
            favColor = favColor.ToUpper();
            char favColorChar = favColor[0];
            Console.Write("How many siblings do you have? ");
            int numSiblings = int.Parse(Console.ReadLine());

            //Determine user's fortune based on user input
            //If the user's age is odd, they will retire in 17 years
            //If the user's age is even they will retire in 8 years
            int retireYrs;
            if (age % 2 == 0)       //If the user's age is even....
            {
                retireYrs = 8;      //they will retire in 8 years
            }
            else                    //Otherwise, if the user's age is odd..
            {
                retireYrs = 17;     //they will retire in 17 years
            }

            //If the user's number of siblings is 
            //0, they will live in Paris, France
            //1, they will live in Omaha, Nebraska
            //2, they will live in Detroit, Michigan
            //3, they will live in Denver, Colorado
            //more than 3, they will live on a remote island in the Caribbean
            string vacHomeLoc;
            switch(numSiblings)
            {
                case 0: vacHomeLoc = "in Paris, France"; break;
                case 1: vacHomeLoc = "in Omaha, Nebraska"; break;
                case 2: vacHomeLoc = "in Detroit, Michigan"; break;
                case 3: vacHomeLoc = "in Denver, Colorado"; break;
                default: vacHomeLoc = "on a remote island in the Caribbean"; break;
            }

            //If the user's favorite color (ROYGBIV) is
            //R, they will have a mini van
            //O, they will have a Corvette
            //Y, they will have a hover board
            //G, they will have a Tesla
            //B, they will have a bicycle
            //I, they will have a moped
            //V, they will have a Mustang
            //default value is chauffeur
            string vehicle;
            switch(favColorChar)
            {
                case 'R':   vehicle = "mini van"; break;
                case 'O':   vehicle = "Corvette"; break;
                case 'Y':   vehicle = "hover board"; break;
                case 'G':   vehicle = "Tesla"; break;
                case 'B':   vehicle = "bicycle"; break;
                case 'I':   vehicle = "moped"; break;
                case 'V':   vehicle = "Mustang"; break;
                default:    vehicle = "chauffeur"; break;
            }

            //Look at first, second, and third letters of the user's birth month.  
            //Determine if it can be found in either the user's first or last name
            //If the first letter, then $1000 in the bank
            //If the second letter, then $525,000 in the bank
            //If the third letter, then $237.33 in the bank
            //If no letters are found, then $13,725 in the bank
            //Set value to first instance of match, starting with first letter of month

            double bankMoney = 13725;       //Set default value for retirement money
            bool foundLetter = false;       //Set default value for letter "not found"
            string fullName = firstName + lastName;     //Search in string made of first AND last name

            //Index through the first three letters of the birth month
            //Stop searching if the letter is found in the first or last name
            for (int letter = 0; (letter < 3 && !foundLetter); letter ++)
            {
                string birthMonthLetter = birthMonthByString.Substring(letter, 1);
                //Check each character of first and last name for a match with birth month letter
                for (int i = 0; i < fullName.Length; i ++)
                {
                    string letterAsString = fullName.Substring(i, 1);
                    if (letterAsString.Equals(birthMonthLetter, StringComparison.CurrentCultureIgnoreCase))
                    {
                        foundLetter = true;         //Set flag to "true", indicating that a match was found
                        switch(letter)
                        {
                            case 0: bankMoney = 1000; break;
                            case 1: bankMoney = 525000; break;
                            case 2: bankMoney = 237.33; break;
                        }
                        break;          //Break out of the loop if a match is found
                    }
                }
            }

            //Computer thinks about it (use a bell sound), and outputs fortune to the user
            Console.WriteLine();
            Console.WriteLine("\aI'm determining your fortune...");
            Console.WriteLine("\aHere it is...");
            Console.WriteLine();
            Console.WriteLine("{0} {1}, you will retire in {2} years with {3:C} in the bank,\na vacation home {4}, and a {5}.", firstName, lastName, retireYrs, bankMoney, vacHomeLoc, vehicle);
            Console.WriteLine();

            //Allow the user to try again or exit
            Console.Write("Would you like to try again? ");
            string runAgain = Console.ReadLine();
            runAgain = runAgain.ToUpper();          //Set response to upper case
            char runAgainFirstChar = runAgain[0];   //Look at only first character of response
            if (runAgainFirstChar == 'Y')
            {
                Main(args);
            }
        }
    }
}
