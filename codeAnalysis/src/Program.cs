namespace CodeAnalysis;

public static class Program
{
    public static int MultiplyNumbers(int num1, int num2)
    {
        return num1 * num2;
    }

    public static int SumNumbers(int num1, int num2)
    {
        return num1 + num2;
    }

    public static double DivideNumbers(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }
        return (double)num1 / num2;
    }

    private static void MultiplyNumbersFromString(string num1, string num2)
    {
        if (int.TryParse(num1, out int number1) && int.TryParse(num2, out int number2))
        {
            int result = MultiplyNumbers(number1, number2);
            Console.WriteLine($"The multiplication of {number1} and {number2} is: {result}");
        }
        else
        {
            Console.WriteLine("Invalid input for multiplication.");
        }
    }

    private static void SumNumbersFromString(string num1, string num2)
    {
        if (int.TryParse(num1, out int number1) && int.TryParse(num2, out int number2))
        {
            int result = SumNumbers(number1, number2);
            Console.WriteLine($"The sum of {number1} and {number2} is: {result}");
        }
        else
        {
            Console.WriteLine("Invalid input for summation.");
        }
    }

    private static void DivideNumbersFromString(string num1, string num2)
    {
        if (int.TryParse(num1, out int number1) && int.TryParse(num2, out int number2))
        {
            try
            {
                double result = DivideNumbers(number1, number2);
                Console.WriteLine($"The division of {number1} by {number2} is: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for division.");
        }
    }

    public static void Main()
    {
        // Ask for 2 numbers as integers
        Console.WriteLine("Enter the first number:");
        string? input1 = Console.ReadLine();
        Console.WriteLine("Enter the second number:");
        string? input2 = Console.ReadLine();

        // Ask for operation to perform
        Console.WriteLine("Enter the operation to perform (1. Multiply, 2. Sum, 3. Divide): ");
        string? operation = Console.ReadLine();

        // Check for null or empty inputs
        if (string.IsNullOrWhiteSpace(input1) || string.IsNullOrWhiteSpace(input2))
        {
            Console.WriteLine("Invalid input. Please enter valid numbers.");
            return;
        }

        // Check that if operation is empty, abort
        if (string.IsNullOrWhiteSpace(operation))
        {
            Console.WriteLine("No operation specified. Aborting.");
            return;
        }

        // Perform the operation based on user input
        if (operation.Equals("1", StringComparison.OrdinalIgnoreCase))
        {
            MultiplyNumbersFromString(input1, input2);
        }
        else if (operation.Equals("2", StringComparison.OrdinalIgnoreCase))
        {
            SumNumbersFromString(input1, input2);
        }
        else if (operation.Equals("3", StringComparison.OrdinalIgnoreCase))
        {
            DivideNumbersFromString(input1, input2);
        }
        else
        {
            Console.WriteLine("Unknown operation. Please enter multiply, Sum, or Divide.");
        }
    }
}