using System;
namespace ZooKeeperApp
{
    public class Ostrich:Animal
    {
        public Ostrich(string s, string t) : base(s, t)
        {
            
        }

        public override string MakeNoise()
        {
            Console.Clear();

            return $"The ostrich stands firm! \r\n Ostrich: KWAAAAAAAAA!";
        }

        public override string Eat(int foodConsumed, string treat)
        {
            Console.Clear();

            foodConsumed += 1;
            if (foodConsumed > 4)
            {
                Poop();
                
            }
            return $"The ostrich ate an {treat}. That's his favorite!";
        }
    }
}
