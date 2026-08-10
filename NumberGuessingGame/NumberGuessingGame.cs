using System;

class NumberGuessingGame 
{
    static void Main(string[] args)
    {
        int targetNumber = Random.Shared.Next(1, 101);
        int attempts = 1;
        
        while (true)
        {
            Console.Write($"Guess the number between 1-100! (Attempt {attempts}): ");
            string guessInput = Console.ReadLine();
            bool isInputValid = int.TryParse(guessInput, out int guess);
            
            if (isInputValid)
            {
                attempts++;
                
                if (targetNumber > guess)
                {
                    Console.WriteLine("The number is greater than your guess (Too low)!");
                } else if (targetNumber < guess)
                {
                    Console.WriteLine("The number is less than your guess (Too high)!");
                } else
                {
                    Console.WriteLine($"You guessed correct! Total attempts: {attempts}");
                    break;
                }
            } else 
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}