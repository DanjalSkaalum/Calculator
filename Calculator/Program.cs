namespace Calculator
{
    internal class Program
    {
        const int MaxHistorySize = 10;
        string[,] results = new string[MaxHistorySize, 4]; // Adding a column for the operation type
        int resultIndex = 0;

        // Constants for menu options
        const int Add = 1;
        const int Subtract = 2;
        const int Multiply = 3;
        const int Divide = 4;
        const int History = 5;
        const int Exit = 6;

        static void Main()
        {
            Program calculator = new Program();

            while (true)
            {
                // Display menu
                Console.WriteLine("Calculator Menu:");
                Console.WriteLine($"1. Add\n2. Subtract\n3. Multiply\n4. Divide\n5. History\n6. Exit");

                // Get user choice
                Console.Write("Enter your choice (1-6): ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    Console.Write("Enter your choice (1-6): ");
                }

                if (choice == Exit)
                {
                    Console.WriteLine("Exiting the calculator. Goodbye!");
                    break;
                }

                if (choice == History)
                {
                    Console.Clear();
                    calculator.DisplayHistory();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                // Get user input for numbers
                double num1, num2;

                while (!GetUserInput("Enter the first number: ", out num1))
                {
                    // Input error, prompt again
                }

                while (!GetUserInput("Enter the second number: ", out num2))
                {
                    // Input error, prompt again
                }

                // Perform calculation based on user choice
                double result = 0;
                string operation = "";

                switch (choice)
                {
                    case Add:
                        result = calculator.Addition(num1, num2);
                        operation = "Add";
                        break;
                    case Subtract:
                        result = calculator.Subtraction(num1, num2);
                        operation = "Subtract";
                        break;
                    case Multiply:
                        result = calculator.Multiplication(num1, num2);
                        operation = "Multiply by";
                        break;
                    case Divide:
                        result = calculator.Division(num1, num2);
                        operation = "Divide by";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        continue;
                }

                // Store result in history
                calculator.StoreResult(num1, num2, result, operation);

                // Display result
                Console.WriteLine($"Result: {result}\n");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Method to get user input with TryParse
        static bool GetUserInput(string prompt, out double result)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out result))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        // Method for addition
        double Addition(double a, double b)
        {
            return a + b;
        }

        // Method for subtraction
        double Subtraction(double a, double b)
        {
            return a - b;
        }

        // Method for multiplication
        double Multiplication(double a, double b)
        {
            return a * b;
        }

        // Method for division
        double Division(double a, double b)
        {
            if (b != 0)
            {
                return a / b;
            }
            else
            {
                Console.WriteLine("Cannot divide by zero. Please enter a non-zero second number.");
                return 0;
            }
        }

        // Method to store result in the history array
        void StoreResult(double num1, double num2, double result, string operation)
        {
            results[resultIndex, 0] = num1.ToString();
            results[resultIndex, 1] = num2.ToString();
            results[resultIndex, 2] = result.ToString();
            results[resultIndex, 3] = operation;

            resultIndex = (resultIndex + 1) % MaxHistorySize;
        }
        // Method to display the calculation history
        //TODO Make it so the first number is used first, instead of 10.
        void DisplayHistory()
        {
            Console.WriteLine("Calculation History:");
            for (int i = 0; i < MaxHistorySize; i++)
            {
                int index = (resultIndex + i) % MaxHistorySize;
                if (results[index, 0] != null)
                {
                    Console.WriteLine($"#{i + 1}: {results[index, 0]} {results[index, 3]} {results[index, 1]} = {results[index, 2]}");
                }
            }
            Console.WriteLine();
        }
    }
}