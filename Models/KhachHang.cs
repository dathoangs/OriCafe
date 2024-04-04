using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class KhachHang
{
    public int Id { get; set; }

    public string TenKhachHang { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string DienThoai { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int DiemTichLuy { get; set; }

    public int? IdQuan { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual QuanCaPhe? IdQuanNavigation { get; set; }
}
