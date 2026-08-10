using System;

class RockPaperScissors
{
    private static int TransitionMoveToNumber(char move)
    {
        int moveAsNumber = move switch
        {
            'R' => 1,
            'P' => 2,
            'S' => 3,
            _ => 0
        };
        
        return moveAsNumber;
    }
    
    private static string TransitionMoveToString(int move)
    {
        string moveAsString = move switch
        {
            1 => "rock",
            2 => "paper",
            3 => "scissors"
        };
        
        return moveAsString;
    }
    
    private static int IsNumberWinOrLoss(int num)
    {
        int winOrLoss = num switch
        {
            1 or -2 => 1, // WIN
            -1 or 2 => 2, // LOSS
            0 => 3  // TIE
        };
        
        return winOrLoss;
    }
    
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("How many rounds would you like to play?: ");
            
            string roundsInput = Console.ReadLine();
            bool isRoundsInputValid = int.TryParse(roundsInput, out int rounds) && rounds > 0;
            
            if (!isRoundsInputValid)
            {
                Console.WriteLine("Invalid input!");
                continue;
            }
            
            int playerScore = 0;
            int computerScore = 0;
            
            while (rounds > -1)
            {
                Console.Write("Rock, paper, scissors! Your move! (R/P/S): ");
                
                string playerMoveFullInput = Console.ReadLine().ToUpper();
                
                if (string.IsNullOrEmpty(playerMoveFullInput))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                
                char playerMoveInput = playerMoveFullInput[0];
                int playerMoveAsNumber = RockPaperScissors.TransitionMoveToNumber(playerMoveInput);
                
                if (playerMoveAsNumber <= 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                
                int computerMove = Random.Shared.Next(1, 4);
                string computerMoveAsString = RockPaperScissors.TransitionMoveToString(computerMove);
                
                int movesComparison = RockPaperScissors.IsNumberWinOrLoss(playerMoveAsNumber - computerMove);
                
                if (movesComparison == 1)
                {
                    playerScore++;
                    Console.WriteLine($"The computer chose {computerMoveAsString}! You won! {playerScore}-{computerScore}!");
                }
                else if (movesComparison == 2)
                {
                    computerScore++;
                    Console.WriteLine($"The computer chose {computerMoveAsString}! You lost! {playerScore}-{computerScore}!");
                }
                else
                {
                    Console.WriteLine($"You both chose {computerMoveAsString}! Tie! {playerScore}-{computerScore}!");
                }
                
                rounds--;
                
                if (rounds == 0)
                {
                    if (playerScore > computerScore)
                    {
                        Console.WriteLine($"Total: You won! {playerScore}-{computerScore}!");
                    }
                    else if (computerScore > playerScore)
                    {
                        Console.WriteLine($"Total: You lost! {playerScore}-{computerScore}!");
                    }
                    else
                    {
                        Console.WriteLine($"Total: Tie! {playerScore}-{computerScore}!");
                    }
                    
                    break;
                }
            }
        }
    }
}