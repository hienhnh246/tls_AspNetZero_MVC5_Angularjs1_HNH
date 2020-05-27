namespace triluatsoft.tls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HNH_Added_Phones_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HNHPhones",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Type = c.Byte(nullable: false),
                        Number = c.String(nullable: false, maxLength: 16),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HNHPersons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HNHPhones", "PersonId", "dbo.HNHPersons");
            DropIndex("dbo.HNHPhones", new[] { "PersonId" });
            DropTable("dbo.HNHPhones");
        }
    }
}
