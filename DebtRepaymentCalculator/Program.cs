internal class Program
{
    // List of all debts
    private static List<Debt> Debts = new List<Debt>();

    private static void Main(string[] args)
    {
        // Prints welcome message to the program
        Console.WriteLine("Welcome to Debt Repayment Calculator v0.1! This code is a work in progress.");

        do
        {
        } while (!Menu());
    }

    // Prints menu options and allows for user selection
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
                    SaveDebtFile();

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

    // Saves debts to a writable text file
    private static int SaveDebtFile()
    {
        Console.Write("Enter file name (file extension will be automatically appended): ");

        string fileName = Console.ReadLine() + ".txt";

        using (StreamWriter sw = File.CreateText(fileName))
        {
            foreach (Debt debt in Debts)
            {
                sw.WriteLine(debt.GetSaveString());
            }
        }
        
        return 0;
    }

    // Loads debts from a text file
    private static int LoadDebtFile()
    {
        return 0;
    }

    // Class representing a single debt account of the user (such as credit cards, Affirm, etc.)
    class Debt
    {
        // Debt account name
        private string Name = "";

        // Debt account's current balance
        private float Balance = 0;

        // Debt account's APR
        private float APR = 0;

        // Debt account's monthly payment formula
        private string MonthlyPayment = "";

        // Updates balance of account based on adjustment amount
        public void UpdateBalance(float adjustment)
        {
            Balance += adjustment;
        }

        // Updates APR
        public void UpdateAPR(float newAPR)
        {
            APR = newAPR;
        }

        // Returns monthly payment based on MonthlyPayment formula
        public float GetMonthlyPayment()
        {
            float monthlyPayment = 0;

            return monthlyPayment;
        }

        // Returns save string to be written to file
        public string GetSaveString()
        {
            string saveString = $"{Name}||{Balance}||{APR}||{MonthlyPayment}";

            return saveString;
        }

        // Load Constructor for Debt class
        public Debt(string saveString)
        {
            string[] debtVariables = saveString.Split("||");
            Name = debtVariables[0];
            Balance = float.Parse(debtVariables[1]);
            APR = float.Parse(debtVariables[2]) / 100;
            MonthlyPayment = debtVariables[3];
        }

        // Main Constructor for Debt class
        public Debt(string name, float balance, float apr, string monthlyPayment)
        {
            Name = name;
            Balance = balance;
            APR = apr / 100;
            MonthlyPayment = monthlyPayment;
        }
    }
}