namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedNameSendMedicine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Centers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                        Code = c.String(),
                        Password = c.String(),
                        Doctor_Id = c.Int(),
                        SendMedicine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Thanas", t => t.ThanaId, cascadeDelete: false)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .ForeignKey("dbo.SendMedicines", t => t.SendMedicine_Id)
                .Index(t => t.DistrictId)
                .Index(t => t.ThanaId)
                .Index(t => t.Doctor_Id)
                .Index(t => t.SendMedicine_Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Population = c.Int(nullable: false),
                        SendMedicine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SendMedicines", t => t.SendMedicine_Id)
                .Index(t => t.SendMedicine_Id);
            
            CreateTable(
                "dbo.Thanas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DistrictId = c.Int(nullable: false),
                        SendMedicine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.SendMedicines", t => t.SendMedicine_Id)
                .Index(t => t.DistrictId)
                .Index(t => t.SendMedicine_Id);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        TProcedure = c.String(nullable: false),
                        PDrugs = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CenterId = c.Int(nullable: false),
                        Name = c.String(),
                        Degree = c.String(),
                        Specialisation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenericName = c.String(nullable: false),
                        MgMl = c.Double(nullable: false),
                        SendMedicine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SendMedicines", t => t.SendMedicine_Id)
                .Index(t => t.SendMedicine_Id);
            
            CreateTable(
                "dbo.SendMedicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                        CenterId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thanas", "SendMedicine_Id", "dbo.SendMedicines");
            DropForeignKey("dbo.Medicines", "SendMedicine_Id", "dbo.SendMedicines");
            DropForeignKey("dbo.Districts", "SendMedicine_Id", "dbo.SendMedicines");
            DropForeignKey("dbo.Centers", "SendMedicine_Id", "dbo.SendMedicines");
            DropForeignKey("dbo.Centers", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Centers", "ThanaId", "dbo.Thanas");
            DropForeignKey("dbo.Thanas", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Centers", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Medicines", new[] { "SendMedicine_Id" });
            DropIndex("dbo.Thanas", new[] { "SendMedicine_Id" });
            DropIndex("dbo.Thanas", new[] { "DistrictId" });
            DropIndex("dbo.Districts", new[] { "SendMedicine_Id" });
            DropIndex("dbo.Centers", new[] { "SendMedicine_Id" });
            DropIndex("dbo.Centers", new[] { "Doctor_Id" });
            DropIndex("dbo.Centers", new[] { "ThanaId" });
            DropIndex("dbo.Centers", new[] { "DistrictId" });
            DropTable("dbo.SendMedicines");
            DropTable("dbo.Medicines");
            DropTable("dbo.Doctors");
            DropTable("dbo.Diseases");
            DropTable("dbo.Thanas");
            DropTable("dbo.Districts");
            DropTable("dbo.Centers");
        }
    }
}
