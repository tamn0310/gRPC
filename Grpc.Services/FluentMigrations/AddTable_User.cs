using FluentMigrator;

namespace Grpc.Services.FluentMigrations
{
    [Migration(202103022116000)]
    public class AddTable_User : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("first_name").AsString().NotNullable()
                .WithColumn("last_name").AsString().NotNullable()
                .WithColumn("phone").AsString().Nullable()
                .WithColumn("email").AsString().Nullable()
                .WithColumn("created_at").AsInt64().NotNullable()
                .WithColumn("created_by").AsString().NotNullable()
                .WithColumn("updated_at").AsInt64().Nullable()
                .WithColumn("updated_by").AsString().Nullable()
                .WithColumn("is_deleted").AsBoolean().WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Table("users");
        }
    }
}