using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class ThemCapVungMien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoCuaHang",
                table: "LangNghe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CapVungMienId",
                table: "CapTinh",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoCuaHang",
                table: "CapTinh",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoCuaHang",
                table: "CapHuyen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CapVungMien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    SoCuaHang = table.Column<int>(nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapVungMien", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapTinh_CapVungMienId",
                table: "CapTinh",
                column: "CapVungMienId");

            migrationBuilder.AddForeignKey(
                name: "FK_CapTinh_CapVungMien_CapVungMienId",
                table: "CapTinh",
                column: "CapVungMienId",
                principalTable: "CapVungMien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapTinh_CapVungMien_CapVungMienId",
                table: "CapTinh");

            migrationBuilder.DropTable(
                name: "CapVungMien");

            migrationBuilder.DropIndex(
                name: "IX_CapTinh_CapVungMienId",
                table: "CapTinh");

            migrationBuilder.DropColumn(
                name: "SoCuaHang",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "CapVungMienId",
                table: "CapTinh");

            migrationBuilder.DropColumn(
                name: "SoCuaHang",
                table: "CapTinh");

            migrationBuilder.DropColumn(
                name: "SoCuaHang",
                table: "CapHuyen");
        }
    }
}
