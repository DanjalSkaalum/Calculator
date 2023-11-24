namespace Calculator
{
    internal class Program
    {
        // Constants for menu options
        const int Add = 1;
        const int Subtract = 2;
        const int Multiply = 3;
        const int Divide = 4;
        const int Exit = 5;

        static void Main()
        {
            Program calculator = new Program();

            while (true)
            {
                // Display menu
                Console.WriteLine("Calculator Menu:");
                Console.WriteLine($"1. Add\n2. Subtract\n3. Multiply\n4. Divide\n5. Exit");

                // Get user choice
                Console.Write("Enter your choice (1-5): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == Exit)
                {
                    Console.WriteLine("Exiting the calculator. Goodbye!");
                    break;
                }

                // Get user input for numbers
                Console.Write("Enter the first number: ");
                double num1 = double.Parse(Console.ReadLine());
                Console.Write("Enter the second number: ");
                double num2 = double.Parse(Console.ReadLine());

                // Perform calculation based on user choice
                double result = 0;

                switch (choice)
                {
                    case Add:
                        result = calculator.Addition(num1, num2);
                        break;
                    case Subtract:
                        result = calculator.Subtraction(num1, num2);
                        break;
                    case Multiply:
                        result = calculator.Multiplication(num1, num2);
                        break;
                    case Divide:
                        result = calculator.Division(num1, num2);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        continue;
                }

                // Display result
                Console.WriteLine($"Result: {result}\n");
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
    }
}
