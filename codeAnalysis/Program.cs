namespace CodeAnalysis;

public static class Program
{
    public static void Main()
    {
        // Ask for 2 numbers as integers
        Console.WriteLine("Enter the first number:");
        string? input1 = Console.ReadLine();
        Console.WriteLine("Enter the second number:");
        string? input2 = Console.ReadLine();

        // Check for null or empty inputs
        if (string.IsNullOrWhiteSpace(input1) || string.IsNullOrWhiteSpace(input2))
        {
            Console.WriteLine("Invalid input. Please enter valid numbers.");
            return;
        }

        // Try to convert inputs to integers
        if (!int.TryParse(input1, out int number1) || !int.TryParse(input2, out int number2))
        {
            Console.WriteLine("Invalid input. Please enter valid numbers.");
            return;
        }

        // Calculate the sum
        int sum = number1 + number2;
        // Display the result
        Console.WriteLine("The sum is: " + sum);

    }
}