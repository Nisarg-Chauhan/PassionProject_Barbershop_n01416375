namespace PassionProject_Barbershop_n01416375.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointments : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Appointments", new[] { "customerId" });
            DropIndex("dbo.Appointments", new[] { "barberId" });
            CreateIndex("dbo.Appointments", "CustomerId");
            CreateIndex("dbo.Appointments", "BarberId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Appointments", new[] { "BarberId" });
            DropIndex("dbo.Appointments", new[] { "CustomerId" });
            CreateIndex("dbo.Appointments", "barberId");
            CreateIndex("dbo.Appointments", "customerId");
        }
    }
}
