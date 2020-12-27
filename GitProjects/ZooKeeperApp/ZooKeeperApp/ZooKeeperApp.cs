using System;
using System.Collections.Generic;

namespace ZooKeeperApp
{
    public class ZooKeeperApp
    {
        //main functionality for app

        private List<Animal> _animals = new List<Animal>();
        //contains all animals created


        public ZooKeeperApp()
        {
            bool keepRunning = true;

            //list animals initialized
            _animals = GetAnimals(_animals);
            while (keepRunning)
            {
                
                for (int i = 0; i < _animals.Count; i++)
                {
                    //use species prop
                    Console.WriteLine($"[{i + 1}] {_animals[i].Species}");
                }

                //ask for user selection
                Console.WriteLine("\r\n[0] Exit");
                Console.Write("Please enter your selection 1 - 6: ");
                string selInput = Console.ReadLine();
                int menuSel = Validation.ValidateRange(Validation.ValidateInt(selInput), 0, 6);
                if (menuSel > 0)
                {
                    MenuSel(menuSel);
                }
                else
                {
                    UI.Footer("Thank you for using the Zoo Keeper App!\r\nGoodbye!");
                    keepRunning = false;

                }
            }

        }

        private List<Animal> GetAnimals(List<Animal> animals)
        {
            //welcome user
            UI.Header("Zoo Keeper");

            //add instances of each animal to _animals
            Monkey monkey = new Monkey("Monkey (trainable)", "banana");
            animals.Add(monkey);

            Alligator alligator = new Alligator("Alligator", "rodent");
            animals.Add(alligator);

            Giraffe giraffe = new Giraffe("Giraffe (trainable)", "leaf");
            animals.Add(giraffe);

            Elephant elephant = new Elephant("Elephant (trainable)", "peanut");
            animals.Add(elephant);

            Eagle eagle = new Eagle("Eagle", "seed");
            animals.Add(eagle);

            Ostrich ostrich = new Ostrich("Ostrich", "insect");
            animals.Add(ostrich);

            return animals;

        }

        private void MenuSel(int menuSel)
        {
            Console.Clear();
            //user selection
            
            List<string> menu = new List<string> { "Teach new skill", "Eat fave treat", "Do tricks", "Listen to their call", "Select another animal" };
            Menu animalMenu = new Menu(menu);
            bool displayAnimal = true;
            while (displayAnimal)
            {
                
                UI.Header($"{_animals[menuSel - 1].Species}");
                animalMenu.DisplayMenu();
                Console.Write("Please enter your selection: ");
                string selString = Console.ReadLine();
                int selNum = Validation.ValidateRange(Validation.ValidateInt(selString), 1, menu.Count);
                switch (selNum)
                {
                    case 1:
                        if (_animals[menuSel - 1] is ITrainable)
                        {

                            Console.Write($"Enter the signal for the new trick: ");
                            string signal = Console.ReadLine();
                            signal = Validation.ValidateString(signal);
                            Console.Write($"Enter the trick you would like them to learn: ");
                            string behavior = Console.ReadLine();
                            behavior = Validation.ValidateString(behavior);
                            string display = ((ITrainable)_animals[menuSel - 1]).Train(signal, behavior);
                            UI.DisplayValid(display);
                        }
                        else
                        {
                            UI.DisplayError("This animal cannot learn skills!");
                        }
                        break;
                    case 2:
                        Feed(_animals[menuSel - 1]);
                        break;
                    case 3:
                        if (_animals[menuSel - 1] is ITrainable)
                        {
                            Console.WriteLine("Enter the signal to see a trick");
                            string signal = Console.ReadLine();
                            signal = Validation.ValidateString(signal);
                            string display = ((ITrainable)_animals[menuSel - 1]).Perform(signal);
                            UI.DisplayValid(display);
                        }
                        else
                        {
                            UI.DisplayError("This animal cannot learn skills!");
                        }
                        break;
                    case 4:
                        string message = _animals[menuSel - 1].MakeNoise();
                        UI.DisplayValid(message);
                        break;
                    case 5:
                        UI.Footer("Returning to Animals");
                        displayAnimal = false;
                        break;
                }
            }
            

        }

        private void Feed(Animal animal)
        {
            bool feedAnimal = true;
            int foodConsumed = 0;
            Console.Clear();

            while (feedAnimal)
            {
                Console.WriteLine($"Feed {animal.Species} their favorite treat? [Y/N]");
                string response = Console.ReadLine();
                response = Validation.ValidateYOrN(response);
                if (response.ToLower() == "y")
                {
                    foodConsumed += 1;
                    string display = animal.Eat(foodConsumed, animal.Treat);
                    UI.DisplayValid(display);
                    if(foodConsumed > 6)
                    {
                        UI.DisplayError("No more treats! We have to keep them healthy!");
                        feedAnimal = false;
                    }
                } else
                {
                    feedAnimal = false;
                }
            }
        }

        }
    }
