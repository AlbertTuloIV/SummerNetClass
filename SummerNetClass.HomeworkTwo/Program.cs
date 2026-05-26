// Albert Tulo IV
// 5/26/2026
// CPSC 23000, Homework 2 Tax Table Problem

namespace TaxTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter your taxable income: ");
                double income = double.Parse(Console.ReadLine());

                if (income < 0)
                {
                    Console.WriteLine("Income cannot be less than 0.");
                }
                else
                {
                    Console.WriteLine("Calculating...");
                    Thread.Sleep(1000);
                    double taxes = CalculateTaxes(income);
                    Console.WriteLine($"Taxes payable: {taxes:C}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Please input a proper decimal: {ex.Message}");
            }
        }

        private static double CalculateTaxes(double income)
        {
            double totalTaxes = 0.00;

            foreach (var bracket in TaxBrackets)
            {
                if (income >= bracket.FromAmount && income <= bracket.ToAmount)
                {
                    if (bracket.CentsPerDollar != 0)
                    {
                        double dollarsOver = income - bracket.FromAmount;
                        totalTaxes += (dollarsOver * bracket.CentsPerDollar);
                    }
                    if (bracket.BaseTax != 0)
                    {
                        totalTaxes += bracket.BaseTax;
                    }
                }
            }

            return totalTaxes;
        }

        private static List<TaxBracket> TaxBrackets = new List<TaxBracket>
        {
            new TaxBracket { FromAmount = 1.00, ToAmount = 4461.99, BaseTax = 0, CentsPerDollar = 0 },
            new TaxBracket { FromAmount = 4462.00, ToAmount = 17893.99, BaseTax = 0, CentsPerDollar = 0.30 },
            new TaxBracket { FromAmount = 17894.00, ToAmount = 29499.99, BaseTax = 4119.00, CentsPerDollar = 0.35 },
            new TaxBracket { FromAmount = 29500.00, ToAmount = 45787.99, BaseTax = 8656.00, CentsPerDollar = 0.46 },
            new TaxBracket { FromAmount = 45788.00, ToAmount = double.MaxValue, BaseTax = 11179.00, CentsPerDollar = 0.60 }
        };

        private class TaxBracket
        {
            public double FromAmount { get; set; }
            public double ToAmount { get; set; }
            public double BaseTax { get; set; }
            public double CentsPerDollar { get; set; }
        }
    }
}