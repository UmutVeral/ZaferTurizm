using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class BusTripController : Controller
    {
        private readonly IBusTripService _busTripService;
        private readonly IRouteService _routeService;
        private readonly IVehicleService _vehicleService;

        // Mediatr
        // CQRS
        public BusTripController(
            IBusTripService busTripService,
            IRouteService routeService,
            IVehicleService vehicleService)
        {
            _busTripService = busTripService;
            _routeService = routeService;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            var busTripSummaries = _busTripService.GetSummaries();

            return View(busTripSummaries);
        }

        public IActionResult Create()
        {
            FillRouteAndVehicleValues();

            // Mediator olaydı böyle yazacaktık
            //var getAllRoutesQuery = new GetAllRoutesQuery();
            //var allRoutes = _mediator.Send(getAllRoutesQuery);

            //var query = new GetBusTripsByRouteQuery()
            //{
            //    RouteId = 10
            //};

            return View();
        }

        private void FillRouteAndVehicleValues()
        {
            var routeSummaries = _routeService.GetSummaries();
            var vehicleSummaries = _vehicleService.GetSummaries();

            ViewBag.RouteSelectList = new SelectList(routeSummaries, "Id", "RouteName");
            ViewBag.VehicleSelectList = new SelectList(vehicleSummaries, "Id", "Description");
        }

        [HttpPost]
        public IActionResult Create(BusTripDto dto)
        {
            var result = _busTripService.Create(dto);

            if (result.IsSuccess)
            {
                //ViewBag.SuccessMessage = result.Message;
                TempData["SuccessMessage"] = result.Message;

                return RedirectToAction(nameof(Index));
            }
            else
            {
                FillRouteAndVehicleValues();

                ViewBag.ErrorMessage = result.Message.Replace("\n", "<br>");

                return View(dto);
            }
        }
    }
}
