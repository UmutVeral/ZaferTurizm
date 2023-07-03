using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    // Command: Create, Update, Delete
    // Query:   Read

    public class __VehicleMakeService : __IVehicleMakeService
    {
        private readonly TourDbContext _tourDbContext;

        // parametre -> metotta tanımlanmış, dışarıdan gelen değerleri karşılayacak olan değişken
        // argüman -> parametreye gönderilmiş değer
        public __VehicleMakeService(TourDbContext tourDbContext)
        {
            if (tourDbContext == null)
            {
                //throw new ArgumentNullException("tourDbContext");
                throw new ArgumentNullException(nameof(tourDbContext));
            }

            _tourDbContext = tourDbContext;
        }

        public CommandResult Create(VehicleMakeDto model)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return CommandResult.Failure("Marka adı boş geçilemez");
                }

                // Mapping
                var vehicleMakeEntity = new VehicleMake()
                {
                    Name = model.Name
                };

                _tourDbContext.VehicleMakes.Add(vehicleMakeEntity);
                _tourDbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public CommandResult Delete(VehicleMakeDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model null olamaz");
            }

            // Bu metot içerisinde tüm Delete akışını ayrıca implement etmeye gerek yok
            // Zaten bu işi Id üzerinden yapabilen aşağıdaki Delete(id) implementation'ı mevcut
            // O yüzden bu metot çağırıldığında model.Id değerini aşağıdaki metoda göndererek
            // pratik bir kodlama yapabiliriz
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var entity = new VehicleMake() { Id = id };

            // klasik yöntem
            // Önce kaydı oku (entity izlenmeye başlıyor), sonra Remove ile Context nesnesine silinmesi
            // gerektiğini bildir (State'i Deleted olarak işaretlenecek)
            // entity = _tourDbContext.VehicleMakes.Find(id); 

            try
            {
                _tourDbContext.VehicleMakes.Remove(entity);
                _tourDbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Bir hata meydana geldi, sistem yöneticisine başvurun");

                //return CommandResult.Error(ex, "Bir hata meydana geldi....");
            }
        }

        public IEnumerable<VehicleMakeDto> GetAll()
        {
            try
            {
                return _tourDbContext.VehicleMakes
                    .Select(vm => new VehicleMakeDto()
                    {
                        Id = vm.Id,
                        Name = vm.Name
                    })
                    .ToList();

                //var allVehicleMakes = _tourDbContext.VehicleMakes.ToList();

                //var dtoList = new List<VehicleMakeDto>();
                //foreach (var vehicleMake in allVehicleMakes)
                //{
                //    dtoList.Add(new VehicleMakeDto()
                //    {
                //        Id = vehicleMake.Id,
                //        Name = vehicleMake.Name
                //    });
                //}

                //return dtoList;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                // Tekil bir kayıt için;
                // Kaydın olma durumuna Instance
                // Kaydın olmama durumuna null

                // Koleksiyon tipideki bir veri için
                // Verinin olma durumu Instance (1 veya birden fazla kayıt içerir şekilde)
                // Verinin olmama durumu boş koleksiyon

                // koleksiyonlar için null değerinden mümkün olduğunca kaçınmak gerekir. null durumu
                // bir koleksiyonun boş olduğu anlamını taşımamalı

                //return new List<VehicleMakeDto>();
                return Enumerable.Empty<VehicleMakeDto>();
            }
        }

        public VehicleMakeDto GetById(int id)
        {
            try
            {
                // Find -> DbSet üzerinde PK değeri ile bir kaydı bulmaya yarayan metot
                var vehicleMake = _tourDbContext.VehicleMakes.Find(id);

                // Single -> yazdığınız kritere göre mutlaka 1 adet kayıt olmalı
                // SingleOrDefault -> yazdığınız kriter karşılığında 1 veya hiç kayıt olmalı
                // First -> yazdığınız kriter karşılığında mutlaka 1 veya daha fazla kayıt olmalı, First metodu
                // bu kayıtlardan birincisini döndürecek

                // Özetle; Linq metotlarında Tekil kayıt döndürmeye yarayan Single, First, Last metotlarının
                // filtre kriterine yazdığınız ifadenin karşılığında kayıt dönmeme ihtimali varsa o durumda
                // bu metotların OrDefault versiyonunu kullanın

                // Aşağıda SingleOrDefault kullanarak ID değerine göre tek kayıt okuma örneği
                // teknik olarak yukarıdaki Find metodu ile aynı işi yapıyor. Sentaks olarak çağırma şekilleri farklı
                //vehicleMake = _tourDbContext.VehicleMakes.SingleOrDefault(vm => vm.Id == id);

                if (vehicleMake == null)
                {
                    return null;
                }

                var vehicleMakeDto = new VehicleMakeDto()
                {
                    Id = vehicleMake.Id,
                    Name = vehicleMake.Name
                };

                return vehicleMakeDto;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public CommandResult Update(VehicleMakeDto model)
        {
            if (model == null)
            {
                // Genel olarak bu tekniğe Guard veya Defensive Coding deniyor
                //throw new ArgumentNullException(nameof(model), "VehicleMakeDto nesnesi null değer olamaz");
                return CommandResult.Failure("Model nesnesi null olamaz");
            }

            // Validation
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return CommandResult.Failure("Marka adı boş geçilemez");
            }

            var entity = new VehicleMake()
            {
                Id = model.Id,
                Name = model.Name
            };

            try
            {
                _tourDbContext.VehicleMakes.Update(entity);
                _tourDbContext.SaveChanges();

                // Eğer dotnet Core değil de klasik .NET Framework ile EF kullanılıyor olsaydı
                // 1. En klasik yöntem
                //var vehicleMake1 = _tourDbContext.VehicleMakes.Find(model.Id);
                //vehicleMake1.Name = model.Name;
                //_tourDbContext.SaveChanges();

                // 2. Attach yöntemi (DB'den kaydı okumaya gerek kalmadan)
                //var vehicleMake2 = new VehicleMake()
                //{
                //    Id = model.Id,
                //    Name = model.Name
                //};
                //var entry = _tourDbContext.Attach(vehicleMake2);
                //entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //_tourDbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Bir hata meydana geldi. Sistem yöneticisine başvurun");
            }
        }
    }
}
