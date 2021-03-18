namespace PassionProject_Barbershop_n01416375.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointments3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "BarberId", "dbo.Barbers");
            DropForeignKey("dbo.Appointments", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Appointments", new[] { "CustomerId" });
            DropIndex("dbo.Appointments", new[] { "BarberId" });
            AlterColumn("dbo.Appointments", "CustomerId", c => c.Int());
            AlterColumn("dbo.Appointments", "BarberId", c => c.Int());
            CreateIndex("dbo.Appointments", "CustomerId");
            CreateIndex("dbo.Appointments", "BarberId");
            AddForeignKey("dbo.Appointments", "BarberId", "dbo.Barbers", "barberId");
            AddForeignKey("dbo.Appointments", "CustomerId", "dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Appointments", "BarberId", "dbo.Barbers");
            DropIndex("dbo.Appointments", new[] { "BarberId" });
            DropIndex("dbo.Appointments", new[] { "CustomerId" });
            AlterColumn("dbo.Appointments", "BarberId", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "BarberId");
            CreateIndex("dbo.Appointments", "CustomerId");
            AddForeignKey("dbo.Appointments", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "BarberId", "dbo.Barbers", "barberId", cascadeDelete: true);
        }
    }
}
