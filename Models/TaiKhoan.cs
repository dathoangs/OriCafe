using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class TaiKhoan
{
    public int Id { get; set; }

    public string TenTaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int VaiTro { get; set; }

    public int TrangThai { get; set; }

    public int? IdQuan { get; set; }

    public int? IdNhanVien { get; set; }

    public virtual NhanVien? IdNhanVienNavigation { get; set; }

    public virtual QuanCaPhe? IdQuanNavigation { get; set; }

    public virtual ICollection<PhanQuyen> PhanQuyens { get; set; } = new List<PhanQuyen>();
}
