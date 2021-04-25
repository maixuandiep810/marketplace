using marketplace.Data.Configurations;
using marketplace.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace marketplace.Data.EF
{
    public class marketplaceDbContext : IdentityDbContext<TaiKhoan, VaiTro, Guid>
    {
        public marketplaceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API

            modelBuilder.ApplyConfiguration(new ChiTietDonHangCF());
            modelBuilder.ApplyConfiguration(new CuaHangCF());
            modelBuilder.ApplyConfiguration(new DanhMucCF());
            modelBuilder.ApplyConfiguration(new DanhMucDichThuatCF());
            modelBuilder.ApplyConfiguration(new DonHangCF());


            modelBuilder.ApplyConfiguration(new GiaoDichCF());
            modelBuilder.ApplyConfiguration(new GioHangCF());
            modelBuilder.ApplyConfiguration(new HinhAnhCF());
            modelBuilder.ApplyConfiguration(new KhachHangCF());
            modelBuilder.ApplyConfiguration(new LangNgheCF());
            modelBuilder.ApplyConfiguration(new LangNgheDanhMucCF());

            modelBuilder.ApplyConfiguration(new NgonNguCF());
            modelBuilder.ApplyConfiguration(new NguoiBanCF());
            modelBuilder.ApplyConfiguration(new QuanLyDonHangCF());

            modelBuilder.ApplyConfiguration(new SanPhamCF());
            modelBuilder.ApplyConfiguration(new SanPhamDanhMucCF());
            modelBuilder.ApplyConfiguration(new SanPhamDichThuatCF());
            modelBuilder.ApplyConfiguration(new TaiKhoanCF());
            modelBuilder.ApplyConfiguration(new VaiTroCF());

            // modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("ApplicationUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("TaiKhoanVaiTro").HasKey(x => new { x.UserId, x.RoleId });
            // modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("ApplicationUserLogins").HasKey(x => x.UserId);

            // modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("ApplicationRoleClaims");
            // modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("ApplicationUserTokens").HasKey(x => x.UserId);
            modelBuilder.Ignore<IdentityUserLogin<Guid>>();
            modelBuilder.Ignore<IdentityUserClaim<Guid>>();
            modelBuilder.Ignore<IdentityUserToken<Guid>>();
            modelBuilder.Ignore<IdentityRoleClaim<Guid>>();

            //Data seeding
            // modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }

        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        // public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        // public DbSet<IdentityUserRole<Guid>> ApplicationUserRoles { get; set; }
        // // public DbSet<AppConfig> AppConfigs { get; set; }
        // // public DbSet<AppConfig> AppConfigs { get; set; }


        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<CuaHang> CuaHangs { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<DanhMucDichThuat> DanhMucDichThuats { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }

        public DbSet<GiaoDich> GiaoDichs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<HinhAnh> HinhAnhs { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LangNghe> LangNghes { get; set; }
        public DbSet<LangNgheDanhMuc> LangNgheDanhMucs { get; set; }
        public DbSet<NgonNgu> NgonNgus { get; set; }
        public DbSet<NguoiBan> NguoiBans { get; set; }

        public DbSet<QuanLyDonHang> QuanLyDonHangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<SanPhamDanhMuc> SanPhamDanhMucs { get; set; }
        public DbSet<SanPhamDichThuat> SanPhamDichThuats { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<VaiTro> VaiTros { get; set; }
    }
}