using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface __IVehicleModelService
    {
        VehicleModelDto GetById(int id);
        IEnumerable<VehicleModelDto> GetAll();
        IEnumerable<VehicleModelSummary> GetSummaries();
        IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId);

        CommandResult Create(VehicleModelDto model);
        CommandResult Update(VehicleModelDto model);
        CommandResult Delete(VehicleModelDto model);
        CommandResult Delete(int id);
    }
}
