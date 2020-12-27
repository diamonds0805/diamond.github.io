using System;
using System.Collections.Generic;

namespace GameConsole
{
    class Program
    {
        /* Sanford, Diamond
         * 09/04/2020
         * ADP
         * Synopsis: This is the main entry point to the program
         */
        static void Main(string[] args)
        {
            User userOne = User.Login();
            //create loop for using to keep playing
            bool playGame = true;
            while (playGame)
            {
                
                //display welcome
                UI.Header("welcome");
                //display menu
                List<string> games = new List<string> {"[1] Hangman","[2] Tic Tac Toe","[3] Math Challenge","[4] Mastermind","[5] Hangman" };
                List<string> user = new List<string> { "[6] Profile" };
                List<string> add = new List<string> { "[7] Register User" };
                List<string> system = new List<string> { "[0] Exit" };
                Menu gameMenu = new Menu(games);
                Menu userMenu = new Menu(user);
                Menu sysMenu = new Menu(system);
                Menu addMenu = new Menu(add);
                gameMenu.DisplayMenu();
                userMenu.DisplayMenu();
                addMenu.DisplayMenu();
                sysMenu.DisplayMenu();
                
                //req sel from menu
                playGame = MenuSel(playGame);
                
            }
        }
        //create method to allow user to select from menu
        private static bool MenuSel(bool menuRun)
        {
            //req user sel from menu
            Console.WriteLine("\r\n");
            UI.Separater();
            Console.WriteLine("Please choose a menu option:");
            //capture response
            string selString = Console.ReadLine();
            //validate
            int selNum = Validation.ValidateInt(selString);
            selNum = Validation.ValidateRange(selNum, 0, 7);
            switch (selNum)
            {
                case 1:
                    //display HighLow
                    UI.Header("HighLow");
                    
                    break;
                case 2:
                    //display TicTacToe
                    UI.Header("TicTacToe");
                    break;
                case 3:
                    //display MathChallenge
                    UI.Header("MathChallenge");
                    break;
                case 4:
                    //display Mastermind
                    UI.Header("Mastermind");
                    break;
                case 5:
                    //display Hangman
                    UI.Header("Hangman");
                    break;
                case 6:
                    //display user profile
                    User user = User.Login();
                    user.DisplayUserProfile();
                    break;
                case 7:
                    //add user
                    User.AddUser();
                    break;
                case 0:
                    UI.Footer("Thanks for playing!");
                    menuRun = false;
                    break;

            }
            return menuRun;
        }
    }
}
