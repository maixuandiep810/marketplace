using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class FixDecimalErrorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "HinhAnh",
                newName: "TieuDe");

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGiaGoc",
                table: "SanPham",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGia",
                table: "SanPham",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ThanhTien",
                table: "Orders",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ThanhTien",
                table: "GiaoDich",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Phi",
                table: "GiaoDich",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,8)");

            migrationBuilder.AlterColumn<bool>(
                name: "HienThiTrangChu",
                table: "DanhMuc",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGia",
                table: "ChiTietDonHang",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,8)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TieuDe",
                table: "HinhAnh",
                newName: "Caption");

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGiaGoc",
                table: "SanPham",
                type: "decimal(10,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGia",
                table: "SanPham",
                type: "decimal(10,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ThanhTien",
                table: "Orders",
                type: "decimal(10,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ThanhTien",
                table: "GiaoDich",
                type: "decimal(10,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Phi",
                table: "GiaoDich",
                type: "decimal(10,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "HienThiTrangChu",
                table: "DanhMuc",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGia",
                table: "ChiTietDonHang",
                type: "decimal(10,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");
        }
    }
}
