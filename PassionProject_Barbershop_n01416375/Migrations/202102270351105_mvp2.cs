namespace PassionProject_Barbershop_n01416375.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mvp2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "customerid", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "barberid", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "customerid");
            CreateIndex("dbo.Appointments", "barberid");
            AddForeignKey("dbo.Appointments", "barberid", "dbo.Barbers", "barberId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "customerid", "dbo.Customers", "customerId", cascadeDelete: true);
            DropColumn("dbo.Barbers", "appointmentid");
            DropColumn("dbo.Customers", "appointmentid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "appointmentid", c => c.Int(nullable: false));
            AddColumn("dbo.Barbers", "appointmentid", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointments", "customerid", "dbo.Customers");
            DropForeignKey("dbo.Appointments", "barberid", "dbo.Barbers");
            DropIndex("dbo.Appointments", new[] { "barberid" });
            DropIndex("dbo.Appointments", new[] { "customerid" });
            DropColumn("dbo.Appointments", "barberid");
            DropColumn("dbo.Appointments", "customerid");
        }
    }
}
