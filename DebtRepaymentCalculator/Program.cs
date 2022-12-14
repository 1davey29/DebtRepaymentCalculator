internal class Program
{
    // List of all debts
    private static List<Debt> Debts = new List<Debt>();
    private static int Increment = 1;

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

            Console.WriteLine($"\nCurrent increment: ${Increment}\n");
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
            int userDebtValue;
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

                    string monthlyPayment = "";
                    string paymentFormat = "";

                    Console.Write("Is your monthly payment static of formulaic? ");

                    paymentFormat = Console.ReadLine();

                    if (paymentFormat.Equals("static"))
                    {
                        Console.Write("Please enter your static monthly payment amount: ");

                        float staticPayment = float.Parse(Console.ReadLine());

                        monthlyPayment = $"{paymentFormat}:::{staticPayment}";
                    }
                    else
                    {
                        Console.Write("Please enter your formulaic monthly payment amount: ");

                        string formulaicPayment = Console.ReadLine();

                        monthlyPayment = $"{paymentFormat}:::{formulaicPayment}";
                    }

                    Debts.Add(new Debt(newDebtName, newDebtBalance, newDebtAPR, monthlyPayment));

                    break;

                case "2":
                    if (Debts.Count == 0)
                    {
                        Console.WriteLine("No debt accounts exist");
                        break;
                    }

                    for (int i = 0; i < Debts.Count - 1; i++)
                    {
                        Console.WriteLine($"{i + 1}) {Debts[i].Name}");
                    }

                    Console.Write("Please select a debt account to edit: ");

                    userDebtValue = int.Parse(Console.ReadLine());
                    
                    // TODO: Change to a standard while loop, remove if statement
                    if (!(userDebtValue > 0 || userDebtValue <= Debts.Count))
                    {
                        do
                        {
                            Console.Write("Invalid input. Please select a debt account to edit: ");

                            userDebtValue = int.Parse(Console.ReadLine());
                        } while (!(userDebtValue > 0 || userDebtValue <= Debts.Count));
                    }

                    EditDebtAccount(userDebtValue - 1);

                    break;

                case "3":
                    if (Debts.Count == 0)
                    {
                        Console.WriteLine("No debt accounts exist");
                        break;
                    }

                    for (int i = 0; i < Debts.Count - 1; i++)
                    {
                        Console.WriteLine($"{i + 1}) {Debts[i].Name}");
                    }

                    Console.Write("Please select a debt account to delete: ");

                    userDebtValue = int.Parse(Console.ReadLine());

                    // TODO: Change to a standard while loop, remove if statement
                    if (!(userDebtValue > 0 || userDebtValue <= Debts.Count))
                    {
                        do
                        {
                            Console.Write("Invalid input. Please select a debt account to delete: ");

                            userDebtValue = int.Parse(Console.ReadLine());
                        } while (!(userDebtValue > 0 || userDebtValue <= Debts.Count));
                    }

                    Debts.RemoveAt(userDebtValue - 1);

                    break;

                case "4":
                    Console.Write("Please enter a new increment value: ");

                    Increment = int.Parse(Console.ReadLine());

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

    private static int EditDebtAccount(int debtIndex)
    {
        Console.WriteLine("1) Account Name\n" +
            "2) Account Balance\n" +
            "3) Account APR\n" +
            "4) Account Monthly Payment Formula\n" +
            "5) Cancel");
        Console.Write("\nPlease select an option to edit from above");

        int userInput = int.Parse(Console.ReadLine());

        while (userInput < 1 || userInput > 5)
        {
            Console.Write("Invalid input, please try again: ");

            userInput = int.Parse(Console.ReadLine());
        }

        switch (userInput)
        {
            case 1:
                Console.Write("Please enter a new account name: ");

                Debts[debtIndex].Name = Console.ReadLine();

                break;
            case 2:
                Console.Write("Please enter a new account balance: ");

                Debts[debtIndex].Balance = float.Parse(Console.ReadLine());

                break;
            case 3:
                Console.Write("Please enter a new account APR: ");

                Debts[debtIndex].APR = float.Parse(Console.ReadLine());

                break;
            case 4:
                string monthlyPayment = "";
                string paymentFormat = "";

                Console.Write("Is your monthly payment static of formulaic? ");

                paymentFormat = Console.ReadLine();

                if (paymentFormat.Equals("static"))
                {
                    Console.Write("Please enter your static monthly payment amount: ");

                    float staticPayment = float.Parse(Console.ReadLine());

                    monthlyPayment = $"{paymentFormat}:::{staticPayment}";
                }
                else
                {
                    Console.Write("Please enter your formulaic monthly payment amount: ");

                    string formulaicPayment = Console.ReadLine();

                    monthlyPayment = $"{paymentFormat}:::{formulaicPayment}";
                }

                Debts[debtIndex].MonthlyPayment = monthlyPayment;

                break;
            case 5:
                return 1;
        }

        return 0;
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
        public string Name = "";

        // Debt account's current balance
        public float Balance = 0;

        // Debt account's APR
        public float APR = 0;

        // Debt account's monthly payment formula
        public string MonthlyPayment = "";

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

        private float CalculateMonthlyPayment(string formula)
        {
            float monthlyPayment = 0;
            List<String> funcCalls = formula.Split('(').ToList<String>();

            funcCalls[funcCalls.Count - 1] = funcCalls[funcCalls.Count - 1].Remove(funcCalls[funcCalls.Count - 1].Length - 1, 1);

            if (funcCalls[0].StartsWith("min"))
            {
                funcCalls.RemoveAt(0);

                float min = float.Parse(funcCalls[0].Split(',')[0]);

                funcCalls[0] = funcCalls[0].Split(',')[1];

                if (Balance < min)
                {
                    monthlyPayment = Balance;
                }
                else
                {
                    if (funcCalls[0].StartsWith("high") || funcCalls[0].StartsWith("low"))
                    {
                        int indexSplit = funcCalls.FindIndex(x => x.Equals(";"));
                        List<string> firstFormula = funcCalls.GetRange(0, indexSplit);
                        List<string> secondFormula = funcCalls.GetRange(indexSplit + 1, funcCalls.Count - indexSplit - 1);
                        float firstPayment = 0;
                        float secondPayment = 0;

                        monthlyPayment = funcCalls[0].StartsWith("high") ? (firstPayment > secondPayment ? firstPayment : secondPayment) : (firstPayment < secondPayment ? firstPayment : secondPayment);
                    }
                    else
                    {

                    }
                }
            }

            return monthlyPayment;
        }

        // Returns monthly payment based on MonthlyPayment formula
        public float GetMonthlyPayment()
        {
            float monthlyPayment = 0;
            string[] paymentFormula = MonthlyPayment.Split(":::");

            if (paymentFormula[0].Equals("static"))
            {
                monthlyPayment = float.Parse(paymentFormula[1]);
            }
            else
            {
                monthlyPayment = CalculateMonthlyPayment(paymentFormula[1]);
            }

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