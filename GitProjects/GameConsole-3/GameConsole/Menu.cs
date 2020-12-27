using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Menu
    {
        /* Sanford, Diamond
         * 09/04/2020
         * ADP
         * Synopsis: This class contains the functions to display the menu
         */

        //create fields
       
        private List<string> _menuOptions = new List<string>();

        //create constructor
        public Menu(List<string> menuOptions)
        {
          
            _menuOptions = menuOptions;
        }
        public void DisplayMenu()
        {
           for(int i = 0; i <  _menuOptions.Count; i++)
            {
                Console.WriteLine(_menuOptions[i]);
            }
            
        }
       
    }
}
