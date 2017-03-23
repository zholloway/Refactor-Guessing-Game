using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewrittenNumberGuesser
{
    class Program
    {

        public static int CreateRandomNumber (int lower, int upper)
        {
            Random rand = new Random();
            int correctNum = rand.Next(lower, upper);
            return correctNum;
        }

        public static string PromptUserGuess ()
        {
            Console.WriteLine("Please guess a number between 1 and 100.");
            var userGuess = Console.ReadLine();
            return userGuess;
        }

        public static int ParseUserGuess (string userGuess)
        {
            var parsedGuess = 0;
            var wasSuccessful = int.TryParse(userGuess, out parsedGuess);

            while (wasSuccessful != true)
            {
                Console.WriteLine("Oops, that is not number. Please try again.");
                wasSuccessful = int.TryParse(userGuess, out parsedGuess);
            }

            return parsedGuess;
        }

        public static string GiveFeedback (int userGuess, int correctNum)
        {
            var guessStatus = "";

            if (userGuess < correctNum)
            {
                Console.WriteLine("Sorry, that guess was too low.");
                guessStatus = "low";
            }
            else if (userGuess > correctNum)
            {
                Console.WriteLine("Sorry, that guess was too high.");
                guessStatus = "high";
            }
            else
            {
                Console.WriteLine("You got it right! Congratulations!");
                guessStatus = "correct";
            }
        }

        static void Main(string[] args)
        {
            //create random number
            var correctNum = CreateRandomNumber(1, 101);

            //prompt for guess and parse
            var parsedGuess = ParseUserGuess(PromptUserGuess());

            //feedback
            
        }  
    }
}
