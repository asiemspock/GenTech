using GenTech.Data;
using GenTech.Models;
using GenTech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GenTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                TotalCompanies = _context.Company.Count(),
                TotalUsers = _context.User.Count(),
                CompaniesList = _context.Company.OrderByDescending(c => c.Users.Count).ToList(),
            };

            return View(viewModel);
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
}
