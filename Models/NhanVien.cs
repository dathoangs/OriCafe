using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class NhanVien
{
    public int Id { get; set; }

    public string TenNhanVien { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string DienThoai { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int TrangThai { get; set; }

    public int? IdQuan { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual QuanCaPhe? IdQuanNavigation { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
