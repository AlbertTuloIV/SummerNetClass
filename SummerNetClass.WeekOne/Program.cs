// Albert Tulo 5/21/2026
// Week 1 A 

namespace PayrollProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Application to take user's name, pay rate, hours work and calculate their gross, taxes paid and net pay.
            Console.WriteLine("Welcome to Payroll Process.");
            Console.WriteLine("Please follow the prompts to calculate your pay.");
            Console.WriteLine();

            // declare variables
            string userName;
            double pay, hoursWorked, net, gross;
            double tax = 0.0495;

            // get user's name
            Console.WriteLine("Enter your Name: ");
            userName = Console.ReadLine();

            //initialize isRunning to true for loop

            bool isRunning = true;

            while (isRunning)
            {
                try
                {
                    // get hourly rate
                    Console.WriteLine("Enter your hourly rate (no special chars): $");
                    pay = double.Parse(Console.ReadLine());

                    // get hours worked.
                    Console.WriteLine("Enter your hours worked this week: ");
                    hoursWorked = double.Parse(Console.ReadLine());

                    Console.WriteLine("Calculating Pay...");
                    Console.WriteLine();

                    // Payroll calculations
                    gross = pay * hoursWorked;
                    tax = gross * tax;
                    net = gross - tax;

                    // format to monetary strings.
                    string formattedGross = gross.ToString("C");
                    string formattedTax = tax.ToString("C");
                    string formattedNet = net.ToString("C"); ;

                    // Final tabulated output
                    Console.WriteLine($"{"Name",-30} | {"Gross Pay",-15} | {"Income Tax 4.95%",-15} | {"Net Pay",15}");
                    Console.WriteLine($"{userName,-30} | {formattedGross,-15} | {formattedTax,-15} | {formattedNet,15}");

                    // set isRunning to false to exit loop 
                    isRunning = false;

                }
                catch (Exception ex)
                {
                    // Any error will get caught and restart to last place error happened. 
                    Console.WriteLine("An invalid value has been entered: " + ex);
                    Console.WriteLine("Please try again..");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Thank you for using Payroll Process");
        }
    }
}