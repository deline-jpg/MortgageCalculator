class MortgageCalculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nUXI MORTGAGE LOANS");

        //User input for loan amount (R) (principal amount)
        Console.Write("\nEnter your loan amount: R");
        double loanAmount = Convert.ToDouble(Console.ReadLine());

        //User input for annual interest rate (%)
        Console.Write("Enter the annual interest rate in PERCENTAGE: ");
        double annualInterestRate = double.Parse(Console.ReadLine()) / 100;

        //User input for loan duration (years)
        Console.Write("Enter the loan duration in YEARS: ");
        int loanTermYears = int.Parse(Console.ReadLine());

        //Calculate monthly repayment amount
        double monthlyRepayment = CalculateMonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);

        //Calculate total interest paid amount
        double totalInterestPaid = CalculateTotalInterestPaid(loanAmount, annualInterestRate, loanTermYears);

        //Calculate total amount paid with principal + interest
        double totalAmountPaid = CalculateTotalAmountPaid(loanAmount, annualInterestRate, loanTermYears);

        //Display the result of monthly amount
        Console.WriteLine("\nMonthly repayment on your home loan: R" + Math.Round(monthlyRepayment, 2));

        //Display the result of total interest amount
        Console.WriteLine("Total interest paid throughout your loan: R" + Math.Round(totalInterestPaid, 2));

        //Display the result of total overall amount
        Console.WriteLine("Total amount paid throughout your loan: R" + Math.Round(totalAmountPaid, 2));

        //Seperator
        Console.WriteLine("______________________________________________________________");

        //Display Amortization Schedule
        Console.WriteLine("\n        YOUR PERSONALIZED AMORTIZATION SCHEDULE      ");
        GenerateAmortizationSchedule(loanAmount, annualInterestRate, loanTermYears);
    }

    //Method for calculating monthly repayment
    static double CalculateMonthlyRepayment(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyInterestRate = annualInterestRate / 12;
        int loanTermMonths = loanTermYears * 12;
        double monthlyRepayment = loanAmount * (monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -loanTermMonths));
        return monthlyRepayment;
    }

    //Method for calculating total interest paid
    static double CalculateTotalInterestPaid(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyInterestRate = annualInterestRate / 12;
        int loanTermMonths = loanTermYears * 12;
        double monthlyRepayment = CalculateMonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);
        double totalInterestPaid = monthlyRepayment * loanTermMonths - loanAmount;
        return totalInterestPaid;
    }

    //Method for calculating total amount paid (principal + interest)
    static double CalculateTotalAmountPaid(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double totalInterestPaid = CalculateTotalInterestPaid(loanAmount, annualInterestRate, loanTermYears);
        double totalAmountPaid = loanAmount + totalInterestPaid;
        return totalAmountPaid;
    }

    //Method for calculating and generating the amortization schedule table
    static void GenerateAmortizationSchedule(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyInterestRate = annualInterestRate / 12;
        int loanTermMonths = loanTermYears * 12;
        double balanceRemaining = loanAmount;
        double monthlyRepayment = CalculateMonthlyRepayment(loanAmount, annualInterestRate, loanTermYears);

        //Create sub headings in column form for schedule
        Console.WriteLine("\nMonth\t\tPrincipal\tInterest\tBalance");

        //Calculate and display numbers from 1 to end of loan duration in months
        for (int month = 1; month <= loanTermMonths; month++)
        {
            double interestPayment = balanceRemaining * monthlyInterestRate;
            double principalPayment = monthlyRepayment - interestPayment;
            balanceRemaining -= principalPayment;

            //Display all numbers in 2 decimal numbers and in columns under each sub heading
            Console.WriteLine($"{month}\t\t  {Math.Round(principalPayment,2)}\t\t  {Math.Round(interestPayment,2)}\t\t  {Math.Round(balanceRemaining,2)}\t\t");

            //Break the loop when there is no outstanding money lest to pay (End of loan duration)
            if (balanceRemaining <= 0)
                break;
        }
    }
}


