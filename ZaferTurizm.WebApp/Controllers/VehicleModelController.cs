using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleModelController(
            IVehicleModelService vehicleModelService,
            IVehicleMakeService vehicleMakeService)
        {
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
        }

        public IActionResult Index()
        {
            var vehicleModelSummaries = _vehicleModelService.GetSummaries();

            return View(vehicleModelSummaries);
        }

        public IActionResult Create()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();
            //ViewBag.VehicleMakes = vehicleMakes;
            ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(VehicleModelDto vehicleModel)
        {
            var result = _vehicleModelService.Create(vehicleModel);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(vehicleModel);
            }
        }

        public IActionResult GetVehicleModelsByMakeId(int vehicleMakeId)
        {
            var allVehicleModels = _vehicleModelService.GetAll();
            var vehicleModelsOfMake = 
                allVehicleModels.Where(model => model.VehicleMakeId == vehicleMakeId);

            //var vehicleModels = _vehicleModelService.GetByVehicleMakeId(vehicleMakeId);

            //Thread.Sleep(5000);

            return Json(vehicleModelsOfMake);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _vehicleModelService.Delete(id);

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
