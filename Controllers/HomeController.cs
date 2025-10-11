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
        var availableEquipment = equipmentRepository.GetAvailable().ToList();
        ViewBag.Equipment = availableEquipment;
        return View();
    }

    [HttpPost]
    public IActionResult RequestForm(ITEquipmentRequest request)
    {
        if (ModelState.IsValid) {
            requestRepository.Add(request);
            return View("Confirmation", request);
        } else {
            var availableEquipment = equipmentRepository.GetAvailable().ToList();
            ViewBag.Equipment = availableEquipment;
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
        var requests = requestRepository.GetAll().ToList();
        var equipmentIds = requests.Select(r => r.EquipmentId).Distinct().ToList();
        var equipments = equipmentRepository.GetAll()
                                    .Where(e => equipmentIds.Contains(e.Id))
                                    .ToDictionary(e => e.Id, e => e);
        
        var viewModel = requests.Select(r => new RequestWithEquipmentViewModel
        {
            RequestId = r.Id,
            RequesterName = r.Requester.Name,
            RequesterRole = r.Requester.Role.ToString(),
            EquipmentType = equipments.ContainsKey(r.EquipmentId)
                            ? equipments[r.EquipmentId].Type.ToString()
                            : "Unknown",
            DurationDays = r.Borrow.DurationDays,
            Status = r.Status,
            CreatedAt = r.CreatedAt
        })
        .OrderByDescending(r => r.CreatedAt)
        .ToList();

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Accept(int id)
    {
        requestRepository.UpdateStatus(id, RequestStatus.Accepted);
        return RedirectToAction("Requests");
    }

    [HttpPost]
    public IActionResult Deny(int id)
    {
        requestRepository.UpdateStatus(id, RequestStatus.Denied);
        return RedirectToAction("Requests");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
