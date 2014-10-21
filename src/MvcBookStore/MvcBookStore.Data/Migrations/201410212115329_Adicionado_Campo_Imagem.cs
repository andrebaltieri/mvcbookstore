namespace MvcBookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionado_Campo_Imagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Image", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Image");
        }
    }
}
