using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface __IVehicleDefinitionService
    {
        CommandResult Create(VehicleDefinitionDto model);
        CommandResult Update(VehicleDefinitionDto model);
        CommandResult Delete(VehicleDefinitionDto model);
        CommandResult Delete(int id);

        VehicleDefinitionDto? GetById(int id);
        IEnumerable<VehicleDefinitionDto> GetAll();
        IEnumerable<VehicleDefinitionSummary> GetSummaries();
    }
}
