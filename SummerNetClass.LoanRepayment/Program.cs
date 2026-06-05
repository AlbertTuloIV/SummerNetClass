// Albert Tulo 6/5/2026
// Homework Assignment 3: Loan Repayment Schedule

namespace LoanRepayment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoanInfo loanInfo = new LoanInfo();

            Console.WriteLine("Input Items to Generate Loan Repayment Schedule:\n");

            loanInfo.InitialAmount = GetValidDouble(
                "Loan Amount: ",
                5000,
                500000,
                "Loan amount cannot exceed $500,000 and must be at least $5,000. Please try again."
            );

            loanInfo.InterestRate = GetValidInterestRate();

            loanInfo.LoanLife = GetValidInt(
                "Years: ",
                1,
                40,
                "Loan length must be between 1 and 40 years. Please try again."
            );

            loanInfo.PaymentsPerYear = GetValidInt(
                "Payments per Year: ",
                1,
                365,
                "Payments per year must be between 1 and 365. Please try again."
            );

            loanInfo.PaymentSchedules = CalculatePaymentSchedules(loanInfo);

            Console.WriteLine();
            Console.WriteLine($"Total Payments: {loanInfo.PaymentsPerYear * loanInfo.LoanLife}");
            Console.WriteLine($"Payment Amount: {loanInfo.PaymentSchedules[0].FormattedPaymentAmount}");
            Console.WriteLine();

            Console.WriteLine("Loan Repayment Schedule");
            Console.WriteLine($"{"Payment Num",-15}{"Date",-15}{"Payment",-15}{"Interest",-15}{"Principal",-15}{"Balance",-15}");
            Console.WriteLine($"{"0",-15}{DateTime.Today.ToString("MM/dd/yyyy"), -15}{"-",-15}{"-",-15}{"-",-15}{loanInfo.FormattedInitialAmount, -15}");

            foreach (var payment in loanInfo.PaymentSchedules)
            {
                Console.WriteLine(
                    $"{payment.PaymentNumber,-15}" +
                    $"{payment.PaymentDate.ToString("MM/dd/yyyy"),-15}" +
                    $"{payment.FormattedPaymentAmount,-15}" +
                    $"{payment.FormattedInterestPortion,-15}" +
                    $"{payment.FormattedPrincipalPortion,-15}" +
                    $"{payment.FormattedBalanceRemaining,-15}"
                );
            }

            Console.WriteLine();
            Console.WriteLine($"Total Payments: {loanInfo.PaymentSchedules.Sum(p => p.PaymentAmount).ToString("C")}");
            Console.WriteLine($"Total Interest: {loanInfo.PaymentSchedules.Sum(p => p.InterestPortion).ToString("C")}");
        }

        public static double GetValidDouble(string message, double min, double max, string errorMessage)
        {
            double value;

            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                }

                Console.WriteLine(errorMessage);
            }
        }

        public static int GetValidInt(string message, int min, int max, string errorMessage)
        {
            int value;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                }

                Console.WriteLine(errorMessage);
            }
        }

        public static double GetValidInterestRate()
        {
            while (true)
            {
                Console.Write("Annual Interest Rate (%): ");

                string inputPerc = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputPerc))
                {
                    Console.WriteLine("Interest rate cannot be blank. Please try again.");
                    continue;
                }

                inputPerc = inputPerc.Replace("%", "");

                if (double.TryParse(inputPerc, out double interestRate))
                {
                    if (interestRate > 0 && interestRate <= 100)
                    {
                        return interestRate / 100.0;
                    }
                }

                Console.WriteLine("Invalid interest rate. Enter something like 5.6 or 5.6%.");
            }
        }

        public static List<LoanPaymentSchedule> CalculatePaymentSchedules(LoanInfo loanInfo)
        {
            List<LoanPaymentSchedule> paymentSchedules = new List<LoanPaymentSchedule>();

            double periodicRate = loanInfo.InterestRate / loanInfo.PaymentsPerYear;
            int totalPayments = loanInfo.LoanLife * loanInfo.PaymentsPerYear;

            double paymentAmount = (loanInfo.InitialAmount * periodicRate) /
                                   (1 - Math.Pow(1 + periodicRate, -totalPayments));

            double balance = loanInfo.InitialAmount;

            for (int paymentNumber = 1; paymentNumber <= totalPayments; paymentNumber++)
            {
                double interestPortion = balance * periodicRate;
                double principalPortion = paymentAmount - interestPortion;

                balance -= principalPortion;

                if (paymentNumber == totalPayments)
                {
                    principalPortion += balance;
                    paymentAmount = interestPortion + principalPortion;
                    balance = 0;
                }

                LoanPaymentSchedule paymentSchedule = new LoanPaymentSchedule
                {
                    PaymentNumber = paymentNumber,
                    PaymentDate = DateTime.Today.AddMonths(paymentNumber),
                    PaymentAmount = paymentAmount,
                    InterestPortion = interestPortion,
                    PrincipalPortion = principalPortion,
                    BalanceRemaining = balance
                };

                paymentSchedules.Add(paymentSchedule);
            }

            return paymentSchedules;
        }

        public class LoanInfo
        {
            public double InitialAmount { get; set; }
            public double InterestRate { get; set; }
            public int PaymentsPerYear { get; set; }
            public int LoanLife { get; set; }
            public List<LoanPaymentSchedule> PaymentSchedules { get; set; } = [];

            public string FormattedInterestRate
            {
                get
                {
                    return InterestRate.ToString("P1");
                }
            }

            public string FormattedInitialAmount
            {
                get
                {
                    return InitialAmount.ToString("C");
                }
            }
        }

        public class LoanPaymentSchedule
        {
            public int PaymentNumber { get; set; }
            public DateTime PaymentDate { get; set; }
            public double PaymentAmount { get; set; }
            public double InterestPortion { get; set; }
            public double PrincipalPortion { get; set; }
            public double BalanceRemaining { get; set; }

            public string FormattedPaymentAmount
            {
                get
                {
                    return PaymentAmount.ToString("C");
                }
            }

            public string FormattedInterestPortion
            {
                get
                {
                    return InterestPortion.ToString("C");
                }
            }

            public string FormattedPrincipalPortion
            {
                get
                {
                    return PrincipalPortion.ToString("C");
                }
            }

            public string FormattedBalanceRemaining
            {
                get
                {
                    return BalanceRemaining.ToString("C");
                }
            }
        }
    }
}