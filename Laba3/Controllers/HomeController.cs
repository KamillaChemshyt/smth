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

        public async Task<IActionResult> Ticket()
        {
            return View(await _ticketService.GetAllAsync());
        }


        public async Task<IActionResult> Airline()
        {
            return View(await _airlineService.GetAllAsync());
        }

        public IActionResult PassengerAddView()
        {
            return View();
        }

        public IActionResult AirlineAddView()
        {
            return View();
        }

        public async Task<IActionResult> TicketAddView()
        {
            return View(new TicketAdd
            {
                PassengerIds = await _passengerService.GetAllPassengerIds(),
                AirlineIds = await _airlineService.GetAllAirlineIds()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Passenger passenger)
        {
            await _passengerService.AddPassengerAsync(passenger);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CreateAirline(Airline airline)
        {
            await _airlineService.AddAirlineAsync(airline);
            return RedirectToAction("Airline");
        }

        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            await _ticketService.AddTicketAsync(ticket);
            return RedirectToAction("Ticket");
        }

        public IActionResult No()
        {
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePassenger(string id)
        {
            if (id != null)
            {
                Passenger passenger = await _passengerService.GetPassengerByIdAsync(id);
                if (passenger != null)
                {
                    return View(passenger);
                }
            }
            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(Passenger passenger)
        {
            await _passengerService.RemoveAsync(passenger);
            return RedirectToAction("Index");
        }


        public IActionResult No2()
        {
            return RedirectToAction("Airline");
        }
        public async Task<IActionResult> DeleteAirline(string id)
        {
            if (id != null)
            {
                Airline airline = await _airlineService.GetAirlineByIdAsync(id);
                if (airline != null)
                {
                    return View(airline);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSomeAirline(Airline airline)
        {
            await _airlineService.RemoveAsync(airline);
            return RedirectToAction("Airline");
        }



        public IActionResult No3()
        {
            return RedirectToAction("Ticket");
        }
        public async Task<IActionResult> DeleteTicket(string id)
        {
            if (id != null)
            {
                Ticket ticket = await _ticketService.GetTicketByIdAsync(id);
                if (ticket != null)
                {
                    return View(ticket);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSomeTicket(Ticket ticket)
        {
            await _ticketService.RemoveAsync(ticket);
            return RedirectToAction("Ticket");
        }



        public async Task<IActionResult> PassengerEditView(string id)
            {
                if (id != null)
                {
                    var passenger = await _passengerService.GetPassengerByIdAsync(id); ;
                    if (passenger != null)
                        return View(passenger);
                }
                return NotFound();
            }
        


        [HttpPost( "edit")]
        public async Task<IActionResult> Edit(Passenger passenger)
        {
            await _passengerService.UpdateAsync(passenger);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AirlineEditView(string id)
        {
            if (id != null)
            {
                var airline = await _airlineService.GetAirlineByIdAsync(id); ;
                if (airline != null)
                    return View(airline);
            }
            return NotFound();
        }

        [HttpPost("EditSomeAirline")]
        public async Task<IActionResult> EditSomeAirline(Airline airline)
        {
            await _airlineService.UpdateAsync(airline);
            return RedirectToAction("Airline");
        }



        public async Task<IActionResult> TicketEditView(string id)
        {
            if (id != null)
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id); ;
                if (ticket != null)
                    return View(ticket);
            }
            return NotFound();
        }

        [HttpPost("EditSomeTicket")]
        public async Task<IActionResult> EditSomeTicket(Ticket ticket)
        {
            await _ticketService.UpdateAsync(ticket);
            return RedirectToAction("Ticket");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}




