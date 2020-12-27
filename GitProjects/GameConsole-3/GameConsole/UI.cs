using System;
namespace GameConsole
{
    public class UI
    {
        /* Sanford, Diamond
         * 09/04/2020
         * ADP
         * Synopsis: This class contains the design and usability functions for the program
         */

        //Create static method for header
        public static void Header(string title)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(title.ToUpper());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------------------------------------------");
        }
        //Create static method for footer
        public static void Footer(string footer)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(footer);
        }
        //Create static method separater
        public static void Separater()
        {
            Console.WriteLine("---------------");
        }
    }
        
}
