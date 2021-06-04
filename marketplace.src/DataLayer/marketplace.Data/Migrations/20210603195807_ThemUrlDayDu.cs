using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class ThemUrlDayDu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenUrlDayDu",
                table: "SanPham",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrlDayDu",
                table: "LangNghe",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrlDayDu",
                table: "DanhMuc",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrlDayDu",
                table: "CuaHang",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrlDayDu",
                table: "CapVungMien",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrlDayDu",
                table: "CapTinh",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrlDayDu",
                table: "CapHuyen",
                type: "nvarchar(256)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenUrlDayDu",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "TenUrlDayDu",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "TenUrlDayDu",
                table: "DanhMuc");

            migrationBuilder.DropColumn(
                name: "TenUrlDayDu",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "TenUrlDayDu",
                table: "CapVungMien");

            migrationBuilder.DropColumn(
                name: "TenUrlDayDu",
                table: "CapTinh");

            migrationBuilder.DropColumn(
                name: "TenUrlDayDu",
                table: "CapHuyen");
        }
    }
}
