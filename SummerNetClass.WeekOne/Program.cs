// Albert Tulo 5/21/2026
// Week 1 A 
using System.Runtime.InteropServices;

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

            string userName;
            double pay, hoursWorked, net, gross;
            double tax = 0.0495;
            

            Console.WriteLine("Enter your Name: ");
            userName = Console.ReadLine();

            while (true){
                try
                {
                    Console.WriteLine("Enter your hourly rate (no special chars): $");
                    pay = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your hours worked this week: ");
                    hoursWorked = double.Parse(Console.ReadLine());

                    Console.WriteLine("Calculating Pay...");
                    Console.WriteLine();

                    gross = pay * hoursWorked;
                    tax = gross * tax;
                    net = gross - tax;

                    Console.WriteLine("Your Income:");
                    Console.WriteLine($"Gross: {gross:C}");
                    Console.WriteLine($"Illinois Income Tax 4.95%: {tax:C}");
                    Console.WriteLine($"Net Pay: {net:C}");

                }catch(Exception ex)
                {
                    Console.WriteLine("An invalid value has been entered: " + ex);
                }
            }
            

        }
    }
}