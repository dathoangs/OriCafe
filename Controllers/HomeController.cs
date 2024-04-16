using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OriCafe.Models;

namespace OriCafe.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public OriCafeContext db;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        db = new OriCafeContext();
    }

    public IActionResult Index()
    {
        dynamic model = new ExpandoObject();

        model.SanPhams = db.SanPhams.ToList();
        model.LoaiSanPhams = db.LoaiSanPhams.ToList();
        
        
        return View(model);
    }

    public IActionResult addItem(int id)
    {
        return View();
    }

    [HttpPost]
    public void order(ReceiveModel model){
        List<SanPham> sanPhams = db.SanPhams.ToList();


        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class ReceiveModel{
    
   public List<int> array {get; set;}
}