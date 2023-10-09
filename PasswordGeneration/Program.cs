using PasswordGeneration;

FileAPI api = new FileAPI();

Begin();

void Begin()
{
    Console.WriteLine("__________________________________________________________________________________________________________");
    Console.WriteLine("    ____                                          __   ______                           __            ");
    Console.WriteLine("   / __ \\____ ____________      ______  _________/ /  / ____/__  ____  ___  _________ _/ /_____  _____");
    Console.WriteLine("  / /_/ / __ `/ ___/ ___/ | /| / / __ \\/ ___/ __  /  / / __/ _ \\/ __ \\/ _ \\/ ___/ __ `/ __/ __ \\/ ___/");
    Console.WriteLine(" / ____/ /_/ (__  |__  )| |/ |/ / /_/ / /  / /_/ /  / /_/ /  __/ / / /  __/ /  / /_/ / /_/ /_/ / /    ");
    Console.WriteLine("/_/    \\__,_/____/____/ |__/|__/\\____/_/   \\__,_/   \\____/\\___/_/ /_/\\___/_/   \\__,_/\\__/\\____/_/     ");
    Console.WriteLine("                                                                                                      ");
    Console.WriteLine("_________________________________________________________________________________________________________");

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
    int passwordLength = 8;
    bool smallLetters, bigLetters, haveNumbers, haveSpecial;
    
    Console.WriteLine("How many characters do you want in your password?");
    passwordLength = InputStringToNumber();
    Console.Clear();
    
    Console.WriteLine("What letters do you want in your password?");
    Console.WriteLine("1 - Only lower case letters");
    Console.WriteLine("2 - Only upper case letters");
    Console.WriteLine("3 - Both upper & lower case letters");
    string output = Console.ReadLine();
    while (!CheckForCorrectAnswer(new[] { "1", "2", "3" }, output))
    {
        Console.WriteLine("Seems like this answer is not what we expected, try again");
        output = Console.ReadLine();
    }

    switch (output)
    {
        case "1":
            smallLetters = true;
            bigLetters = false;
            break;
        case "2":
            smallLetters = false;
            bigLetters = true;
            break;
        case "3":
            smallLetters = true;
            bigLetters = true;
            break;
        default:
            smallLetters = true;
            bigLetters = true;
            break;
    }
    
    Console.Clear();
    haveNumbers = TrueFalseQuestion("Do you want your password to contain numbers?");
    Console.Clear();
    haveSpecial = TrueFalseQuestion("Do you want your password to contain special characters? ($, &, ...)");
    Console.Clear();
    Console.WriteLine("Generating password with selected options:");
    Console.WriteLine("Length: " + passwordLength);
    Console.WriteLine("Lower case letters: " + smallLetters.ToString().ToUpper());
    Console.WriteLine("Upper case letters: " + bigLetters.ToString().ToUpper());
    Console.WriteLine("Use numbers: " + haveNumbers.ToString().ToUpper());
    Console.WriteLine("Use special characters: " + haveSpecial.ToString().ToUpper());
    Console.WriteLine("");

    WhatToDoWithPassword(passwordLength, smallLetters, bigLetters, haveNumbers, haveSpecial);
}

void WhatToDoWithPassword(int passLength, bool smallLetters, bool bigLetters, bool useNumbers, bool useSpecial)
{
    string password =
        PasswordGenerateAPI.GeneratePassword(passLength, smallLetters, bigLetters, useNumbers, useSpecial);
    Console.WriteLine("Successfully generated a password! Press enter to continue");
    Console.WriteLine("Password: " + password);
    Console.ReadLine();
    
    Console.WriteLine("Password: " + password);
    Console.WriteLine("");
    Console.WriteLine("What do you want to do with this password?");
    Console.WriteLine("1 - Encrypt & Save the password into a file and exit");
    Console.WriteLine("2 - Generate a new password with the same settings");
    Console.WriteLine("3 - Generate a new password with new settings");
    Console.WriteLine("4 - Close the program");
    string output = Console.ReadLine();
    while (!CheckForCorrectAnswer(new[] { "1", "2", "3", "4" }, output))
    {
        Console.WriteLine("Seems like this answer is not what we expected, try again");
        output = Console.ReadLine();
    }

    switch (output)
    {
        case "1":
            string hashedPassword = PasswordEncryptionAPI.Encrypt(password);
            api.SaveNewPasswordToFile(hashedPassword);
            Environment.Exit(0);
            break;
        case "2":
            Console.Clear();
            WhatToDoWithPassword(passLength, smallLetters, bigLetters, useNumbers, useSpecial);
            break;
        case "3":
            Console.Clear();
            GeneratePasswordConversation();
            break;
        case "4":
            Environment.Exit(0);
            break;
    }
}

bool TrueFalseQuestion(string question)
{
    Console.WriteLine(question);
    Console.WriteLine("1 - True");
    Console.WriteLine("2 - False");
    string output = Console.ReadLine();
    while (!CheckForCorrectAnswer(new[] { "1", "2" }, output))
    {
        Console.WriteLine("Seems like this answer is not what we expected, try again");
        output = Console.ReadLine();
    }

    return output.Equals("1");
}

int InputStringToNumber()
{
    string input = Console.ReadLine();
    bool isNumber = false;
    int returningNumber = 0;
    while (!isNumber)
    {
        try
        {
            int tryNumber = Convert.ToInt32(input);
            returningNumber = tryNumber;
            isNumber = true;
        }
        catch (Exception ex)
        {
            if (ex is FormatException)
            {
                Console.WriteLine("Provided value can't be converted to int. Please try again");
                input = Console.ReadLine();
                continue;
            }
            Console.WriteLine("The number is too large, try a smaller one.");
            input = Console.ReadLine();
        }
    }

    return returningNumber;
}

bool CheckForCorrectAnswer(string[] answers, string currentAnswer)
{
    return answers.Any(s => s.Equals(currentAnswer));
}

void ShowAllPasswords()
{
    string[] encrypted = api.ReadAllPasswordsFromFile();
    if (encrypted == null || encrypted.Length == 0)
    {
        Console.WriteLine("You do not have any saved passwords.");
        AskToContinue();
        return;
    }
    
    foreach (string encryptedString in encrypted)
    {
        string password = PasswordEncryptionAPI.Decrypt(encryptedString); 
        Console.WriteLine(password);
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
