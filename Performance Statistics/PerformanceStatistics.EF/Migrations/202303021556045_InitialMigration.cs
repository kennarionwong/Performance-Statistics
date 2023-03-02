namespace PerformanceStatistics.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ObjectID = c.Int(nullable: false),
                        Value = c.Boolean(nullable: false),
                        ValueStamp = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObjectValues", t => t.ObjectID, cascadeDelete: true)
                .Index(t => t.ObjectID);
            
            CreateTable(
                "dbo.ObjectValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        KeyValue = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "ObjectID", "dbo.ObjectValues");
            DropIndex("dbo.Logs", new[] { "ObjectID" });
            DropTable("dbo.ObjectValues");
            DropTable("dbo.Logs");
        }
    }
}
