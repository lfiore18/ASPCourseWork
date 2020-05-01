namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTypoOnSignUpFeee : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.MembershipTypes", "SignUpFeee", "SignUpFee");
        }
        
        public override void Down()
        {

        }
    }
}
