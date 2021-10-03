using FluentMigrator;

namespace Migrations
{
    [Migration(03)]
    public class _03_CreateOrderTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Order")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString();
        }
    }
}
