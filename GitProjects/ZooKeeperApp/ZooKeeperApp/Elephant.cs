using System;
using System.Collections.Generic;

namespace ZooKeeperApp
{
    public class Elephant:Animal,ITrainable
    {
        public Elephant(string s, string t) : base(s, t)
        {
            
        }
        public Dictionary<string, string> Behaviors = new Dictionary<string, string>();

        Dictionary<string, string> ITrainable.Behaviors { get; set; }
        public string Perform(string signal)
        {
            Console.Clear();

            string behavior = Behaviors[signal];
            if (behavior != null)
            {
                return $"The elephant hears {signal}\r\nHe performs {behavior}";
            }
            else
            {
                return $"The elephant doesn't know the {signal} signal!";
            }
        }
        public string Train(string signal, string behavior)
        {
            Console.Clear();

            Behaviors.Add(signal, behavior);
            return $"The elephant learned {behavior}! He will perform this trick after hearing the {signal} signal.";
        }

        public override string MakeNoise()
        {
            Console.Clear();

            return $"The elephant stands tall on a rock! \r\n Elephant: BRUUUUUUUUU!";
        }

        public override string Eat(int foodConsumed, string treat)
        {
            Console.Clear();

            foodConsumed += 1;
            if (foodConsumed > 4)
            {
                Poop();
            }
            return $"The elephant ate a {treat}. That's her favorite!";
        }
    }
}
