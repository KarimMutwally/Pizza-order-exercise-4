using FluentMigrator;

namespace Migrations
{
    [Migration(04)]
    public class _04_CreatePizzaToppingsTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("PizzaToppings")
                .WithColumn("PizzaId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Pizza", "Id")
                .WithColumn("ToppingId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Topping", "Id");
        }
    }
}
