using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class QuyenHan
{
    public int Id { get; set; }

    public string TenQuyenHan { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<PhanQuyen> PhanQuyens { get; set; } = new List<PhanQuyen>();
}
