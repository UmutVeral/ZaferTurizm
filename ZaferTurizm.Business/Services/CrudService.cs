using System.Diagnostics;
using System.Linq.Expressions;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Services
{
    public abstract class CrudService<TDto, TSummary, TEntity> : ICrudService<TDto, TSummary>
        where TEntity : class, IEntity, new()
    {
        protected readonly TourDbContext _dbContext;
        protected readonly IValidator<TEntity> _validator;

        public CrudService(TourDbContext dbContext, IValidator<TEntity> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        protected abstract TEntity MapToEntity(TDto dto);
        protected abstract Expression<Func<TEntity, TDto>> DtoMapper { get; }
        protected abstract Expression<Func<TEntity, TSummary>> SummaryMapper { get; }

        public virtual CommandResult Create(TDto model)
        {
            try
            {
                var entity = MapToEntity(model);

                var validationResult = _validator.Validate(entity);

                if (!validationResult.IsValid)
                {
                    var validationMessages = string.Join('\n', validationResult.Messages);

                    return CommandResult.Failure(validationMessages);
                }

                _dbContext.Set<TEntity>().Add(entity);
                _dbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public virtual CommandResult Delete(TDto model)
        {
            var entity = MapToEntity(model);

            return Delete(entity.Id);
        }

        public virtual CommandResult Delete(int id)
        {
            try
            {
                //var entity = _dbContext.Set<TEntity>().Find(id);
                var entity = new TEntity() { Id = id };

                if (entity != null)
                {
                    _dbContext.Set<TEntity>().Remove(entity);
                    _dbContext.SaveChanges();

                    return CommandResult.Success();
                }
                else
                {
                    return CommandResult.Failure("Kayıt bulunamadı.");
                }

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            try
            {
                return _dbContext.Set<TEntity>()
                    .Select(DtoMapper)
                    .ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TDto>();
            }
        }

        public virtual TDto? GetById(int id)
        {
            try
            {
                //var dtoMapper = new Func<TEntity, TDto>(MapToDto);

                return _dbContext.Set<TEntity>()
                    .Where(entity => entity.Id == id)
                    .Select(DtoMapper)
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public virtual IEnumerable<TSummary> GetSummaries()
        {
            try
            {
                //var summaryMapper = new Func<TEntity, TSummary>(MapToSummary);

                return _dbContext.Set<TEntity>()
                    .Select(SummaryMapper)
                    .ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TSummary>();
            }
        }

        public virtual TSummary? GetSummaryById(int id)
        {
            try
            {
                return _dbContext.Set<TEntity>()
                    .Where(entity => entity.Id == id)
                    .Select(SummaryMapper)
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public virtual CommandResult Update(TDto model)
        {
            try
            {
                var entity = MapToEntity(model);

                _dbContext.Set<TEntity>().Update(entity);
                _dbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }
    }
}
