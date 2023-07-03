using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface IBusTripService: ICrudService<BusTripDto,BusTripInfo>
    {
        IEnumerable<BusTripInfo> GetTripsWithRouteId(int id);
        BusTripDetails GetBusTripDetails(int id);
    }
}
