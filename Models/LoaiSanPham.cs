using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class LoaiSanPham
{
    public int Id { get; set; }

    public int? IdQuan { get; set; }

    public string TenLoaiSanPham { get; set; } = null!;

    public virtual QuanCaPhe? IdQuanNavigation { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
