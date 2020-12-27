using System;
namespace ZooKeeperApp
{
    public class Alligator:Animal
    {
        public Alligator(string s, string t) : base(s, t)
        {
        }

        
        public override string MakeNoise()
        {
            Console.Clear();

            return $"The alligator opens his large mouth! \r\n Alligator: OOOOOOOOOWF!";
        }

        public override string Eat(int foodConsumed, string treat)
        {
            Console.Clear();

            foodConsumed += 1;
            if (foodConsumed > 4)
            {
                Poop();
            }
            return $"The alligator ate a {treat}. That's his favorite!";
        }
    }
}
