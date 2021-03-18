namespace PassionProject_Barbershop_n01416375.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointments2 : DbMigration
    {
        public override void Up()
        {

            AlterColumn("dbo.Appointments", "AppointmentDay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "AppointmentDay", c => c.DateTime(nullable: false));
        }
    }
}




