using System;
namespace ZooKeeperApp
{
    public class UI
    {
       //This class contains the design and usability functions for the program
        

        //method for header
        public static void Header(string title)
        {
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{title.ToUpper(),20}          ");
            Console.WriteLine("===============================");
            Console.ResetColor();

        }
        //method for footer
        public static void Footer(string footer)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{footer,20}            ");
            Console.ResetColor();

        }
        //method for separater
        public static void Separater()
        {
            Console.WriteLine("---------------");
        }

        //method for displaying valid option
        public static void DisplayValid(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }//end display valid method


        //method to display error message
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
    }
        
}
