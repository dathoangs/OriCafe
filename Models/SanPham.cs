using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class SanPham
{
    public int Id { get; set; }

    public int? IdQuan { get; set; }

    public string TenSanPham { get; set; } = null!;

    public double GiaBan { get; set; }

    public string? MoTa { get; set; }

    public int? IdLoaiSanPham { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual LoaiSanPham? IdLoaiSanPhamNavigation { get; set; }

    public virtual QuanCaPhe? IdQuanNavigation { get; set; }
}
