using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface IVehicleModelService : ICrudService<VehicleModelDto, VehicleModelSummary>
    {
        IEnumerable<VehicleModelDto> GetByMakeId(int makeId);
    }
}
