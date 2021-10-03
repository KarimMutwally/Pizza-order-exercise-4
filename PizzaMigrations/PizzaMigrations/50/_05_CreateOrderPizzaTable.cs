using FluentMigrator;

namespace Migrations
{
    [Migration(05)]
    public class _05_CreateOrderPizzaTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("OrderPizza")
                .WithColumn("PizzaId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Pizza", "Id")
                .WithColumn("OrderId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Order", "Id")
                .WithColumn("Size").AsString();
        }
    }
}
