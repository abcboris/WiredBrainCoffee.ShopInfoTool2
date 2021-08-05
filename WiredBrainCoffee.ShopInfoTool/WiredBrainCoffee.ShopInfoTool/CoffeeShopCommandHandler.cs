using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.DataAccess.Model;

namespace WiredBrainCoffee.ShopInfoTool
{
    internal class CoffeeShopCommandHandler: IHelpCommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;
        private string line;

        public CoffeeShopCommandHandler(IEnumerable<CoffeeShop> coffeeShops, string line)
        {
            this.coffeeShops = coffeeShops;
            this.line = line;
        }

        public void HandleCommand()
        {
            var foundCoffeeShops = coffeeShops
                 .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase)).ToList();

            if (foundCoffeeShops.Count == 0)
            {
                Console.WriteLine($"> Command '{line}' not found");
            }
            else if (foundCoffeeShops.Count == 1)
            {
                var coffeeShop = foundCoffeeShops.SingleOrDefault();
                Console.WriteLine($"> Location {coffeeShop.Location}");
                Console.WriteLine($"> Beans in Stock {coffeeShop.BeansInStockInKg.ToString()}");
            }
            else
            {
                Console.WriteLine($"> Multiple matching coffee shop commands found ");
                foreach (var coffeeType in foundCoffeeShops)
                {
                    Console.WriteLine($"> {coffeeType.Location}");
                }
            }
        }
    }
}