namespace PassionProject_Barbershop_n01416375.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mvp1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "appointmentDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Barbers", "firstname", c => c.String());
            AddColumn("dbo.Barbers", "lastname", c => c.String());
            AddColumn("dbo.Barbers", "email", c => c.String());
            AddColumn("dbo.Barbers", "contactno", c => c.String());
            AddColumn("dbo.Barbers", "appointmentid", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "firstname", c => c.String());
            AddColumn("dbo.Customers", "lastname", c => c.String());
            AddColumn("dbo.Customers", "email", c => c.String());
            AddColumn("dbo.Customers", "contactno", c => c.String());
            AddColumn("dbo.Customers", "appointmentid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "appointmentid");
            DropColumn("dbo.Customers", "contactno");
            DropColumn("dbo.Customers", "email");
            DropColumn("dbo.Customers", "lastname");
            DropColumn("dbo.Customers", "firstname");
            DropColumn("dbo.Barbers", "appointmentid");
            DropColumn("dbo.Barbers", "contactno");
            DropColumn("dbo.Barbers", "email");
            DropColumn("dbo.Barbers", "lastname");
            DropColumn("dbo.Barbers", "firstname");
            DropColumn("dbo.Appointments", "appointmentDay");
        }
    }
}
