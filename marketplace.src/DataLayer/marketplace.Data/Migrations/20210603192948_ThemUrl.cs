using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class ThemUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NhomVT",
                table: "VaiTro");

            migrationBuilder.AddColumn<string>(
                name: "TenUrl",
                table: "SanPham",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrl",
                table: "LangNghe",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "DanhMuc",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AddColumn<string>(
                name: "TenUrl",
                table: "DanhMuc",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrl",
                table: "CuaHang",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrl",
                table: "CapVungMien",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrl",
                table: "CapTinh",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenUrl",
                table: "CapHuyen",
                type: "nvarchar(256)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenUrl",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "TenUrl",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "TenUrl",
                table: "DanhMuc");

            migrationBuilder.DropColumn(
                name: "TenUrl",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "TenUrl",
                table: "CapVungMien");

            migrationBuilder.DropColumn(
                name: "TenUrl",
                table: "CapTinh");

            migrationBuilder.DropColumn(
                name: "TenUrl",
                table: "CapHuyen");

            migrationBuilder.AddColumn<string>(
                name: "NhomVT",
                table: "VaiTro",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "DanhMuc",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);
        }
    }
}
