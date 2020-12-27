using System;
using System.Collections.Generic;
namespace ZooKeeperApp
{
    public class Monkey:Animal,ITrainable
    {
        public Monkey(string s, string t):base(s,t)
        {
            Behaviors = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Behaviors { get; set; }


        public string Perform(string signal)
        {
            Console.Clear();
            
            signal = Validation.ValidateInDict(Behaviors,signal); ;
            string behavior = Behaviors[signal];
            if(behavior != null)
            {
                return $"The monkey hears {signal}\r\nHe performs {behavior}";
            } else if (Behaviors is null)
            {
                return "This is empty! Returning to main menu";

            }
            else
            {
                return $"The monkey doesn't know {signal} signal!";
            }
        }

        public string Train(string signal, string behavior)
        {
            Console.Clear();

            Behaviors.Add(signal, behavior);
            return $"The monkey learned {behavior}! He will perform this trick after hearing the {signal} signal.";
        }

        public override string MakeNoise()
        {
            Console.Clear();

            return $"The monkey jumps and makes a loud cry! \r\nMonkey: EEEEEEEEEEEEE!";
        }

        public override string Eat(int foodConsumed, string treat)
        {
            Console.Clear();

            foodConsumed += 1;
            if (foodConsumed > 4)
            {
                Poop();
            }
            return $"The monkey ate a {treat}. That's his favorite!";
        }
    }
}
