using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(4)]
    public class ProjectTable : Migration
    { 
        public override void Up()
        {
            Execute.EmbeddedScript("4_project.sql");
        }

        public override void Down()
        {
        }
    }
}
