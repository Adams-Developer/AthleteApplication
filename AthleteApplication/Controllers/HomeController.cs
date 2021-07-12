using AthleteApplication.Models;
using AthleteApplication.Services;
using AthleteApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AthleteApplication.Controllers
{
    public class HomeController : Controller
    {
        private AthleteDbContext _dbContext;
        private AthleteService _athleteService;
        private readonly AthleteViewModel _athleteViewModel;

        public HomeController(AthleteDbContext dbContext, AthleteService athleteService)
        {
            _dbContext = dbContext;
            _athleteService = athleteService;
            _athleteViewModel = new AthleteViewModel();
        }

        public IActionResult Index(string query)
        {
            // Dropdown List
            List<Sizes> sizes = _athleteService.GetSizes();
            ViewBag.Sizes = new SelectList(sizes, "SizeId", "Size");



            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SaveRecord(AthleteViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var newRecord = await _athleteService.SaveRecord(viewModel);
        //        return RedirectToAction("ThankYou");
        //    }
        //    return View();
        //}

        [HttpPost]
        public JsonResult CreateRecord(AthleteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newRecord = _athleteService.SaveRecord(viewModel);
                return Json(new { success = true, data = newRecord });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public IActionResult ThankYou()
        {
            return View("ThankYou");
        }

        // Autocomplete
        [HttpPost]
        public JsonResult City_AutoComplete(string searchTerm)
        {
            var customers = (from customer in _dbContext.Cities
                             where customer.City.StartsWith(searchTerm)
                             select new
                             {
                                 label = customer.City,
                                 val = customer.StateCode
                             }).Distinct()
                             .Take(10)
                             .ToList();

            return Json(customers);
        }

        [HttpGet]
        public JsonResult State_AutoComplete(string searchTerm)
        {
            var states = (from state in _dbContext.States
                          where state.StateCode.StartsWith(searchTerm)
                          select new
                          {
                              label = state.StateCode,
                              value = state.StateCode,
                          }).Take(10)
                          .ToList();

            return Json(states);
        }

        // Dropdown
        //public IActionResult GetMerchSize()
        //{
        //    //var merchList = _athleteService.GetMerchSizes()
        //    //    .Select(x => x.Size);

        //    var sizes = new SelectList(_dbContext.Sizes.ToList(), "SizeId", "Size");
        //    ViewData["sizeList"] = sizes;

        //}


        [HttpPost]
        public JsonResult TestCity_AutoComplete(string searchTerm)
        {
          
            var customers = _dbContext.Cities
                .Where(x => x.City.StartsWith(searchTerm))
                .Select(x => new            
                {
                    label = x.City,
                    value = x.StateCode
                })
                .Distinct()
                .Take(10)
                .ToList();

            return Json(customers);
        }



    }
}
