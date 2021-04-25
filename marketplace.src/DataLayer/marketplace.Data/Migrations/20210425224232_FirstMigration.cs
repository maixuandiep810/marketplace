using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    HienThiTrangChu = table.Column<bool>(nullable: false, defaultValue: true),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHA = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    Url = table.Column<string>(type: "ntext", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DoiTuongId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LangNghe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLN = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenDayDu = table.Column<string>(type: "nvarchar(1024)", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangNghe", x => x.Id);
                    table.UniqueConstraint("AK_LangNghe_Ten", x => x.Ten);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(16)", nullable: false),
                    MaNN = table.Column<string>(type: "varchar(32)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    MacDinh = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenDayDu = table.Column<string>(type: "nvarchar(1024)", nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    DonGiaGoc = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    SoLuong = table.Column<int>(nullable: false, defaultValue: 0),
                    LuotXem = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    NgayCapNhat = table.Column<DateTime>(nullable: false),
                    LaNguoiBan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanVaiTro",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanVaiTro", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuaHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCH = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenDayDu = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    LangNgheId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHang", x => x.Id);
                    table.UniqueConstraint("AK_CuaHang_Ten", x => x.Ten);
                    table.ForeignKey(
                        name: "FK_CuaHang_LangNghe_LangNgheId",
                        column: x => x.LangNgheId,
                        principalTable: "LangNghe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LangNgheDanhMuc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangNgheId = table.Column<int>(nullable: false),
                    DanhMucId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangNgheDanhMuc", x => x.Id);
                    table.UniqueConstraint("AK_LangNgheDanhMuc_LangNgheId_DanhMucId", x => new { x.LangNgheId, x.DanhMucId });
                    table.ForeignKey(
                        name: "FK_LangNgheDanhMuc_DanhMuc_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangNgheDanhMuc_LangNghe_LangNgheId",
                        column: x => x.LangNgheId,
                        principalTable: "LangNghe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucDichThuat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    DanhMucId = table.Column<int>(nullable: false),
                    NgonNguId = table.Column<string>(type: "varchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucDichThuat", x => x.Id);
                    table.UniqueConstraint("AK_DanhMucDichThuat_DanhMucId_NgonNguId", x => new { x.DanhMucId, x.NgonNguId });
                    table.ForeignKey(
                        name: "FK_DanhMucDichThuat_DanhMuc_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucDichThuat_Languages_NgonNguId",
                        column: x => x.NgonNguId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamDanhMuc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamId = table.Column<int>(nullable: false),
                    DanhMucId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamDanhMuc", x => x.Id);
                    table.UniqueConstraint("AK_SanPhamDanhMuc_DanhMucId_SanPhamId", x => new { x.DanhMucId, x.SanPhamId });
                    table.ForeignKey(
                        name: "FK_SanPhamDanhMuc_DanhMuc_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamDanhMuc_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamDichThuat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenDayDu = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    SanPhamId = table.Column<int>(nullable: false),
                    NgonNguId = table.Column<string>(type: "varchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamDichThuat", x => x.Id);
                    table.UniqueConstraint("AK_SanPhamDichThuat_SanPhamId_NgonNguId", x => new { x.SanPhamId, x.NgonNguId });
                    table.ForeignKey(
                        name: "FK_SanPhamDichThuat_Languages_NgonNguId",
                        column: x => x.NgonNguId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamDichThuat_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                    table.UniqueConstraint("AK_KhachHang_TaiKhoanId", x => x.TaiKhoanId);
                    table.ForeignKey(
                        name: "FK_KhachHang_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiBan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNB = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: false),
                    TaiKhoanId = table.Column<Guid>(nullable: false),
                    CuaHangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiBan", x => x.Id);
                    table.UniqueConstraint("AK_NguoiBan_TaiKhoanId", x => x.TaiKhoanId);
                    table.ForeignKey(
                        name: "FK_NguoiBan_CuaHang_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiBan_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    NgayCapNhat = table.Column<DateTime>(nullable: false),
                    KhachHangId = table.Column<int>(nullable: false),
                    SanPhamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHang_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHang_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDH = table.Column<string>(type: "varchar(32)", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    KhachHangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    DonHangId = table.Column<int>(nullable: false),
                    SanPhamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => x.Id);
                    table.UniqueConstraint("AK_ChiTietDonHang_DonHangId_SanPhamId", x => new { x.DonHangId, x.SanPhamId });
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_Orders_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaoDich",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaGD = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    Phi = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    NhaCungCap = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    LoiNhan = table.Column<string>(type: "ntext", nullable: true),
                    DonHangId = table.Column<int>(nullable: false),
                    KhachHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoDich", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaoDich_Orders_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiaoDich_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuanLyDonHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuaHangId = table.Column<int>(nullable: false),
                    DonHangId = table.Column<int>(nullable: false),
                    NguoiBanId = table.Column<int>(nullable: true),
                    ChiTietDonHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyDonHang", x => x.Id);
                    table.UniqueConstraint("AK_QuanLyDonHang_CuaHangId_DonHangId", x => new { x.CuaHangId, x.DonHangId });
                    table.ForeignKey(
                        name: "FK_QuanLyDonHang_ChiTietDonHang_ChiTietDonHangId",
                        column: x => x.ChiTietDonHangId,
                        principalTable: "ChiTietDonHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuanLyDonHang_CuaHang_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuanLyDonHang_Orders_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuanLyDonHang_NguoiBan_NguoiBanId",
                        column: x => x.NguoiBanId,
                        principalTable: "NguoiBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_SanPhamId",
                table: "ChiTietDonHang",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_CuaHang_LangNgheId",
                table: "CuaHang",
                column: "LangNgheId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDichThuat_NgonNguId",
                table: "DanhMucDichThuat",
                column: "NgonNguId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDich_DonHangId",
                table: "GiaoDich",
                column: "DonHangId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDich_KhachHangId",
                table: "GiaoDich",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_KhachHangId",
                table: "GioHang",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_SanPhamId",
                table: "GioHang",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_LangNgheDanhMuc_DanhMucId",
                table: "LangNgheDanhMuc",
                column: "DanhMucId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiBan_CuaHangId",
                table: "NguoiBan",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_KhachHangId",
                table: "Orders",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyDonHang_ChiTietDonHangId",
                table: "QuanLyDonHang",
                column: "ChiTietDonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyDonHang_DonHangId",
                table: "QuanLyDonHang",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyDonHang_NguoiBanId",
                table: "QuanLyDonHang",
                column: "NguoiBanId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamDanhMuc_SanPhamId",
                table: "SanPhamDanhMuc",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamDichThuat_NgonNguId",
                table: "SanPhamDichThuat",
                column: "NgonNguId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhMucDichThuat");

            migrationBuilder.DropTable(
                name: "GiaoDich");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HinhAnh");

            migrationBuilder.DropTable(
                name: "LangNgheDanhMuc");

            migrationBuilder.DropTable(
                name: "QuanLyDonHang");

            migrationBuilder.DropTable(
                name: "SanPhamDanhMuc");

            migrationBuilder.DropTable(
                name: "SanPhamDichThuat");

            migrationBuilder.DropTable(
                name: "TaiKhoanVaiTro");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "NguoiBan");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "CuaHang");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "LangNghe");

            migrationBuilder.DropTable(
                name: "TaiKhoan");
        }
    }
}
