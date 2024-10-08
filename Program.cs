using System;

class VendingMachine
{
    static void Main()
    {
       
        string[] items = { "Soda", "Chips", "Candy", "Juice", "Chocolate" };
        double[] prices = { 20.00, 15.00, 2.00, 25.00, 45.00 };
        
        
        DisplayMenu(items, prices);

        while (true)
        {
            Console.WriteLine("Please enter the code of the item you want to purchase (or type 'exit' to quit):");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Thank you for using the vending machine. Goodbye!");
                break;
            }

           
            if (int.TryParse(input, out int choice) && choice > 0 && choice <= items.Length)
            {
                choice--; 
                double price = prices[choice];
                double moneyInserted = 0;

                Console.WriteLine($"You selected {items[choice]} which costs PHP {price:0.00}.");
                Console.WriteLine("Please insert money:");

                
                while (moneyInserted < price)
                {
                    double insertedAmount;
                    if (double.TryParse(Console.ReadLine(), out insertedAmount) && insertedAmount > 0)
                    {
                        moneyInserted += insertedAmount;
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please insert a valid amount.");
                        continue;
                    }

                    if (moneyInserted < price)
                    {
                        Console.WriteLine($"Insufficient funds. Please insert additional PHP {price - moneyInserted:0.00}.");
                    }
                }

                
                double change = moneyInserted - price;
                Console.WriteLine($"Dispensing {items[choice]}.");

               
                if (change > 0)
                {
                    DisplayChange(change);
                }
                else
                {
                    Console.WriteLine("No change to return.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a valid item code.");
            }
        }
    }

    static void DisplayMenu(string[] items, double[] prices)
    {
        Console.WriteLine("Available items:");
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]} - PHP {prices[i]:0.00}");
        }
    }

    static void DisplayChange(double change)
    {
        Console.WriteLine($"Your change is PHP {change:0.00}. Here's your change in denominations:");

        int[] denominations = { 1000, 500, 200, 100, 50, 20, 10, 5, 1 };
        foreach (var denomination in denominations)
        {
            int count = (int)(change / denomination);
            if (count > 0)
            {
                Console.WriteLine($"{count} x PHP {denomination}");
                change -= count * denomination;
            }
        }
    }
}
