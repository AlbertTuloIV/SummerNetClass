// Albert Tulo IV
// 6/5/2026
// CPSC 23000, Programming Assignment 3

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace OrderMenu
{
    internal class Program
    {
        struct CustomerSale
        {
            public int OrderId;
            public string Country;
            public string OrderDate;
            public string SalesRep;
            public string Shipper;
            public string Category;
            public double UnitPrice;
            public int Quantity;
            public double Discount;
            public double Freight;
        }
        static void Main(string[] args)
        {
            List<CustomerSale> sales = new List<CustomerSale>();

            LoadRecords(sales, "../../../custsale.txt");

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("CUSTOMER SALES MENU");
                Console.WriteLine("===================");
                Console.WriteLine("1. Display all records");
                Console.WriteLine("2. Delete first record");
                Console.WriteLine("3. Sum first numeric field");
                Console.WriteLine("4. Find largest value");
                Console.WriteLine("5. Sort by name ascending");
                Console.WriteLine("6. Sort by numeric field descending");
                Console.WriteLine("7. Print report file");
                Console.WriteLine("8. Delete using primary key");
                Console.WriteLine("9. Add new record");
                Console.WriteLine("0. Quit");
                Console.WriteLine();

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        DisplayRecords(sales);
                        break;

                    case "2":
                        DeleteFirstRecord(sales);
                        break;

                    case "3":
                        double total = SumQuantity(sales);
                        Console.WriteLine($"Total Quantity: {total}");
                        break;

                    case "4":
                        int location = FindLargestUnitPrice(sales);

                        if (location >= 0)
                        {
                            Console.WriteLine("Record with largest unit price:");
                            PrintHeadings();
                            PrintRecord(sales[location]);
                        }
                        else
                        {
                            Console.WriteLine("No records found.");
                        }
                        break;

                    case "5":
                        SortBySalesPerson(sales);
                        Console.WriteLine("Records sorted by salesperson ascending.");
                        break;

                    case "6":
                        SortByUnitPriceDescending(sales);
                        Console.WriteLine("Records sorted by unit price descending.");
                        break;

                    case "7":
                        PrintReport(sales, "../../../report.txt");
                        Console.WriteLine("Report file created.");
                        break;

                    case "8":
                        Console.Write("Enter Order ID to delete: ");
                        int deleteKey = int.Parse(Console.ReadLine());
                        DeleteUsingKey(sales, deleteKey);
                        break;

                    case "9":
                        AddNewRecord(sales);
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                }
            }
        }

        static void AddNewRecord(List<CustomerSale> sales)
        {
            Console.Write("Enter new Order ID: ");
            int orderId = int.Parse(Console.ReadLine());

            int location = FindRecordUsingKey(sales, orderId);

            if (location != -1)
            {
                Console.WriteLine("That Order ID is already in use.");
                return;
            }

            CustomerSale newSale = new CustomerSale();

            newSale.OrderId = orderId;

            Console.Write("Enter Country: ");
            newSale.Country = Console.ReadLine();

            Console.Write("Enter Order Date: ");
            newSale.OrderDate = Console.ReadLine();

            Console.Write("Enter Salesperson: ");
            newSale.SalesRep = Console.ReadLine();

            Console.Write("Enter Shipper: ");
            newSale.Shipper = Console.ReadLine();

            Console.Write("Enter Category: ");
            newSale.Category = Console.ReadLine();

            Console.Write("Enter Unit Price: ");
            newSale.UnitPrice = double.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            newSale.Quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter Discount: ");
            newSale.Discount = double.Parse(Console.ReadLine());

            Console.Write("Enter Freight: ");
            newSale.Freight = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("New record preview:");
            PrintHeadings();
            PrintRecord(newSale);

            Console.WriteLine();
            Console.Write("Add this record? Y/N: ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                sales.Add(newSale);
                Console.WriteLine("New record added.");
            }
            else
            {
                Console.WriteLine("Add canceled.");
            }
        }

        static void DeleteUsingKey(List<CustomerSale> sales, int key)
        {
            int location = FindRecordUsingKey(sales, key);

            if (location == -1)
            {
                Console.WriteLine("Record was not found.");
                return;
            }

            Console.WriteLine("Record found:");
            PrintHeadings();
            PrintRecord(sales[location]);

            Console.WriteLine();
            Console.Write("Are you sure you want to delete this record? Y/N: ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                DeleteRecordAtAddressLocation(sales, location);
                Console.WriteLine("Record was deleted.");
            }
            else
            {
                Console.WriteLine("Delete canceled.");
            }
        }

        static void DeleteRecordAtAddressLocation(List<CustomerSale> sales, int location)
        {
            if (location >= 0 && location < sales.Count)
            {
                sales.RemoveAt(location);
            }
        }

        static int FindRecordUsingKey(List<CustomerSale> sales, int key)
        {
            for (int i = 0; i < sales.Count; i++)
            {
                if (sales[i].OrderId == key)
                {
                    return i;
                }
            }

            return -1;
        }

        static void PrintReport(List<CustomerSale> sales, string filePath)
        {
            using StreamWriter writer = new StreamWriter(filePath);

            string title = "CUSTOMER SALES REPORT";
            writer.WriteLine(title.PadLeft((110 + title.Length) / 2));
            writer.WriteLine();
            writer.WriteLine($"{"ID",-8} {"Country",-12} {"Date",-10} {"Salesperson",-12} {"Shipper",-18} {"Category",-15} {"Price",8} {"Qty",5} {"Disc",6} {"Freight",8}"); 
            
            writer.WriteLine(new string('-', 110));

            foreach (CustomerSale sale in sales)
            {
                writer.WriteLine($"{sale.OrderId,-8} {sale.Country,-12} {sale.OrderDate,-10} {sale.SalesRep,-12} {sale.Shipper,-18} {sale.Category,-15} {sale.UnitPrice,8:F2} {sale.Quantity,5} {sale.Discount,6:F2} {sale.Freight,8:F2}");
            }
        }

        static void SortByUnitPriceDescending(List<CustomerSale> sales)
        {
            sales.Sort((a, b) => b.UnitPrice.CompareTo(a.UnitPrice));
        }

        static void SortBySalesPerson(List<CustomerSale> sales)
        {
            sales.Sort((a, b) => a.SalesRep.CompareTo(b.SalesRep));
        }

        static int FindLargestUnitPrice(List<CustomerSale> sales)
        {
            if (sales.Count == 0)
            {
                return -1;
            }

            int largestLocation = 0;

            for (int i = 1; i < sales.Count; i++)
            {
                if (sales[i].UnitPrice > sales[largestLocation].UnitPrice)
                {
                    largestLocation = i;
                }
            }

            return largestLocation;
        }

        static double SumQuantity(List<CustomerSale> sales)
        {
            double total = 0;
            foreach (CustomerSale sale in sales)
            {
                total += sale.Quantity;
            }

            return total;
        }

        static void DeleteFirstRecord(List<CustomerSale> sales)
        {
            if (sales.Count > 0)
            {
                sales.RemoveAt(0);
                Console.WriteLine("The first record was deleted.");
            }
            else
            {
                Console.WriteLine("there are no records to delete.");
            }
        }

        static void LoadRecords(List<CustomerSale> sales, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                CustomerSale sale = new CustomerSale();

                sale.OrderId = int.Parse(parts[0].Trim());
                sale.Country = parts[1].Trim();
                sale.OrderDate = parts[2].Trim();
                sale.SalesRep = parts[3].Trim();
                sale.Shipper = parts[4].Trim();
                sale.Category = parts[5].Trim();
                sale.UnitPrice = double.Parse(parts[6].Trim(), CultureInfo.InvariantCulture);
                sale.Quantity = int.Parse(parts[7].Trim());
                sale.Discount = double.Parse(parts[8].Trim(), CultureInfo.InvariantCulture);
                sale.Freight = double.Parse(parts[9].Trim(), CultureInfo.InvariantCulture);

                sales.Add(sale);
            }
        }

        static void DisplayRecords(List<CustomerSale> sales)
        {
            PrintHeadings();

            foreach (CustomerSale sale in sales)
            {
                PrintRecord(sale);
            }
        }

        static void PrintHeadings()
        {
            Console.WriteLine($"{"ID",-8} {"Country",-12} {"Date",-10} {"SalesRep",-12} {"Shipper",-18} {"Category",-15} {"Price",8} {"Qty",5} {"Disc",6} {"Freight",8}");
        }

        static void PrintRecord(CustomerSale sale)
        {
            Console.WriteLine(
                $"{sale.OrderId,-8} {sale.Country,-12} {sale.OrderDate,-10} {sale.SalesRep,-12} {sale.Shipper,-18} {sale.Category,-15} {sale.UnitPrice,8:F2} {sale.Quantity,5} {sale.Discount,6:F2} {sale.Freight,8:F2}");
        }
    }
}