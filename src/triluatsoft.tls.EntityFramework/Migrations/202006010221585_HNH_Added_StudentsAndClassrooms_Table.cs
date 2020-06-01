namespace triluatsoft.tls.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class HNH_Added_StudentsAndClassrooms_Table : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HNHStudentsOfClassroom", newName: "HNHStudentsAndClassrooms");
            AlterTableAnnotations(
                "dbo.HNHStudentsAndClassrooms",
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_StudentAndClassroom_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_StudentOfClassroom_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
        
        public override void Down()
        {
            AlterTableAnnotations(
                "dbo.HNHStudentsAndClassrooms",
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_StudentAndClassroom_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_StudentOfClassroom_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            RenameTable(name: "dbo.HNHStudentsAndClassrooms", newName: "HNHStudentsOfClassroom");
        }
    }
}
