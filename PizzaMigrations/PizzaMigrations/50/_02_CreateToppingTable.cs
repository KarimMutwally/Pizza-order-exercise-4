using FluentMigrator;

namespace Migrations
{
    [Migration(02)]
    public class _02_CreateToppingTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Topping")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("Price").AsDouble();
        }
    }
}