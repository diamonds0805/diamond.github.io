using System;
using System.Collections.Generic;

namespace EmployeeTracker
{
    public class Validation
    {
        /* Sanford, Diamond
         * 09/27/2020
         * ADP
         * Synopsis: This class files contains static methods for validation
         */

        //create method to validate string not empty
        public static string ValidateString(string userInput)
        {
            while (string.IsNullOrWhiteSpace(userInput))
            {
                //display error
                Console.WriteLine("Please do not leave blank!");
                //ask again
                Console.WriteLine("Re-enter response and press ENTER");
                //recatch response
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        //create method to validate input is int
        public static int ValidateInt(string userInput)
        {
            int validInt;
            while(!(int.TryParse(userInput,out validInt)))
            {
                //display error
                Console.WriteLine("Please only enter a number");
                //ask again
                Console.WriteLine("Re-enter response and press ENTER");
                //recatch response
                userInput = Console.ReadLine();
            }
            return validInt;
        }
        //create method to validate range
        public static int ValidateRange(int userNum,int startP, int endP)
        {
            while(userNum < startP || userNum > endP)
            {
                //display error
                Console.WriteLine($"Please only enter a number between {startP} and {endP}");
                //ask again
                Console.WriteLine("Re-enter response and press ENTER");
                //recatch response
                string userInput = Console.ReadLine();
                userNum = ValidateInt(userInput);
            }
            return userNum;
        }
        public static string ValidateInList(List<string> list,string input)
        {
            while (!(list.Contains(input)))
            {
                Console.WriteLine("Option not valid!");
                Console.Write("Re-enter response: ");
                input = Console.ReadLine();

            }
            return input;
        }
        public static decimal ValidateDec(string userInput)
        {
            decimal validDec;
            while (!(decimal.TryParse(userInput, out validDec)))
            {
                //display error
                Console.WriteLine("Please only enter a number");
                //ask again
                Console.WriteLine("Re-enter response and press ENTER");
                //recatch response
                userInput = Console.ReadLine();
            }
            return validDec;
        }

    }
}
