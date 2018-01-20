namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoterIdTypeChangedIntoint64AndnumberofServiceGiveIsAddedInTreatment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "NumberTimeServiceGiven", c => c.Int(nullable: false));
            AlterColumn("dbo.Treatments", "VoterIdNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatments", "VoterIdNo", c => c.Int(nullable: false));
            DropColumn("dbo.Treatments", "NumberTimeServiceGiven");
        }
    }
}
