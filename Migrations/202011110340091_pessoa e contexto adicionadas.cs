namespace WebApiOdata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pessoaecontextoadicionadas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pessoaid = c.Int(nullable: false),
                        pessoanome = c.String(),
                        pessoasobrenome = c.String(),
                        nomeusuario = c.String(),
                        endereco = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pessoas", t => t.pessoaid, cascadeDelete: true)
                .Index(t => t.pessoaid);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        sobrenome = c.String(),
                        nomeusuario = c.String(),
                        endereco = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contatoes", "pessoaid", "dbo.Pessoas");
            DropIndex("dbo.Contatoes", new[] { "pessoaid" });
            DropTable("dbo.Pessoas");
            DropTable("dbo.Contatoes");
        }
    }
}
