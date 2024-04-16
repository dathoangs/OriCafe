using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OriCafe.Models;
using Microsoft.Data.SqlClient;

namespace OriCafe.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    public OriCafeContext db;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
        db = new OriCafeContext();
    }

    public IActionResult Index()
    {
        dynamic model = new ExpandoObject();

        model.SanPhams = db.SanPhams.ToList();
        
        return View("Product",model);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
        SqlParameter idParam = new SqlParameter("@Id", id);
        await db.Database.ExecuteSqlRawAsync("EXEC DeleteProduct @Id", idParam);
        return Ok(); 
        }
    catch
    {
        return StatusCode(500); 
    }
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
