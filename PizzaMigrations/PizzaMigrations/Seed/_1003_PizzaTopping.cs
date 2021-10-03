using FluentMigrator;
using System.Collections.Generic;

namespace PizzaMigrations.Seed
{
    [Migration(1003)]
    public class _1003_PizzaTopping : AutoReversingMigration
    {
        public override void Up()
        {
            List<int> pizzaIds = new() { 1, 2, 3, 4 };
            List<List<int>> toppingIds = new() { new() { 6, 5 }, new() { 1, 5, 4}, new() { 8, 5, 2 }, new() { 3 } };
            for (int i = 0; i < pizzaIds.Count; i++)
            {
                foreach (int toppingId in toppingIds[i])
                {
                    Insert.IntoTable("PizzaToppings").Row(new
                    {
                        PizzaId = pizzaIds[i],
                        ToppingId = toppingId
                    });
                }
            }
        }
    }
}
