using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    MoTa = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true)
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
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    TaiKhoanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiBan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiBan_AspNetUsers_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiMua",
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
                    table.PrimaryKey("PK_NguoiMua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiMua_AspNetUsers_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    SoCuaHang = table.Column<int>(nullable: false),
                    CapVungMienId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapTinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapTinh_CapVungMien_CapVungMienId",
                        column: x => x.CapVungMienId,
                        principalTable: "CapVungMien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuyenRouteVaiTro_AspNetRoles_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPhamDanhMuc_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    NguoiMuaId = table.Column<int>(nullable: false),
                    SanPhamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHang_NguoiMua_NguoiMuaId",
                        column: x => x.NguoiMuaId,
                        principalTable: "NguoiMua",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GioHang_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SoCuaHang = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                    SoCuaHang = table.Column<int>(nullable: false),
                    DanhMucId = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LangNghe_DanhMuc_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    LangNgheId = table.Column<int>(nullable: false),
                    NguoiBanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuaHang_LangNghe_LangNgheId",
                        column: x => x.LangNgheId,
                        principalTable: "LangNghe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuaHang_NguoiBan_NguoiBanId",
                        column: x => x.NguoiBanId,
                        principalTable: "NguoiBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    NguoiMuaId = table.Column<int>(nullable: false),
                    CuaHangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonHang_CuaHang_CuaHangId",
                        column: x => x.CuaHangId,
                        principalTable: "CuaHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonHang_NguoiMua_NguoiMuaId",
                        column: x => x.NguoiMuaId,
                        principalTable: "NguoiMua",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CapHuyen_CapTinhId",
                table: "CapHuyen",
                column: "CapTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_CapTinh_CapVungMienId",
                table: "CapTinh",
                column: "CapVungMienId");

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
                name: "IX_CuaHang_NguoiBanId",
                table: "CuaHang",
                column: "NguoiBanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_CuaHangId",
                table: "DonHang",
                column: "CuaHangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_NguoiMuaId",
                table: "DonHang",
                column: "NguoiMuaId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_NguoiMuaId",
                table: "GioHang",
                column: "NguoiMuaId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_SanPhamId",
                table: "GioHang",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_LangNghe_CapHuyenId",
                table: "LangNghe",
                column: "CapHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_LangNghe_DanhMucId",
                table: "LangNghe",
                column: "DanhMucId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiBan_TaiKhoanId",
                table: "NguoiBan",
                column: "TaiKhoanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NguoiMua_TaiKhoanId",
                table: "NguoiMua",
                column: "TaiKhoanId",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HinhAnh");

            migrationBuilder.DropTable(
                name: "QuyenRouteVaiTro");

            migrationBuilder.DropTable(
                name: "SanPhamDanhMuc");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "QuyenRoute");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "CuaHang");

            migrationBuilder.DropTable(
                name: "NguoiMua");

            migrationBuilder.DropTable(
                name: "LangNghe");

            migrationBuilder.DropTable(
                name: "NguoiBan");

            migrationBuilder.DropTable(
                name: "CapHuyen");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CapTinh");

            migrationBuilder.DropTable(
                name: "CapVungMien");
        }
    }
}
