// Albert Tulo IV
// CPSC 23000
// Programming Assignment # 1 Credit Card Issuer

namespace CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userPoints = 0;

            Console.WriteLine("Thank you for choosing .NET Credit Services");

            Wait();

            Console.WriteLine("Please enter your name: ");

            string name = Console.ReadLine();

            Console.WriteLine("Thinking...");

            Wait();

            try
            {
                Console.WriteLine($"Hello, {name}, Please enter your age: ");

                userPoints += AgeFactor(int.Parse(Console.ReadLine()));

                Wait();

                Console.WriteLine($"{name}, please enter the years spent at the current address: ");

                userPoints += CurrentAddressFactor(int.Parse(Console.ReadLine()));

                Wait();

                Console.WriteLine($"{name}, please enter your Annual Income: (no $ sign)");

                userPoints += AnnualIncomeFactor(int.Parse(Console.ReadLine()));

                Wait();

                Console.WriteLine($"{name}, please enter years at the same job: ");

                userPoints += JobTimeFactor(int.Parse(Console.ReadLine()));

                Wait();

                Console.WriteLine("Thank you, calculating your credit limit...");

                Wait();

                IssueCard(userPoints);

                Wait();

                Console.WriteLine("Thank you for using .NET Credit Services.");

                Wait();

                Console.WriteLine("Goodbye.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An input was invalid. Please try again: {ex.Message}");
            }


        }

        private static void IssueCard(int points)
        {
            if (points <= 20)
            {
                Console.WriteLine("No Card Issued.");
            }

            if (points >= 21 && points <= 35)
            {
                Console.WriteLine("Card Issued with $500 credit limit.");
            }

            if (points >= 36 && points <= 60)
            {
                Console.WriteLine("Card Issued with $2000 credit limit.");
            }

            if (points >= 61)
            {
                Console.WriteLine("Card Issued with $5000 credit limit.");
            }
        }

        private static void Wait()
        {
            Thread.Sleep(500);
        }

        private static int AgeFactor(int age)
        {
            if (age <= 20)
            {
                return -10;
            }

            if (age >= 21 && age <= 30)
            {
                return 0;
            }

            if (age >= 31 && age <= 50)
            {
                return 20;
            }

            return 25;
        }

        private static int CurrentAddressFactor(int years)
        {
            if (years < 1)
            {
                return -5;
            }

            if (years >= 1 && years <= 3)
            {
                return 5;
            }

            if (years >= 4 && years <= 8)
            {
                return 12;
            }

            return 20;
        }

        private static int AnnualIncomeFactor(int income)
        {
            if (income <= 15000)
            {
                return 0;
            }

            if (income >= 15001 && income <= 25000)
            {
                return 12;
            }

            if (income >= 25001 && income <= 40000)
            {
                return 24;
            }

            return 30;
        }

        private static int JobTimeFactor(int experience)
        {
            if (experience < 2)
            {
                return -4;
            }

            if (experience >= 2 && experience <= 4)
            {
                return 8;
            }

            return 15;
        }
    }
}