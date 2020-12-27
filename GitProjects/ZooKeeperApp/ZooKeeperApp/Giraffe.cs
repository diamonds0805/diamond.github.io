using System;
using System.Collections.Generic;

namespace ZooKeeperApp
{
    public class Giraffe:Animal,ITrainable
    {
        public Giraffe(string s, string t) : base(s, t)
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
                return $"The giraffe hears {signal}\r\nShe performs {behavior}";
            }
            else
            {
                return $"The giraffe doesn't know the {signal} signal!";
            }
        }
         
        public string Train(string signal, string behavior)
        {
            Console.Clear();

            Behaviors.Add(signal, behavior);
            return $"The giraffe learned {behavior}! She will perform this trick after hearing the {signal} signal.";
        }
        public override string MakeNoise()
        {
            Console.Clear();

            return $"The giraffe is feeling sleepy! \r\n Giraffe: *yaaaaaaawn*";
        }

        public override string Eat(int foodConsumed, string treat)
        {
            Console.Clear();

            foodConsumed += 1;
            if (foodConsumed > 4)
            {
                Poop();
            }
            return $"The giraffe ate a {treat}. That's her favorite!";
        }
    }
}
