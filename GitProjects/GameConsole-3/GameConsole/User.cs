using System;
using System.Collections.Generic;
using System.IO;

namespace GameConsole
{
    public class User
    {
        /* Sanford, Diamond
         * 09/09/2020
         * APD
         * Synopsis: This class file contains data for the users of the program
         */

        //create fields to store user data
        private string _username;
        private int _age;
        private string _theme;

        private static List<string> _userInfo = new List<string>();

        public User(string username, int age, string theme)
        {
            _username = username;
            _age = age;
            _theme = theme;
            //call method to change console theme
            ChangeTheme(_theme);
        }

        private void ChangeTheme(string theme)
        {
            //create conditional to change theme
            if(theme.ToLower() == "light")
            {
                //change console color
                Console.BackgroundColor = ConsoleColor.Gray;
            } else
            {
                //change console color
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void DisplayUserProfile()
        {
            //display user profile
            UI.Header("user profile");
            Console.WriteLine($"[Username] {_username.ToLower()}");
            Console.WriteLine($"[Age] {_age}");
            Console.WriteLine($"[Theme] {_theme.ToLower()}");
            UI.Separater();
            Console.WriteLine("Press any key to return to the menu:");
            Console.ReadLine();
            //Console.Clear();

        }
        public static User Login()
        {
            
            string path = "../../../Users.txt";
            UI.Header("Please Login");
            
            Console.Write("Username: ");
            string username = Console.ReadLine();
            
            Console.Write("Password: ");
            string password = Console.ReadLine();
            
            
            //User user = new User()
            using (StreamReader str = new StreamReader(path))
            {
                string line;
                while((line = str.ReadLine()) != null)
                {
                    
                    string[] lineArr = line.Split('|');
                    
                    if(lineArr[0] == username && lineArr[1] == password)
                    {
                        _userInfo.AddRange(lineArr);
                    } 
                }
            }
            //instantiate new user object
            User user = new User(_userInfo[0], int.Parse(_userInfo[2]), _userInfo[3]);
            return user;

        }

        public static void AddUser()
        {
            UI.Header("register new user");
            
            using (StreamWriter str = File.AppendText("../../../Users.txt"))
            {
                Console.Write("[Username]");
                string username = Console.ReadLine();
                Validation.ValidateString(username);
                Console.Write("[Password]");
                string password = Console.ReadLine();
                Validation.ValidateString(password);
                Console.Write("[Age]");
                string ageString = Console.ReadLine();
                int age = Validation.ValidateInt(ageString);
                Console.Write("[Light/Dark]");
                string theme = Console.ReadLine();
                List<string> themes = new List<string> { "light", "dark" };
                Validation.ValInlist(themes, theme);
                str.WriteLine($"{username}|{password}|{age}|{theme}");
            }

        }
    }
}
