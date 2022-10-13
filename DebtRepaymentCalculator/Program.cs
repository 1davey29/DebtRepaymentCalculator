internal class Program
{
    private static void Main(string[] args)
    {
        // Prints welcome message to the program
        Console.WriteLine("Welcome to Debt Repayment Calculator v0.1! This code is a work in progress.");

        do
        {
        } while (!Menu());
    }

    private static bool Menu()
    {
        bool isQuitting = false;
        bool isValid = true;

        Console.WriteLine("Below are the menu options:\n\n" +
            "1) Launch Program\n" +
            "2) Load Debt File\n" +
            "3) Save Debt File\n" +
            "4) Exit\n");
        Console.Write("Please select one of the above menu options by entering the integer value of the option: ");

        do
        {
            isValid = true;

            switch (Console.ReadLine())
            {
                case "1":
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    isQuitting = true;

                    break;

                default:
                    isValid = false;

                    Console.Write("\nInvalid option, please try again: ");

                    break;
            }
        } while (!isValid);

        return isQuitting;
    }

    // Class representing a single debt account of the user (such as credit cards, Affirm, etc.)
    class Debt
    {
        // Debt account name
        private string Name = "";

        // Debt account's current balance
        private int Balance = 0;

        // Debt account's APR
        private float APR = 0;

        // Debt account's monthly payment formula
        private string MonthlyPayment = "";

        public Debt(string name, int balance, float apr, string monthlyPayment)
        {
            Name = name;
            Balance = balance;
            APR = apr / 100;
            MonthlyPayment = monthlyPayment;
        }
    }
}