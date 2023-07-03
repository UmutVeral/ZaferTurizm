using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleDefinitionController : Controller
    {
        private readonly IVehicleDefinitionService _vehicleDefinitionService;
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleDefinitionController(
            IVehicleDefinitionService vehicleDefinitionService,
            IVehicleMakeService vehicleMakeService,
            IVehicleModelService vehicleModelService)
        {
            _vehicleDefinitionService = vehicleDefinitionService;
            _vehicleMakeService = vehicleMakeService;
            _vehicleModelService = vehicleModelService;
        }

        public IActionResult Index()
        {
            var summaries = _vehicleDefinitionService.GetSummaries();

            return View(summaries);
        }

        public IActionResult Create()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();
            ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");

            return View();
        }

        public IActionResult Update(int id)
        {
            var vehicleDefinition = _vehicleDefinitionService.GetById(id);

            if (vehicleDefinition == null)
            {
                return NotFound();
            }

            var allvehicleMakes = _vehicleMakeService.GetAll();
            ViewBag.VehicleMakeSelectList =
                new SelectList(allvehicleMakes, "Id", "Name");

            var vehicleModelsOfMake = _vehicleModelService.GetByMakeId(vehicleDefinition.VehicleMakeId);
            ViewBag.VehicleModelSelectList =
                new SelectList(vehicleModelsOfMake, "Id", "Name");

            //var allVehicleModels = _vehicleModelService.GetAll();
            //ViewBag.VehicleModelsSelectList = new SelectList(allVehicleModels, "Id", "Name");

            return View(vehicleDefinition);
        }
        [HttpPost]
        public IActionResult Update(VehicleDefinitionDto model)
        {
            var result = _vehicleDefinitionService.Update(model);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
            [HttpPost]
        public IActionResult Create(VehicleDefinitionDto vehicleDefinition)
        {
            var result = _vehicleDefinitionService.Create(vehicleDefinition);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(vehicleDefinition);
            }
        }
    }
}
