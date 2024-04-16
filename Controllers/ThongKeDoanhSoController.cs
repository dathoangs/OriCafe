
using Microsoft.AspNetCore.Mvc;
using OriCafe.Models;
using System.Diagnostics.CodeAnalysis;

namespace OriCafe.Controllers
{
    public class ThongKeDoanhSoController : Controller

    {

        private OriCafeContext db = new OriCafeContext();
        [Route("Thongke")]
        public IActionResult ViewThongke()
        {
            return View();
        }
        //[Route("Thongke")]
        [HttpGet]
        public ActionResult GetThongKeDoanhSo( string fromDate, string toDate) 
        {
            var query = from hd in db.HoaDons
                        join cthd in db.ChiTietHoaDons on hd.Id equals cthd.IdHoaDon
                        join sp in db.SanPhams on cthd.IdSanPham equals sp.Id
                        select new
                        {
                            ngay_tao = hd.NgayTao,
                            so_luong = cthd.SoLuong,
                            gia_ban = cthd.GiaBan
                        };


            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.ngay_tao >= startDate);
           }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.ngay_tao < endDate);
            }


            var result = query.GroupBy(x => x.ngay_tao).Select(x => new
            {
                Date = x.Key,
                TotalSell = x.Sum(y => y.so_luong * y.gia_ban),


            }).Select(x=>new
            {
                date = x.Date,
                doanhthu = x.TotalSell,
            }) ;


            return Json(new { Data = result });
            //return View("ViewThongke", result);
        }

    }
}
