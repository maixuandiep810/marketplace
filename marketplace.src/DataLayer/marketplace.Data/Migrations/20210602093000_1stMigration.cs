using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class _1stMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CapTinh",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapTinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    CapDanhMuc = table.Column<int>(nullable: false)
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
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    Url = table.Column<string>(type: "ntext", nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DoiTuongId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ThuTu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyenRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Ten = table.Column<string>(type: "varchar(256)", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    HanhDong = table.Column<string>(type: "varchar(256)", nullable: true),
                    PathRegex = table.Column<string>(type: "ntext", nullable: true),
                    LaRouteCanXacThuc = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenRoute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    TenDayDu = table.Column<string>(type: "ntext", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    DonGiaGoc = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
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
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    HoTen = table.Column<string>(type: "nvarchar(256)", nullable: true),
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
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    NhomVT = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapHuyen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CapTinhId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapHuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapHuyen_CapTinh_CapTinhId",
                        column: x => x.CapTinhId,
                        principalTable: "CapTinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamDanhMuc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    SanPhamId = table.Column<int>(nullable: false),
                    DanhMucId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamDanhMuc", x => x.Id);
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
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    TaiKhoanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHang_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyenRouteVaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    QuyenRouteId = table.Column<int>(nullable: false),
                    VaiTroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenRouteVaiTro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyenRouteVaiTro_QuyenRoute_QuyenRouteId",
                        column: x => x.QuyenRouteId,
                        principalTable: "QuyenRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyenRouteVaiTro_VaiTro_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LangNghe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    TenDayDu = table.Column<string>(type: "ntext", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    DiaChi = table.Column<string>(type: "ntext", nullable: true),
                    CapHuyenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangNghe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LangNghe_CapHuyen_CapHuyenId",
                        column: x => x.CapHuyenId,
                        principalTable: "CapHuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    TrangThaiDonHang = table.Column<int>(nullable: false, defaultValue: 0),
                    KhachHangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonHang_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
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
                name: "CuaHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    TenDayDu = table.Column<string>(type: "ntext", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    DiaChi = table.Column<string>(type: "ntext", nullable: true),
                    LangNgheId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHang", x => x.Id);
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
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    LangNgheId = table.Column<int>(nullable: false),
                    DanhMucId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangNgheDanhMuc", x => x.Id);
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
                name: "ChiTietDonHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    DonHangId = table.Column<int>(nullable: false),
                    SanPhamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
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
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    ThanhTien = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Phi = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    TrangThaiGiaoDich = table.Column<int>(nullable: false, defaultValue: 0),
                    NhaCungCap = table.Column<string>(type: "ntext", nullable: true),
                    LoiNhan = table.Column<string>(type: "ntext", nullable: true),
                    DonHangId = table.Column<int>(nullable: false),
                    KhachHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoDich", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaoDich_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
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
                name: "NguoiBan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    MoTa = table.Column<string>(type: "ntext", nullable: false),
                    TaiKhoanId = table.Column<Guid>(nullable: false),
                    CuaHangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiBan", x => x.Id);
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
                name: "QuanLyDonHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    CuaHangId = table.Column<int>(nullable: false),
                    DonHangId = table.Column<int>(nullable: false),
                    NguoiBanId = table.Column<int>(nullable: true),
                    ChiTietDonHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyDonHang", x => x.Id);
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
                        name: "FK_QuanLyDonHang_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
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
                name: "IX_CapHuyen_CapTinhId",
                table: "CapHuyen",
                column: "CapTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_DonHangId",
                table: "ChiTietDonHang",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_SanPhamId",
                table: "ChiTietDonHang",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_CuaHang_LangNgheId",
                table: "CuaHang",
                column: "LangNgheId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_KhachHangId",
                table: "DonHang",
                column: "KhachHangId");

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
                name: "IX_KhachHang_TaiKhoanId",
                table: "KhachHang",
                column: "TaiKhoanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LangNghe_CapHuyenId",
                table: "LangNghe",
                column: "CapHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_LangNgheDanhMuc_DanhMucId",
                table: "LangNgheDanhMuc",
                column: "DanhMucId");

            migrationBuilder.CreateIndex(
                name: "IX_LangNgheDanhMuc_LangNgheId",
                table: "LangNgheDanhMuc",
                column: "LangNgheId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiBan_CuaHangId",
                table: "NguoiBan",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiBan_TaiKhoanId",
                table: "NguoiBan",
                column: "TaiKhoanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyDonHang_ChiTietDonHangId",
                table: "QuanLyDonHang",
                column: "ChiTietDonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyDonHang_CuaHangId",
                table: "QuanLyDonHang",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyDonHang_DonHangId",
                table: "QuanLyDonHang",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyDonHang_NguoiBanId",
                table: "QuanLyDonHang",
                column: "NguoiBanId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenRouteVaiTro_QuyenRouteId",
                table: "QuyenRouteVaiTro",
                column: "QuyenRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenRouteVaiTro_VaiTroId",
                table: "QuyenRouteVaiTro",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamDanhMuc_DanhMucId",
                table: "SanPhamDanhMuc",
                column: "DanhMucId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamDanhMuc_SanPhamId",
                table: "SanPhamDanhMuc",
                column: "SanPhamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRoleClaims");

            migrationBuilder.DropTable(
                name: "ApplicationUserClaims");

            migrationBuilder.DropTable(
                name: "ApplicationUserLogins");

            migrationBuilder.DropTable(
                name: "ApplicationUserTokens");

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
                name: "QuyenRouteVaiTro");

            migrationBuilder.DropTable(
                name: "SanPhamDanhMuc");

            migrationBuilder.DropTable(
                name: "TaiKhoanVaiTro");

            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "NguoiBan");

            migrationBuilder.DropTable(
                name: "QuyenRoute");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "DonHang");

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

            migrationBuilder.DropTable(
                name: "CapHuyen");

            migrationBuilder.DropTable(
                name: "CapTinh");
        }
    }
}
