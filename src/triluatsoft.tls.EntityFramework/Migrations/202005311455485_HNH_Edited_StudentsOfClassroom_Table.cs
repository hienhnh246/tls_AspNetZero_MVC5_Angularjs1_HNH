namespace triluatsoft.tls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HNH_Edited_StudentsOfClassroom_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HNHStudentsOfClassroom", "StudentOfClassroom_Id", "dbo.HNHStudentsOfClassroom");
            DropIndex("dbo.HNHStudentsOfClassroom", new[] { "StudentOfClassroom_Id" });
            DropColumn("dbo.HNHStudentsOfClassroom", "StudentOfClassroom_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HNHStudentsOfClassroom", "StudentOfClassroom_Id", c => c.Int());
            CreateIndex("dbo.HNHStudentsOfClassroom", "StudentOfClassroom_Id");
            AddForeignKey("dbo.HNHStudentsOfClassroom", "StudentOfClassroom_Id", "dbo.HNHStudentsOfClassroom", "Id");
        }
    }
}
