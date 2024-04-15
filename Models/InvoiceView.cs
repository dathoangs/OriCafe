using System;
using System.Collections.Generic;

namespace OriCafe.Models;

public partial class InvoiceView
{
        public int id { get; set; }
        public string ten_quan { get; set; }
        public string ten_khach_hang { get; set; }
        public string ten_nhan_vien { get; set; }
        public DateTime ngay_tao { get; set; }
        public int tong_tien { get; set; }
}