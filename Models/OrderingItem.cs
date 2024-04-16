using System;

namespace OriCafe.Models
{
    public class OrderingItem{
        public int IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public float GiaBan { get; set; }
        public int SoLuong { get; set; }

        public OrderingItem(int IdSanPham, string TenSanPham, string LoaiSanPham, float GiaBan, int SoLuong){
            this.IdSanPham = IdSanPham;
            this.TenSanPham = TenSanPham;
            this.LoaiSanPham = LoaiSanPham;
            this.GiaBan = GiaBan;
            this.SoLuong = SoLuong;
        }
    }
}