namespace MathGame;

internal class UserInterface()
{
    private string? readResult;
    internal void MainMenu()
    {
        string mainMenuSelection;

        do
        {
            Console.Clear();

            mainMenuSelection = "";     // Resets menu selection for each loop

            // Ask user if they want to play the game, check history, or exit
            Console.WriteLine("Welcome to the Math Game app. Your main menu options are");
            Console.WriteLine("1. Play the game");
            Console.WriteLine("2. Check game history");
            Console.WriteLine("3. End the program\n");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                mainMenuSelection = readResult.ToLower().Trim();
            }

            // Selects appropiate option based on user input
            switch (mainMenuSelection)
            {
                case "1":
                    PlayGame();
                    break;
                case "2":
                    CheckHistory();
                    break;
                case "3":
                    ExitGame();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again. (Press enter to continue)");
                    Console.ReadLine();
                    break;
            }
        } while (mainMenuSelection != "3");
    }

    // Second menu to choose which operation to play with
    internal void PlayGame()
    {
        Console.Clear();

        string playMenuSelection = "";
        string[] operations = ["+", "-", "*", "/", "R"];

        // Ask user which operation they want to use
        Console.WriteLine("Choose which operation you wish to play with");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Substraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Random using all operations");
        Console.WriteLine(".. Enter anything else to go back\n");

        // Checks if input is not null
        readResult = Console.ReadLine();
        if (readResult != null)
        {
            playMenuSelection = readResult.ToLower().Trim();
        }

        int.TryParse(playMenuSelection, out int operationIndex);

        if (operationIndex >= 1 && operationIndex <= 5)
        {
            operationIndex--;      // Adjust operation index to match math game logic
            ChooseDifficulty(operationIndex);
        }
    }

    internal void ChooseDifficulty(int operationIndex)
    {
        Console.Clear();
        string difficultyMenuSelection = "";
        // Ask user which difficulty they want to use
        Console.WriteLine("Choose which difficulty you wish to play with");
        Console.WriteLine("The higher the difficulty, the bigger the numbers used");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Console.WriteLine(".. Enter anything else to go back\n");
        // Checks if input is not null
        readResult = Console.ReadLine();
        if (readResult != null)
        {
            difficultyMenuSelection = readResult.ToLower().Trim();
        }

        int.TryParse(difficultyMenuSelection, out int difficultyLevel);

        // Starts the game with the correct operation and difficulty
        if (difficultyLevel >= 1 && difficultyLevel <= 3)
        {
            difficultyLevel--;      // Adjust difficulty level to match math game logic
            GameEngine.GameProcess(operationIndex, difficultyLevel);
        }
    }

    // Checks if user has played the game before and displays their score history
    internal void CheckHistory()
    {
        Console.Clear();

        Console.WriteLine("Game History:");
        if (ScoreHistory.CurrentScores.Count > 0)
        {
            //DisplayGameHistory();
            foreach (string score in ScoreHistory.CurrentScores)
            {
                Console.WriteLine(score);
            }
        }
        else
        {
            Console.WriteLine("You have not played the game yet!");
        }

        // Pause message to let the user see their previous scores
        Console.WriteLine("\nPress enter to go back to the main menu");
        readResult = Console.ReadLine();

    }

    /* Possibly add more details
    // Displays the scores for all games user has played
    internal void DisplayGameHistory()
    {
        foreach (string score in ScoreHistory.CurrentScores)
        {
            Console.WriteLine(score);
        }
    }*/

    // Displays message for when user exits the game
    internal void ExitGame()
    {
        Console.WriteLine("Thank you for playing!");
        readResult = Console.ReadLine();
    }
}