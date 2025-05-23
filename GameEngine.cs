﻿namespace MathGame;

internal static class GameEngine
{
    private static DateTime start_time;

    private static string? readResult;
    private static string[] operations = ["+", "-", "*", "/", "R"];

    // Starting logic of the game
    internal static void GameProcess(int operationIndex, int difficulty)
    {
        int numberOfProblems = 10;      // Number of problems given to the user, change for testing
        int currentScore = 0;

        int time = 0;

        Console.Clear();

        // Timer for the game
        SetTimer();

        // Gives math problems and updates the score of the user
        for (int i = numberOfProblems; i > 0; i--)
        {
            Console.WriteLine("Time: {0} seconds", Time_Elapsed()); // Update timer display
            if (GiveProblem(operationIndex, difficulty))
            {
                currentScore++;
            }
            Console.Clear();
        }

        time = Time_Elapsed();  // Final time after completing all problems

        // Adds final score to user's game history
        AddToHistory(currentScore, numberOfProblems, operationIndex, difficulty, time);

        // Display score to user
        Console.WriteLine($"You got {currentScore} out of {numberOfProblems}");
        Console.WriteLine($"You took {time} seconds");
        Console.WriteLine("Press enter to go back to the main menu");
        readResult = Console.ReadLine();
    }

    // Generate a math problem
    internal static bool GiveProblem(int operationIndex, int difficulty)
    {
        const int BASE_NUM_GENERATOR = 10; // Base number for generating random numbers

        Random random = new Random();

        // Generate upper and lower bound for random numbers
        int lowerBound = (int) Math.Pow(BASE_NUM_GENERATOR, difficulty);
        int upperBound = (int) Math.Pow(BASE_NUM_GENERATOR, (difficulty + 1));

        // Generates random numbers for the math problem
        int firstNumber = random.Next(lowerBound, upperBound);
        int secondNumber = random.Next(lowerBound, upperBound);
        bool validInput = false;
        int answer;

        // Randomly select an operation
        if (operationIndex == 4)
        {
            operationIndex = random.Next(0, 4);
        }

        // For division problems, make sure the first number is divisible by the second number
        if (operations[operationIndex] == "/")
        {
            firstNumber = firstNumber * secondNumber;
        }

        // Display math problem and get user input
        do
        { 
            Console.WriteLine($"{firstNumber:N0} {operations[operationIndex]} {secondNumber:N0} ?");
            readResult = Console.ReadLine();

            // Checks if user input is an integer
            validInput = int.TryParse(readResult, out answer);

            if (!validInput)
            {
                Console.WriteLine("Did not enter an intenger, please try again.");
            }
        } while (validInput == false);

        return CheckAnswer(answer, firstNumber, secondNumber, operations[operationIndex]);
    }

    // Checks if the answer to a math problem is correct for add, sub, mult, div
    internal static bool CheckAnswer(int answer, int firstNumber, int secondNumber, string operation)
    {
        bool correctAnswer = false;

        switch (operation)
        {
            case "+":
                correctAnswer = ((firstNumber + secondNumber) == answer);
                break;
            case "-":
                correctAnswer = ((firstNumber - secondNumber) == answer);
                break;
            case "*":
                correctAnswer = ((firstNumber * secondNumber) == answer);
                break;
            case "/":
                correctAnswer = ((firstNumber / secondNumber) == answer);
                break;
        }

        return correctAnswer;
    }

    // Store score in the list of games user has played
    internal static void AddToHistory(int finalScore, int numberOfProblems, int operationIndex, int difficulty, int seconds)
    {
        string difficultyLevel = difficulty switch
        {
            0 => "Easy",
            1 => "Medium",
            2 => "Hard",
            _ => "Unknown"
        };
        ScoreHistory.CurrentScores.Add($"{operations[operationIndex]} : {finalScore} out of {numberOfProblems} | Time: {seconds} seconds | {difficultyLevel} mode");
    }

    // Sets current time
    private static void SetTimer()
    {
        start_time = DateTime.Now;
    }

    // Timer for the game
    private static int Time_Elapsed()
    {
        TimeSpan elapsed = DateTime.Now - start_time;

        return elapsed.Seconds;
    }
}
