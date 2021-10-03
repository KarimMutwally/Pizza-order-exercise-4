using FluentMigrator;
using System.Collections.Generic;

namespace PizzaMigrations.Seed
{
    [Migration(1002)]
    public class _1002_Pizzas : AutoReversingMigration
    {
        public override void Up()
        {
            List<string> pizzaNames = new() { "Pepperoni", "Chicken Ranch", "Sea Food", "Margherita"};
            foreach (var pizzaName in pizzaNames)
            {
                Insert.IntoTable("Pizza").Row(new
                {
                    Name = pizzaName,
                    IsCustomed = false
                });
            }
        }
    }
}
