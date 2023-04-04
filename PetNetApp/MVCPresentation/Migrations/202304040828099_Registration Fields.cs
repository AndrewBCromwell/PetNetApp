namespace MVCPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PronounId", c => c.String());
            AddColumn("dbo.AspNetUsers", "ShelterId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressTwo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AddressTwo");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "ShelterId");
            DropColumn("dbo.AspNetUsers", "PronounId");
        }
    }
}
