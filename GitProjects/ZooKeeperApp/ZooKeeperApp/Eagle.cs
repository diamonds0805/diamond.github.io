using System;
namespace ZooKeeperApp
{
    public class Eagle:Animal
    {
        public Eagle(string s, string t) : base(s, t)
        {
           
        }

        public override string MakeNoise()
        {
            Console.Clear();

            return $"The eagle is perched on a tree! \r\n Eagle: QWEEEEEEEEE!";
        }

        public override string Eat(int foodConsumed, string treat)
        {
            Console.Clear();

            foodConsumed += 1;
            if (foodConsumed > 4)
            {
                Poop();
            }
            return $"The eagle ate a {treat}. That's his favorite!";
        }
    }
}
