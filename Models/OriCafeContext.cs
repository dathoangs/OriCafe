using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OriCafe.Models;

public partial class OriCafeContext : DbContext
{
    public OriCafeContext()
    {
    }

    public OriCafeContext(DbContextOptions<OriCafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<QuanCaPhe> QuanCaPhes { get; set; }

    public virtual DbSet<QuyenHan> QuyenHans { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
    public virtual DbSet<InvoiceView> InvoiceViews { get; set; }
    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8TISM2T\\SQLEXPRESS; Initial Catalog=OriCafe; Trusted_Connection=True; Integrated Security=True; MultipleActiveResultSets=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<InvoiceView>().HasNoKey();
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chi_Tiet__3213E83F7838515E");

            entity.ToTable("Chi_Tiet_Hoa_Don");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GiaBan).HasColumnName("gia_ban");
            entity.Property(e => e.IdHoaDon).HasColumnName("id_hoa_don");
            entity.Property(e => e.IdSanPham).HasColumnName("id_san_pham");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");

            entity.HasOne(d => d.IdHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdHoaDon)
                .HasConstraintName("FK__Chi_Tiet___id_ho__5CD6CB2B");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdSanPham)
                .HasConstraintName("FK__Chi_Tiet___id_sa__5DCAEF64");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hoa_Don__3213E83FA4CC0DC5");

            entity.ToTable("Hoa_Don");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdKhachHang).HasColumnName("id_khach_hang");
            entity.Property(e => e.IdNhanVien).HasColumnName("id_nhan_vien");
            entity.Property(e => e.IdQuan).HasColumnName("id_quan");
            entity.Property(e => e.NgayTao)
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.TongTien).HasColumnName("tong_tien");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");

            entity.HasOne(d => d.IdKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdKhachHang)
                .HasConstraintName("FK__Hoa_Don__id_khac__59063A47");

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdNhanVien)
                .HasConstraintName("FK__Hoa_Don__id_nhan__5812160E");

            entity.HasOne(d => d.IdQuanNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdQuan)
                .HasConstraintName("FK__Hoa_Don__id_quan__59FA5E80");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khach_Ha__3213E83F026668A9");

            entity.ToTable("Khach_Hang");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("dia_chi");
            entity.Property(e => e.DiemTichLuy).HasColumnName("diem_tich_luy");
            entity.Property(e => e.DienThoai)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dien_thoai");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdQuan).HasColumnName("id_quan");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(255)
                .HasColumnName("ten_khach_hang");

            entity.HasOne(d => d.IdQuanNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.IdQuan)
                .HasConstraintName("FK__Khach_Han__id_qu__4E88ABD4");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Loai_San__3213E83FD369CAF2");

            entity.ToTable("Loai_San_Pham");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdQuan).HasColumnName("id_quan");
            entity.Property(e => e.TenLoaiSanPham)
                .HasMaxLength(255)
                .HasColumnName("ten_loai_san_pham");

            entity.HasOne(d => d.IdQuanNavigation).WithMany(p => p.LoaiSanPhams)
                .HasForeignKey(d => d.IdQuan)
                .HasConstraintName("FK__Loai_San___id_qu__5165187F");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nhan_Vie__3213E83FA07ABEBA");

            entity.ToTable("Nhan_Vien");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("dia_chi");
            entity.Property(e => e.DienThoai)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dien_thoai");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdQuan).HasColumnName("id_quan");
            entity.Property(e => e.TenNhanVien)
                .HasMaxLength(255)
                .HasColumnName("ten_nhan_vien");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");

            entity.HasOne(d => d.IdQuanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdQuan)
                .HasConstraintName("FK__Nhan_Vien__id_qu__4BAC3F29");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phan_Quy__3213E83F61BE7027");

            entity.ToTable("Phan_Quyen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdQuyenHan).HasColumnName("id_quyen_han");
            entity.Property(e => e.IdTaiKhoan).HasColumnName("id_tai_khoan");

            entity.HasOne(d => d.IdQuyenHanNavigation).WithMany(p => p.PhanQuyens)
                .HasForeignKey(d => d.IdQuyenHan)
                .HasConstraintName("FK__Phan_Quye__id_qu__6754599E");

            entity.HasOne(d => d.IdTaiKhoanNavigation).WithMany(p => p.PhanQuyens)
                .HasForeignKey(d => d.IdTaiKhoan)
                .HasConstraintName("FK__Phan_Quye__id_ta__66603565");
        });

        modelBuilder.Entity<QuanCaPhe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quan_Ca___3213E83FB31B1790");

            entity.ToTable("Quan_Ca_Phe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("dia_chi");
            entity.Property(e => e.DienThoai)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dien_thoai");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.TenQuan)
                .HasMaxLength(255)
                .HasColumnName("ten_quan");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
        });

        modelBuilder.Entity<QuyenHan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quyen_Ha__3213E83FA8787227");

            entity.ToTable("Quyen_Han");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MoTa)
                .HasColumnType("text")
                .HasColumnName("mo_ta");
            entity.Property(e => e.TenQuyenHan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten_quyen_han");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__San_Pham__3213E83FC7304E05");

            entity.ToTable("San_Pham");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GiaBan).HasColumnName("gia_ban");
            entity.Property(e => e.IdLoaiSanPham).HasColumnName("id_loai_san_pham");
            entity.Property(e => e.IdQuan).HasColumnName("id_quan");
            entity.Property(e => e.MoTa)
                .HasColumnType("text")
                .HasColumnName("mo_ta");
            entity.Property(e => e.TenSanPham)
                .HasMaxLength(255)
                .HasColumnName("ten_san_pham");

            entity.HasOne(d => d.IdLoaiSanPhamNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdLoaiSanPham)
                .HasConstraintName("FK__San_Pham__id_loa__5535A963");

            entity.HasOne(d => d.IdQuanNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdQuan)
                .HasConstraintName("FK__San_Pham__id_qua__5441852A");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tai_Khoa__3213E83FACED733D");

            entity.ToTable("Tai_Khoan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdNhanVien).HasColumnName("id_nhan_vien");
            entity.Property(e => e.IdQuan).HasColumnName("id_quan");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mat_khau");
            entity.Property(e => e.TenTaiKhoan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten_tai_khoan");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            entity.Property(e => e.VaiTro).HasColumnName("vai_tro");

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdNhanVien)
                .HasConstraintName("FK__Tai_Khoan__id_nh__619B8048");

            entity.HasOne(d => d.IdQuanNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdQuan)
                .HasConstraintName("FK__Tai_Khoan__id_qu__60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
   
}
