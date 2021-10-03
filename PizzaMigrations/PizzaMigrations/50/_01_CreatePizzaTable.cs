using FluentMigrator;

namespace Migrations
{
    [Migration(01)]
    public class _01_CreatePizzaTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Pizza")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("IsCustomed").AsBoolean();
        }
    }
}