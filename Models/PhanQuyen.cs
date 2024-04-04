using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class PhanQuyen
{
    public int Id { get; set; }

    public int? IdTaiKhoan { get; set; }

    public int? IdQuyenHan { get; set; }

    public virtual QuyenHan? IdQuyenHanNavigation { get; set; }

    public virtual TaiKhoan? IdTaiKhoanNavigation { get; set; }
}
