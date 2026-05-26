// Albert Tulo 5/22/2026
// Week 1 B
namespace CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declarations for app use.
            List<Item> orderItems = new List<Item>();

            string borderLine = new string('=', 50);

            bool isRecording = true;
            bool firstRun = true;

            Console.WriteLine(borderLine);
            Console.WriteLine(FormattedLine("Welcome to The Coffee Shop"));
            Console.WriteLine(borderLine);

            // main pos system loop
            while (isRecording)
            {
                // first run of app, force user to add an item to the order
                int userChoice = 1;
                if (!firstRun)
                {
                    Console.WriteLine("What would you like to do? (1-5)");
                    Console.WriteLine("(1) - Add an Item");
                    Console.WriteLine("(2) - Remove an Item");
                    Console.WriteLine("(3) - View Current Items");
                    Console.WriteLine("(4) - CheckOut");
                    Console.WriteLine("(5) - Cancel");
                    try
                    {
                        userChoice = int.Parse(Console.ReadLine());
                        if (userChoice < 1 || userChoice > 5)
                        {
                            Console.WriteLine("Please select a number 1-5.");
                            userChoice = 0;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Please select a number 1-5: Exception: {ex.Message}");
                        break;
                    }
                }

                // switch cases for user main menu choice.
                switch (userChoice)
                {
                    // Add an item
                    case 1:
                        Item thisItem = new Item();
                        try
                        {
                            Console.WriteLine("Enter the name of the item: ");
                            thisItem.ItemName = Console.ReadLine();
                            Console.WriteLine($"Enter the price of the {thisItem.ItemName}: ");
                            thisItem.PricePerUnit = double.Parse(Console.ReadLine());
                            Console.WriteLine($"Enter the quantity of the {thisItem.ItemName}: ");
                            thisItem.ItemQuantity = int.Parse(Console.ReadLine());

                            Console.WriteLine("Adding item...");

                            orderItems.Add(thisItem);
                            if (firstRun)
                            {
                                firstRun = false;
                            }
                            Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Invalid entry, please try again: {ex.Message}");
                            Thread.Sleep(1000);
                            if (!firstRun)
                            {
                                firstRun = true;
                            }
                        }
                        break;

                    // Delete an item
                    case 2:
                        if (orderItems.Count > 1)
                        {
                            Console.WriteLine("-Delete an Item-");
                            Console.WriteLine($"{" ",-10}{"Item",-10} {"Quantity",-10} {"Price",-10} {"Total",-10}");
                            int itemNumber = 1;
                            foreach (var items in orderItems)
                            {
                                Console.WriteLine($"{itemNumber,-10} {items.ItemName,-10} {items.ItemQuantity,-10} {items.FormattedUnitPrice,-10} {items.FormattedTotalPrice,-10}");
                                itemNumber++;

                            }
                            Console.WriteLine($"Please Select an Item to delete: (enter 0 to cancel)");
                            int response = int.Parse(Console.ReadLine());
                            if (response == 0)
                            {
                                Console.WriteLine("Cancelling deletion of item...");
                                break;
                            }

                            if (response > 0 && response <= orderItems.Count)
                            {
                                Item toDelete = orderItems[response - 1];
                                Console.WriteLine($"Are you sure you want to delete: ");
                                Console.WriteLine($"{itemNumber,-10}: {toDelete.ItemName}?");
                                Console.WriteLine("type 'Y' or 'y' to confirm, enter anything to cancel:");
                                try
                                {
                                    string choice = Console.ReadLine().ToLower();
                                    if (choice == "n")
                                    {
                                        Console.WriteLine("Canceling deletion of item...");
                                        Thread.Sleep(1000);
                                        break;
                                    }

                                    if (choice == "y")
                                    {
                                        orderItems.Remove(toDelete);
                                        Console.Write("Item has been deleted...");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine($"Invalid option, please type 'y/n'");
                                    Thread.Sleep(1000);
                                    break;
                                }
                            }
                        }

                        if (orderItems.Count == 1)
                        {
                            Console.WriteLine("You cannot delete your last item, please add more to the order.");
                            Thread.Sleep(1000);
                            break;
                        }
                        Console.WriteLine("There are no items to delete, please add items to order.");
                        Thread.Sleep(1000);
                        break;

                    // View Current Items in order
                    case 3:
                        if (orderItems.Count > 0)
                        {
                            GetReceipt(orderItems, false);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("There are no items in the order to view..");
                            Console.WriteLine("Please add items to the order.");
                            Thread.Sleep(1000);
                        }
                        break;

                    // Checkout 
                    case 4:
                        if (orderItems.Count > 0)
                        {
                            GetReceipt(orderItems, true);
                            Thread.Sleep(1000);
                            isRecording = false;
                        }
                        else
                        {
                            Console.WriteLine("There are no items in the order, cannot create a receipt.");
                            Console.WriteLine("Please add items to create a receipt.");
                            Thread.Sleep(1000);
                        }
                        break;

                    // Cancel
                    case 5:
                        Console.WriteLine("Canceling...");
                        isRecording = false;
                        break;
                }
            }
            Thread.Sleep(1000);
            Console.WriteLine("Thank you for using the Coffee Shop System.");
        }

        // Method that takes the list of items in the order and checks to see if is receipt or not. 1 method to cover 2 cases. 
        private static void GetReceipt(List<Item> items, bool isReceipt)
        {
            string receiptBorder = new string('-', 50);
            double subTotal = 0.00;

            if (isReceipt)
            {
                Console.WriteLine("Receipt: ");
            }
            else
            {
                Console.WriteLine("Current Items: ");
            }

            Console.WriteLine(receiptBorder);
            Console.WriteLine($"{"Item",-10} {"Quantity",-10} {"Price",-10} {"Total",-10}");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.ItemName,-10} {item.ItemQuantity,-10} {item.FormattedUnitPrice,-10} {item.FormattedTotalPrice,-10}");
                subTotal += item.TotalItemPrice;
            }
            Console.WriteLine(receiptBorder);
            Console.WriteLine($"Subtotal: {subTotal.ToString("C"),0} ");
            Console.WriteLine($"Sales Tax (8%): {(subTotal * 0.08).ToString("C"),0}");
            Console.WriteLine($"Final Total: {(subTotal * 1.08).ToString("C"),0}");
        }

        // Simple formatted line for centered text
        private static string FormattedLine(string text)
        {
            int spaceBefore = (50 - text.Length) / 2;
            return new string(' ', spaceBefore) + text;
        }

        // model for the items to add for easy calling
        private class Item
        {
            public string ItemName { get; set; }
            public double PricePerUnit { get; set; }
            public int ItemQuantity { get; set; }

            public double TotalItemPrice
            {
                get
                {
                    return PricePerUnit * ItemQuantity;
                }
            }

            public string FormattedUnitPrice
            {
                get
                {
                    return PricePerUnit.ToString("C");
                }
            }

            public string FormattedTotalPrice
            {
                get
                {
                    return TotalItemPrice.ToString("C");
                }
            }
        }
    }
}