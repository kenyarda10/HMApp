namespace JCCCAppProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 64),
                        CompanyDescription = c.String(maxLength: 200),
                        EstablishmentDate = c.DateTime(),
                        CompanyWebsite = c.String(maxLength: 64),
                        EmployerID = c.Int(nullable: false),
                        IndustryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Employers", t => t.EmployerID, cascadeDelete: true)
                .ForeignKey("dbo.Industries", t => t.IndustryID, cascadeDelete: true)
                .Index(t => t.EmployerID)
                .Index(t => t.IndustryID);
            
            CreateTable(
                "dbo.CompanyLogoes",
                c => new
                    {
                        CompanyLogoID = c.Int(nullable: false, identity: true),
                        CompanyLogoName = c.String(maxLength: 64),
                        CompanyImageData = c.Binary(),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyLogoID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        EmployerID = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false),
                        EmployerImageData = c.Binary(),
                        EmployerImageMimeType = c.String(),
                        UserLogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployerID)
                .ForeignKey("dbo.UserLogs", t => t.UserLogID, cascadeDelete: true)
                .Index(t => t.UserLogID);
            
            CreateTable(
                "dbo.JobPostings",
                c => new
                    {
                        JobPostingID = c.Int(nullable: false, identity: true),
                        createdDate = c.DateTime(),
                        JobDescription = c.String(maxLength: 75),
                        JobTitle = c.String(maxLength: 64),
                        NumOpenings = c.Int(),
                        HoursPerWeek = c.Int(),
                        WageSalary = c.Decimal(precision: 18, scale: 2),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Qualifications = c.String(maxLength: 300),
                        ApplicationInstructions = c.String(maxLength: 100),
                        ApplicationWebsite = c.String(maxLength: 64),
                        ExpirationDate = c.DateTime(),
                        JobType = c.String(maxLength: 64),
                        IndustryID = c.Int(nullable: false),
                        EmployerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobPostingID)
                .ForeignKey("dbo.Employers", t => t.EmployerID, cascadeDelete: true)
                .ForeignKey("dbo.Industries", t => t.IndustryID, cascadeDelete: true)
                .Index(t => t.IndustryID)
                .Index(t => t.EmployerID);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        IndustryID = c.Int(nullable: false, identity: true),
                        IndustryName = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.IndustryID);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        UserLogID = c.Int(nullable: false, identity: true),
                        LastLoginDate = c.DateTime(),
                        LastApplyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserLogID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false),
                        StudentImageData = c.Binary(),
                        StudentImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.EducationDetails",
                c => new
                    {
                        EducationDetailID = c.Int(nullable: false, identity: true),
                        CertificateDegree = c.String(maxLength: 64),
                        Major = c.String(maxLength: 64),
                        InstitutionName = c.String(maxLength: 64),
                        StartDate = c.DateTime(),
                        CompletionDate = c.DateTime(),
                        Percentage = c.Int(nullable: false),
                        GPA = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EducationDetailID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.JobApplicationStatus",
                c => new
                    {
                        JobApplicationStatusID = c.Int(nullable: false, identity: true),
                        StatusDesc = c.String(maxLength: 64),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobApplicationStatusID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentUserLogs",
                c => new
                    {
                        Student_StudentID = c.Int(nullable: false),
                        UserLog_UserLogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentID, t.UserLog_UserLogID })
                .ForeignKey("dbo.Students", t => t.Student_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.UserLogs", t => t.UserLog_UserLogID, cascadeDelete: true)
                .Index(t => t.Student_StudentID)
                .Index(t => t.UserLog_UserLogID);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Address1", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address2", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zip", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhoneNumber2", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employers", "UserLogID", "dbo.UserLogs");
            DropForeignKey("dbo.StudentUserLogs", "UserLog_UserLogID", "dbo.UserLogs");
            DropForeignKey("dbo.StudentUserLogs", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.JobApplicationStatus", "StudentID", "dbo.Students");
            DropForeignKey("dbo.EducationDetails", "StudentID", "dbo.Students");
            DropForeignKey("dbo.JobPostings", "IndustryID", "dbo.Industries");
            DropForeignKey("dbo.Companies", "IndustryID", "dbo.Industries");
            DropForeignKey("dbo.JobPostings", "EmployerID", "dbo.Employers");
            DropForeignKey("dbo.Companies", "EmployerID", "dbo.Employers");
            DropForeignKey("dbo.CompanyLogoes", "CompanyID", "dbo.Companies");
            DropIndex("dbo.StudentUserLogs", new[] { "UserLog_UserLogID" });
            DropIndex("dbo.StudentUserLogs", new[] { "Student_StudentID" });
            DropIndex("dbo.JobApplicationStatus", new[] { "StudentID" });
            DropIndex("dbo.EducationDetails", new[] { "StudentID" });
            DropIndex("dbo.JobPostings", new[] { "EmployerID" });
            DropIndex("dbo.JobPostings", new[] { "IndustryID" });
            DropIndex("dbo.Employers", new[] { "UserLogID" });
            DropIndex("dbo.CompanyLogoes", new[] { "CompanyID" });
            DropIndex("dbo.Companies", new[] { "IndustryID" });
            DropIndex("dbo.Companies", new[] { "EmployerID" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "PhoneNumber2");
            DropColumn("dbo.AspNetUsers", "Zip");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address2");
            DropColumn("dbo.AspNetUsers", "Address1");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.StudentUserLogs");
            DropTable("dbo.RoleViewModels");
            DropTable("dbo.JobApplicationStatus");
            DropTable("dbo.EducationDetails");
            DropTable("dbo.Students");
            DropTable("dbo.UserLogs");
            DropTable("dbo.Industries");
            DropTable("dbo.JobPostings");
            DropTable("dbo.Employers");
            DropTable("dbo.CompanyLogoes");
            DropTable("dbo.Companies");
        }
    }
}
