using System;
using System.Collections.Generic;

namespace ZooKeeperApp
{
    public class Validation
    {
        //This class files contains static methods for validation
        

        //method to validate string not empty
        public static string ValidateString(string userInput)
        {
            while (string.IsNullOrWhiteSpace(userInput))
            {
                //display error
                UI.DisplayError("Please do not leave blank. Re-enter response and press ENTER");
                //recatch response
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        //method to validate input is int
        public static int ValidateInt(string userInput)
        {
            int validInt;
            while(!(int.TryParse(userInput,out validInt)))
            {
                //display error
                UI.DisplayError("Please only enter a number. Re-enter response and press ENTER");
                //recatch response
                userInput = Console.ReadLine();
            }
            return validInt;
        }
        //method to validate range
        public static int ValidateRange(int userNum,int startP, int endP)
        {
            while(userNum < startP || userNum > endP)
            {
                //display error
                UI.DisplayError($"Please only enter a number between {startP} and {endP}. Re-enter response and press ENTER");
                //recatch response
                string userInput = Console.ReadLine();
                userNum = ValidateInt(userInput);
            }
            return userNum;
        }

        //method to validate input in dictionary
        public static string ValidateInDict(Dictionary<string, string> behaviors, string input)
        {
            while (!(behaviors.ContainsKey(input)))
            {
                //display error
                UI.DisplayError("Option not valid! Re-enter response and press ENTER");
                input = Console.ReadLine();
                
            }
            return input;
        }

        //method to validate yes or no
        public static string ValidateYOrN(string input)
        {
            while(input.ToLower() != "y" && input.ToLower() != "n")
            {
                UI.DisplayError("Please only enter Y or N: ");
                input = Console.ReadLine();
                input = ValidateString(input);

            }
            return input;
        }

    }
}
