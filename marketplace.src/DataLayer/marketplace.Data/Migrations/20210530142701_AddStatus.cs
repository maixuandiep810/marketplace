using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "VaiTro",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "VaiTro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "TaiKhoan",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "TaiKhoan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "SanPhamDanhMuc",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "SanPhamDanhMuc",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "SanPham",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "SanPham",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenRouteVaiTro",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "QuyenRouteVaiTro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenRoute",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "QuyenRoute",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenEntityVaiTro",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "QuyenEntityVaiTro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenEntityTaiKhoan",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "QuyenEntityTaiKhoan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenEntity",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "QuyenEntity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuanLyDonHang",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "QuanLyDonHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "NguoiBan",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "NguoiBan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "NgonNgu",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "NgonNgu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "LangNgheDanhMuc",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "LangNgheDanhMuc",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "LangNghe",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "LangNghe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "KhachHang",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "KhachHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "HinhAnh",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "HinhAnh",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "GioHang",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "GioHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "GiaoDich",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "GiaoDich",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiGiaoDich",
                table: "GiaoDich",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "DonHang",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiDonHang",
                table: "DonHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "DanhMuc",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "CuaHang",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "CuaHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "ChiTietSanPham",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "ChiTietSanPham",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "ChiTietDonHang",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "ChiTietDonHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "ChiTietDanhMuc",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "ChiTietDanhMuc",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "SanPhamDanhMuc");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "QuyenRouteVaiTro");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "QuyenRoute");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "QuyenEntityVaiTro");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "QuyenEntityTaiKhoan");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "QuyenEntity");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "QuanLyDonHang");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "NguoiBan");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "NgonNgu");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LangNgheDanhMuc");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "HinhAnh");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "GioHang");

            migrationBuilder.DropColumn(
                name: "TrangThaiGiaoDich",
                table: "GiaoDich");

            migrationBuilder.DropColumn(
                name: "TrangThaiDonHang",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietSanPham");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietDanhMuc");

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "VaiTro",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "TaiKhoan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "SanPhamDanhMuc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "SanPham",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenRouteVaiTro",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenRoute",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenEntityVaiTro",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenEntityTaiKhoan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuyenEntity",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "QuanLyDonHang",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "NguoiBan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "NgonNgu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "LangNgheDanhMuc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "LangNghe",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "KhachHang",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "HinhAnh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "GioHang",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "GiaoDich",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "GiaoDich",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "DonHang",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "DanhMuc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "CuaHang",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "ChiTietSanPham",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "ChiTietDonHang",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "DaXoa",
                table: "ChiTietDanhMuc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
