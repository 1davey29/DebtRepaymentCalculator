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
        } while (!MainMenu());
    }

    // Primary debt program function, shows user debt accounts and gives menu options for editing debts and doing calculations
    private static void RunDebtProgram()
    {
        do
        {
            Console.WriteLine("Current debt accounts:\n");

            foreach (Debt debt in Debts)
            {
                Console.WriteLine(debt.ToString());
            }

            Console.WriteLine("\n");
        } while (!ProgramMenu());
    }

    // Prints main menu options and allows for user selection
    private static bool MainMenu()
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
                    RunDebtProgram();

                    break;

                case "2":
                    LoadDebtFile();

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

    // Prints program menu options and allows for user selection
    private static bool ProgramMenu()
    {
        bool isQuitting = false;
        bool isValid = true;

        Console.WriteLine("Below are the menu options:\n\n" +
            "1) Add New Debt\n" +
            "2) Edit Existing Debt\n" +
            "3) Delete Existing Debt\n" +
            "4) Edit Increment\n" +
            "5) Calculate Recommended Monthly Payments\n" +
            "6) Return to Main Menu\n");
        Console.Write("Please select one of the above menu options by entering the integer value of the option: ");

        // TODO: Add type validation
        do
        {
            isValid = true;

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter your debt's account name: ");

                    string newDebtName = Console.ReadLine();

                    Console.Write("Enter your debt's balance: ");

                    float newDebtBalance = float.Parse(Console.ReadLine());

                    Console.Write("Enter your debt's APR: ");

                    float newDebtAPR = float.Parse(Console.ReadLine());

                    Console.Write("Enter your debt's monthly payment formula: ");

                    string newDebtMonthly = Console.ReadLine();

                    Debts.Add(new Debt(newDebtName, newDebtBalance, newDebtAPR, newDebtMonthly));

                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                case "6":
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
        string fileName;
        bool firstIteration = true;

        // Prompts user for file name and confirms file exists
        do
        {
            if (!firstIteration)
            {
                Console.WriteLine("File does not exist");
            }

            Console.Write("Enter file name (file extension will be automatically appended): ");

            fileName = Console.ReadLine() + ".txt";
            firstIteration = false;

            // Add some form of save file validation to confirm file is valid for the program
        } while (!File.Exists(fileName));

        Debts = new List<Debt>();

        using (StreamReader sr = File.OpenText(fileName))
        {
            string debtString;

            while ((debtString = sr.ReadLine()) != null)
            {
                Debts.Add(new Debt(debtString));
            }
        }

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

        // Overrides ToString function for use in displaying to the user
        public override string ToString()
        {
            string returnString = "";

            returnString = $"{Name}: {Balance} @ {APR * 100}% APR for {GetMonthlyPayment} a month";

            return returnString;
        }
    }
}