namespace ZaferTurizm.Business.Services
{
    public interface ICrudService<TDto, TSummary>
    {
        CommandResult Create(TDto model);
        CommandResult Update(TDto model);
        CommandResult Delete(TDto model);
        CommandResult Delete(int id);

        TDto? GetById(int id);
        IEnumerable<TDto> GetAll();

        TSummary? GetSummaryById(int id);
        IEnumerable<TSummary> GetSummaries();
    }
}
