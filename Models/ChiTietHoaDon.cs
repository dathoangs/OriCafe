using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class ChiTietHoaDon
{
    public int Id { get; set; }

    public int SoLuong { get; set; }

    public double GiaBan { get; set; }

    public int? IdHoaDon { get; set; }

    public int? IdSanPham { get; set; }

    public virtual HoaDon? IdHoaDonNavigation { get; set; }

    public virtual SanPham? IdSanPhamNavigation { get; set; }
}
