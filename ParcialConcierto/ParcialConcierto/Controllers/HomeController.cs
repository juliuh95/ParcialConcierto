using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialConcierto.Data;
using ParcialConcierto.Data.Entities;
using ParcialConcierto.Models;
using System.Diagnostics;

namespace ParcialConcierto.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;


        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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