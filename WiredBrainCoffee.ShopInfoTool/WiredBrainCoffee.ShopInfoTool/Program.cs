using System;
using System.Linq;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffee.ShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee - Shop Info Tool!");

            Console.WriteLine("Write 'help' to list available coffee shop commands, " +
              "write 'quit' to exit application and here is a message from the first user addded ");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();


                //@@@BorisTest Below is the same implementation the commented once is much better
                //it is readable and more convenient the short one uncommented looks like a shit just keep it for now 
                var commandHandler = string.Equals("help", line, StringComparison.OrdinalIgnoreCase)
                    ? new HelpCommandHandler(coffeeShops) as IHelpCommandHandler
                    : new CoffeeShopCommandHandler(coffeeShops, line);
                commandHandler.HandleCommand();


                //IHelpCommandHandler commandHandler;
                //if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                //{
                //    commandHandler = new HelpCommandHandler(coffeeShops);
                //}
                //else {
                //    commandHandler = new CoffeeShopCommandHandler(coffeeShops, line);
                //}
                //commandHandler.HandleCommand();
            }

        }
    }
}
