namespace CrudWebApiAngularJs.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToEmployeeEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Age", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Age");
        }
    }
}
