using PasswordGeneration;

FileAPI api = new FileAPI();

Begin();

void Begin()
{
    Console.WriteLine("Hello! Thanks for using our program for creating your new passwords.");
    Console.WriteLine("What do you want to do? (Write the number before the action)");
    Console.WriteLine("1 - Show all saved passwords");
    Console.WriteLine("2 - Create a new password");
    string output = Console.ReadLine();
    while (!CheckForCorrectAnswer(new[] { "1", "2" }, output))
    {
        Console.WriteLine("Seems like this answer is not what we expected, try again");
        output = Console.ReadLine();
    }
    
    if (output.Equals("1"))
    {
        Console.Clear();
        Console.WriteLine("Showing all saved passwords");
        ShowAllPasswords();
        return;
    }
    
    Console.Clear();
    GeneratePasswordConversation();
}

void GeneratePasswordConversation()
{
    // Conv for generating password
}

bool CheckForCorrectAnswer(string[] answers, string currentAnswer)
{
    return answers.Any(s => s.Equals(currentAnswer));
}

void ShowAllPasswords()
{
    string[] hashedPasswords = api.ReadAllPasswordsFromFile();
    if (hashedPasswords.Length == 0)
    {
        Console.WriteLine("You do not have any saved passwords.");
        AskToContinue();
        return;
    }
    
    foreach (string hashedPassword in hashedPasswords)
    {
        // ToDo: Decrypt
        Console.WriteLine(hashedPassword);
    }
    Console.WriteLine("--");
    AskToContinue();
}

void AskToContinue()
{
    Console.WriteLine("Would you like to:");
    Console.WriteLine("1 - Start from beginning");
    Console.WriteLine("2 - Exit the program");
    string output = Console.ReadLine();
    while (!CheckForCorrectAnswer(new[] { "1", "2" }, output))
    {
        Console.WriteLine("Seems like this answer is not what we expected, try again");
        output = Console.ReadLine();
    }

    if (output.Equals("1"))
    {
        Console.Clear();
        Begin();
        return;
    }

    Environment.Exit(0);
}
