using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(3)]
    public class StudentTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("3_student.sql");
        }

        public override void Down()
        {
        }
    }
}
