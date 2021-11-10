namespace QuanLyTinTuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        MoTa = c.String(),
                        NoiDung = c.String(),
                        HinhAnh = c.String(),
                        NgayDang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinTucs");
        }
    }
}
