namespace PasswordGeneration;

using System;
using System.IO;

public class FileAPI
{
    private readonly string filePath;

    public FileAPI()
    {
        // Set the file path to the directory where the program is running.
        filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "passwords.txt");
    }

    /// <summary>
    ///     Called at the start of the program.
    ///     This should generate a file to have passwords in.
    /// </summary>
    public void Startup()
    {
        // Check if the file already exists, if not, create it.
        if (!File.Exists(filePath)) File.Create(filePath).Close();
    }

    /// <summary>
    ///     Called when user decides to save a hashed password to file.
    /// </summary>
    /// <param name="hashedPassword">The hashed password to save.</param>
    /// <returns>True if the password was saved successfully, false otherwise.</returns>
    public bool SaveNewPasswordToFile(string hashedPassword)
    {
        try
        {
            // Append the hashed password to the file, each password on a new line.
            File.AppendAllText(filePath, hashedPassword + Environment.NewLine);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    ///     Called when user decides to read all passwords from file.
    /// </summary>
    /// <returns>An array of passwords read from the file.</returns>
    public string[] ReadAllPasswordsFromFile()
    {
        try
        {
            // Read all lines from the file and return as an array.
            return File.ReadAllLines(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return null;
        }
    }
}