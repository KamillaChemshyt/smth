using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Laba3.Models;
using Laba3.Dal.Entities;
using Laba3.Dal;

namespace Laba3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PassengerService _passengerService;

        private readonly TicketService _ticketService;

        private readonly AirlineService _airlineService;



        

        public HomeController(ILogger<HomeController> logger, PassengerService passengerService, TicketService ticketService, AirlineService airlineService)
        {
            _logger = logger;
            _passengerService = passengerService;
            _ticketService = ticketService;
            _airlineService = airlineService;
        }

        public async Task <IActionResult> Index() 
        {
            return View(await _passengerService.GetAllAsync());
        }

        public IActionResult PassengerAddView()
        {
            return View();
        }

        public IActionResult PassengerEditView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Passenger passenger)
        {
            await _passengerService.AddPassengerAsync(passenger);
            return RedirectToAction("Index");
        }

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> Delete(string accountKey)
        //{
        //    await _passengerService.RemoveAsync(accountKey);
        //    return RedirectToAction("Index");
        //}


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                Passenger passenger = await _passengerService.GetPassengerByIdAsync(id);
                if (passenger != null)
                {
                    await _passengerService.RemoveAsync(passenger);
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }



        public async Task<IActionResult> Edit(string id)
        {
            if (id != null)
            {
                Passenger passenger = await _passengerService.GetPassengerByIdAsync(id); ;
                if (passenger != null) 
                    return View(passenger);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Passenger passenger)
        {
            await _passengerService.UpdateAsync(passenger);
            return RedirectToAction("Index");
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




