using System;
namespace EmployeeTracker
{
    public class UI
    {
        /* Sanford, Diamond
         * 09/27/2020
         * ADP
         * Synopsis: This class contains the design and usability functions for the program
         */

        //Create static method for header
        public static void Header(string title)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{title.ToUpper(),20}          ");
            Console.ResetColor();

        }
        //Create static method for footer
        public static void Footer(string footer)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{footer,20}            ");
            Console.ResetColor();

        }
        //Create static method separater
        public static void Separater()
        {
            Console.WriteLine("---------------");
        }

        //create static method for displaying employees
        public static void EmpUI()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("================");
            Console.ResetColor();
        }
    }
        
}
