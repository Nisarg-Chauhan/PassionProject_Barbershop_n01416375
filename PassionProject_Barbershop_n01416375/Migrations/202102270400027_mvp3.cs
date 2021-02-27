namespace PassionProject_Barbershop_n01416375.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mvp3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Appointments", new[] { "customerid" });
            DropIndex("dbo.Appointments", new[] { "barberid" });
            AddColumn("dbo.Barbers", "bFirstName", c => c.String());
            AddColumn("dbo.Barbers", "bLastName", c => c.String());
            AddColumn("dbo.Barbers", "bEmail", c => c.String());
            AddColumn("dbo.Barbers", "bContactNo", c => c.String());
            CreateIndex("dbo.Appointments", "customerId");
            CreateIndex("dbo.Appointments", "barberId");
            DropColumn("dbo.Barbers", "firstname");
            DropColumn("dbo.Barbers", "lastname");
            DropColumn("dbo.Barbers", "email");
            DropColumn("dbo.Barbers", "contactno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Barbers", "contactno", c => c.String());
            AddColumn("dbo.Barbers", "email", c => c.String());
            AddColumn("dbo.Barbers", "lastname", c => c.String());
            AddColumn("dbo.Barbers", "firstname", c => c.String());
            DropIndex("dbo.Appointments", new[] { "barberId" });
            DropIndex("dbo.Appointments", new[] { "customerId" });
            DropColumn("dbo.Barbers", "bContactNo");
            DropColumn("dbo.Barbers", "bEmail");
            DropColumn("dbo.Barbers", "bLastName");
            DropColumn("dbo.Barbers", "bFirstName");
            CreateIndex("dbo.Appointments", "barberid");
            CreateIndex("dbo.Appointments", "customerid");
        }
    }
}
