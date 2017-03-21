namespace coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assessments",
                c => new
                    {
                        AssessmentID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.AssessmentID);
            
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CourdeworkMimeType = c.String(),
                        CourseworkData = c.Binary(),
                    })
                .PrimaryKey(t => t.StudentID);  
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentModels");
            DropTable("dbo.Assessments");
        }
    }
}
