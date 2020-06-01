namespace triluatsoft.tls.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class HNH_Added_StudentsOfClassroom_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HNHStudentsOfClassroom",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassroomId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        StudentOfClassroom_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StudentOfClassroom_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HNHClassrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.HNHStudents", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.HNHStudentsOfClassroom", t => t.StudentOfClassroom_Id)
                .Index(t => t.ClassroomId)
                .Index(t => t.StudentId)
                .Index(t => t.StudentOfClassroom_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HNHStudentsOfClassroom", "StudentOfClassroom_Id", "dbo.HNHStudentsOfClassroom");
            DropForeignKey("dbo.HNHStudentsOfClassroom", "StudentId", "dbo.HNHStudents");
            DropForeignKey("dbo.HNHStudentsOfClassroom", "ClassroomId", "dbo.HNHClassrooms");
            DropIndex("dbo.HNHStudentsOfClassroom", new[] { "StudentOfClassroom_Id" });
            DropIndex("dbo.HNHStudentsOfClassroom", new[] { "StudentId" });
            DropIndex("dbo.HNHStudentsOfClassroom", new[] { "ClassroomId" });
            DropTable("dbo.HNHStudentsOfClassroom",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StudentOfClassroom_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
