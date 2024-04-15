using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class InvoiceDetail
{
        public int id { get; set; }
        public string ten_san_pham { get; set; }
        public int so_luong { get; set; }
        public double gia_ban { get; set; }
}