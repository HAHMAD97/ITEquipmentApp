using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ITEquipmentBorrowApp.Models;

namespace ITEquipmentBorrowApp.Controllers;

public class HomeController : Controller
{
    private IEquipmentRepository equipmentRepository;
    private IRequestRepository requestRepository;

    public HomeController(IEquipmentRepository equipmentRepo, IRequestRepository requestRepo)
    {
        equipmentRepository = equipmentRepo;
        requestRepository = requestRepo;
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
            requestRepository.Add(request);
            return View("Confirmation", request);
        } else {
            return View();
        }
    }

    [HttpGet]
    public ViewResult AllEquipment()
    {
        return View(equipmentRepository.GetAll());
    }

    [HttpGet]
    public ViewResult AvailableEquipment()
    { 
        return View(equipmentRepository.GetAvailable());
    }

    [HttpGet]
    public ViewResult Requests()
    {
        return View(requestRepository.GetAll());
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
