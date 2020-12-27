using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindErrorsClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            /* INSTRUCTIONS
                *  1. Copy this code to a new project, do not work in this file!
                *  2. Start by finding and fixing all of the Syntax Errors first.
                *     - Syntax errors are the red squiggly lines that will prevent the code from running.
                *  3. Now the code should run and you can see the output on the console.
                *  4. Find the Logical Errors
                *     - Logical errors will give you the wrong output.
                *     - These are a bit harder to find.  Keep checking the correct output given!
                *     - Follow any additional instructions given in the comments.
                *  5. Once you think you are done, check your output line by line against the 
                *     given correct output.
                *  6. When it matches perfectly, zip your whole project file and submit it to FSO.
              */

            /* Diamond Sanford
             * 3/8/20
             * Find The Errors
             */

            //In this program we will create a class of a movie and utillize the methods and member variables

            //Create four instances of the movie class
            Movie theGoonies = new Movie("The Goonies", 19000000m, 61500000m, 1985);
            Movie originalGhostbusters = new Movie("Ghostbusters", 30000000m, 295200000m, 1948);
            Movie ghostbusters = new Movie("Ghostbusters", 144000000m, 229100000m, 2016);
            Movie theAvengers = new Movie("The Avengers", 220000000m, 1519000000m, 2012);

            

            //Use the Getters
            Console.WriteLine("\r\nWhen I was a kid, one of my favorite movies growing up was {0} which came out in {1}.", theGoonies.GetMovieTitle(), theGoonies.GetYearMade());

            Console.WriteLine("When it originally came out it cost {0} to make, which was a lot back then!", theGoonies.GetCostToMake().ToString("C"));

           

            Console.WriteLine("\r\nNow a days movies cost so much more to make!");
            Console.WriteLine("Take {0} for example.\r\nIt cost {1} to make, however it also brought in {2} at the box office!!", theAvengers.GetMovieTitle(), theAvengers.GetCostToMake().ToString("C"), theAvengers.GetMoneyMade().ToString("C")) ;
            //Update the Box Office Total for The Avenegers movie using a setter
            theAvengers.SetMoneyMade(1299000000m);

            Console.WriteLine("Marvel and Disney made {0} from that movie alone!", theAvengers.GetMoneyMade().ToString("C"));
            

            Console.WriteLine("\r\nLet's take a look at the same movie, but made in different years.");

            //Fix Ghostbusters original year it came out using a setter
            originalGhostbusters.SetYearMade(1984);

            Console.Write("{0} came out in both {1} and in {2}!", originalGhostbusters.GetMovieTitle(), originalGhostbusters.GetYearMade(), ghostbusters.GetYearMade());

            //Calculate the difference between each ghostbuster film
            decimal differenceBudget = ghostbusters.GetCostToMake() - originalGhostbusters.GetCostToMake();
            decimal differneceBoxOffice = originalGhostbusters.GetMoneyMade() - ghostbusters.GetMoneyMade();


            Console.WriteLine("If we take a look at how each film did in the box office, you might think they were basically the same.");
            Console.WriteLine("The original making {1}, while the new one made {0}.", originalGhostbusters.GetMoneyMade().ToString("C"), ghostbusters.GetMoneyMade().ToString("C"));
            Console.WriteLine("That is only a difference of {0}.", differneceBoxOffice.ToString(""));

            Console.WriteLine("\r\nHowever when you look at the costs to make the two films, it gets more interesting!");
            Console.WriteLine("The original cost {0} to make.\r\nThe new cost {1}.\r\nThat is a difference of {2}!", originalGhostbusters.GetCostToMake().ToString("C"), ghostbusters.GetCostToMake().ToString("C"), differenceBudget.ToString("C"));

            //Conditional to test which has the higher profit
            if (originalGhostbusters.ProfitMade() > ghostbusters.ProfitMade())
            {
                //Calculate the difference in profit    
                decimal differenceProfits = originalGhostbusters.ProfitMade() - ghostbusters.ProfitMade();
                Console.WriteLine("\r\nThis means there is a difference in profit between the two films of {0}!", differenceProfits.ToString("C"));
                Console.WriteLine("Which makes the original much more profitable!");

            }
            else
            {
                decimal differenceProfits = ghostbusters.ProfitMade() - originalGhostbusters.ProfitMade();
                Console.WriteLine("\r\nThis means there is a difference in profit between the two films of {0}!", differenceProfits.ToString("C"));
                Console.WriteLine("Which makes the remake much more profitable!");
            }


            Console.WriteLine("\r\nIn the end though, they were both great films in their own way!");

        }
    }
}
