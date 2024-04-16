using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OriCafe.Models;
namespace OriCafe.Controllers;
using System.Data.SqlClient;

public class InvoiceController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public OriCafeContext db;

    public InvoiceController(ILogger<HomeController> logger)
    {
        _logger = logger;
        db = new OriCafeContext();
    }

     public async Task<IActionResult> Index(string searchString)
        {
            // Gọi stored procedure và nhận kết quả trả về
            var invoices = await db.InvoiceViews.FromSqlRaw("EXEC Proc_HoaDon").ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                invoices = invoices.Where(i => i.ten_khach_hang.Contains(searchString)).ToList();
            }
    
            return View("Invoice",invoices);
        }
    public IActionResult InvoiceDetail(int id)
    {
        ViewBag.InvoiceId = id;
        var invoiceDetail = db.InvoiceDetails.FromSqlInterpolated($"EXEC Proc_GetInvoiceDetail {id}").ToList();
        return View("InvoiceDetail",invoiceDetail);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
