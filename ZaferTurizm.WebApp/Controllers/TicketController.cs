using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Dtos;
using Rotativa;
using System.Transactions;

namespace ZaferTurizm.WebApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly IBusTripService _busTripService;
        private readonly ITicketService _ticketService;

        public TicketController(IBusTripService busTripService, ITicketService ticketService)
        {
            _busTripService = busTripService;
            _ticketService = ticketService;
        }

        public IActionResult TicketsOfBusTrip(int busTripId)
        {
            var busTripDetails = _busTripService.GetBusTripDetails(busTripId);

            if (busTripDetails == null)
            {
                TempData["ErrorMessage"] = "Seyahat bulunamadı";
                return RedirectToAction("Index", "BusTrip");
            }

            return View(busTripDetails);
        }

        [HttpPost]
        public IActionResult Create(TicketDto ticket)
        {
            var result = _ticketService.Create(ticket);
            


           return Json(result);
          
        }
        public IActionResult Index(string ara)
        {
            var ticketPage = _ticketService.GetAll();
            if (!string.IsNullOrEmpty(ara))
            {
                ticketPage = ticketPage.Where(x => x.PassengerFirstName.Contains(ara) || x.PassengerLastName.Contains(ara)).ToList();
            }
            return View(ticketPage);
        }

        public IActionResult Update(int id)
        {
            var ticketDto = _ticketService.GetById(id);

            if (ticketDto != null)
            {
                return View(ticketDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update(TicketDto tc)
        {
            var result = _ticketService.Update(tc);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(tc);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _ticketService.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }


    }
}
