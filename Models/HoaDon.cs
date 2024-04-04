using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public DateTime NgayTao { get; set; }

    public int TongTien { get; set; }

    public int TrangThai { get; set; }

    public int? IdNhanVien { get; set; }

    public int? IdKhachHang { get; set; }

    public int? IdQuan { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang? IdKhachHangNavigation { get; set; }

    public virtual NhanVien? IdNhanVienNavigation { get; set; }

    public virtual QuanCaPhe? IdQuanNavigation { get; set; }
}
