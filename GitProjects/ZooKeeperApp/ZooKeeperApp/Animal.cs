using System;
namespace ZooKeeperApp
{
    public abstract class Animal
    {
        protected int _foodConsumed = 0;
        //keeps track of how much food animal has eaten
        protected string _treat;
        //store the name of the food the animal likes to eat

        public string Species { get; set; }
        //will hold animal's name (i.e dolphin)
        public string Treat { get; set; }
        public Animal(string s, string treat)
        {
            Species = s;
            Treat = treat;
        }

        public virtual string Eat(int foodConsumed, string treat)
        {
            //tracks how much food has been consumed
            Console.Clear();

            _foodConsumed += 1;
                if(foodConsumed > 4)
                {
                    Poop();
                }
            
            //if animal eats over 4x should trigger Poop(); and
            //reset _foodConsumed

            //should return string describing how the animal ate the food
            return "The animal ate a treat";
        }

        public virtual string MakeNoise()
        {
            Console.Clear();

            //should return string
            //will be overidden
            //should have default value
            return "Animal made a sound";
        }

        protected void Poop()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"They pooped!");
            Console.ResetColor();
            
        }
    }
}
