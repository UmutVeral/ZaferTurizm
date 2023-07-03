using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    // CRUD: Create, Read, Update, Delete
    public interface __IVehicleMakeService
    {
        CommandResult Create(VehicleMakeDto model);
        CommandResult Update(VehicleMakeDto model);
        CommandResult Delete(VehicleMakeDto model);
        CommandResult Delete(int id);

        VehicleMakeDto GetById(int id);
        IEnumerable<VehicleMakeDto> GetAll();
    }
}
