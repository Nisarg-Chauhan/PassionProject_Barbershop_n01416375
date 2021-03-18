namespace PassionProject_Barbershop_n01416375.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customers2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AppointmentDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "AppointmentDate");
        }
    }
}
