using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class HouseholdsController : Controller
    {
        private readonly WebAppDbContext _context;

        public HouseholdsController(WebAppDbContext context) : base()
        {
            _context = context;
        }

        public IActionResult Index([FromQuery] int page = 1)
        {
            IList<Household> households = new List<Household>();

            try {
                households = _context.GetHouseholds(page);
            }
            catch (Exception e)
            {
                ViewBag.error = e;
            }

            ViewData.Model = households;

            return View();
        }
    }
}
