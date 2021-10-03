using FluentMigrator;
using System.Collections.Generic;

namespace PizzaMigrations.Seed
{
    [Migration(1001)]
    public class _1001_Toppings : AutoReversingMigration
    {
        public override void Up()
        {
            List<string> toppingNames = new() { "Chicken", "Calamari", "Extra cheese", "Ranch", "Cheese", "Pepperoni", "Barbeque", "Shrimp", "Sausage" };
            List<double> toppingPrices = new() { 25, 30, 30, 5, 15, 25, 5, 40, 25 };
            for (int i = 0; i < toppingNames.Count; i++)
            {
                Insert.IntoTable("Topping").Row(new
                {
                    Name = toppingNames[i],
                    Price = toppingPrices[i]
                });
            }
        }
    }
}
