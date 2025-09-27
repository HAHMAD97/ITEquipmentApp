using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ITEquipmentBorrowApp.Models;

namespace ITEquipmentBorrowApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpGet]
    public ViewResult RequestForm() {
        return View();
    }

    [HttpPost]
    public IActionResult RequestForm(ITEquipmentRequest request)
    {
        if (ModelState.IsValid) {
            Repository.AddRequest(request);
            return View("Confirmation", request);
        } else {
            return View();
        }
    }

    [HttpGet]
    public ViewResult AllEquipment()
    {
        return View(Repository.Equipments);
    }

    [HttpGet]
    public ViewResult AvailableEquipment()
    { 
        return View(Repository.Equipments.Where(e => e.Availability == true));
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
