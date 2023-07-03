using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Dtos;
using ZaferTurizm.WebApp.Models;

namespace ZaferTurizm.WebApp.Controllers
{
    // /VehicleMake
    // /VehicleMake/Index
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        public IActionResult Index()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();

            return View(vehicleMakes);
        }

        public IActionResult Create()
        {
            return View();
        }

        /*
         * HTTP Get tipindeki requestlerde veriler URL'in devamında Query String olarak
         * sunucuya iletilir
         * Örnek: /VehicleMake/Create?marka_adi=Isuzu
         * 
         * HTTP Post (hatta Put ve Delete dahil) tipindeki request'lerde veriler Request'in 
         * BODY bölümünde (yani gömülü şekilde) sunucuya iletilir
         */

        // Bir action metodun üstüne [HttpPost], [HttpGet] şeklindeki Attribute'lerden bir tanesini
        // eklemek, o action metodun YALNIZCA O HTTP METODU İLE ÇALIŞACAĞINI bildirmek olur
        // Yani diğer Http metotları ile aynı adrese açılmış Request'lere CEVAP VERME anlamına gelir

        //public IActionResult CreateSubmit(IFormCollection formCollection)
        //public IActionResult CreateSubmit(string marka_adi)

        // Kısacası, CreateSubmit action'ını YALNIZCA POST REQUESTLERE CEVAP VER şeklinde KISITLAMIŞ olduk
        [HttpPost]
        public IActionResult CreateSubmit(VehicleMakeDto dto)
        {
            //string vehicleMakeName = HttpContext.Request.Form["marka_adi"];
            //string vehicleMakeName = formCollection["marka_adi"];
            //string vehicleMakeName = marka_adi;

            var result = _vehicleMakeService.Create(dto);

          

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Ok();
            }
        }

        // VehicleMake/Update/5
        // VehicleMake/Update?id=5

        public IActionResult Update(int id)
        {
            var vehicleMakeDto = _vehicleMakeService.GetById(id);

            if (vehicleMakeDto != null)
            {
                return View(vehicleMakeDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update(VehicleMakeDto model)
        {
            var result = _vehicleMakeService.Update(model);

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
        public IActionResult Delete(int id)
        {
            var result = _vehicleMakeService.Delete(id);

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
