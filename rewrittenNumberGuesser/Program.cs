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
                userGuess = PromptUserGuess();
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

            return guessStatus;
        }

        public static bool EndGame (string guessStatus)
        {
            if (guessStatus != "correct")
            {
                Console.WriteLine("You failed. Game over.");
            }

            var gameComplete = true;

            return gameComplete;
        }

        public static string CreateGuessList ()
        {
            var list = "Previous guesses: ";
            return list;
        }

        public static string AddToGuessList (int parsedGuess, string guessStatus)
        {
            var addition = $"{parsedGuess} ({guessStatus}) ";
            return addition;
        }

        public static string DetermineTryAgain (string guessStatus, int parsedGuess, int correctNum)
        {
            var numberTries = 1;
            var pastGuesses = CreateGuessList();

            while (guessStatus != "correct" && numberTries < 5)
            {
                pastGuesses += AddToGuessList(parsedGuess, guessStatus);
                Console.WriteLine(pastGuesses);
                Console.Write($"You have {5 - numberTries} tries left. ");
                parsedGuess = ParseUserGuess(PromptUserGuess());
                guessStatus = GiveFeedback(parsedGuess, correctNum);
                numberTries++;
            }

            return guessStatus;
        }

        public static void PlayNumberGuesser ()
        {
            var gameComplete = false;

            while (gameComplete == false)
            {

                //create random number
                var correctNum = CreateRandomNumber(1, 101);

                //prompt for guess and parse
                var parsedGuess = ParseUserGuess(PromptUserGuess());

                //feedback
                var guessStatus = GiveFeedback(parsedGuess, correctNum);

                //try again if wrong
                guessStatus = DetermineTryAgain(guessStatus, parsedGuess, correctNum);

                //inform of win or loss and end game
                gameComplete = EndGame(guessStatus);
            }

            Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            PlayNumberGuesser();           
        }  
    }
}
