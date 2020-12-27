﻿using System;
using System.Collections.Generic;

namespace ZooKeeperApp
{
    public class Menu
    {
        // This class contains the functions to display the menu
         

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
                Console.WriteLine($"[{i+1}] {_menuOptions[i]}");

            }
            
        }
       
    }
}
