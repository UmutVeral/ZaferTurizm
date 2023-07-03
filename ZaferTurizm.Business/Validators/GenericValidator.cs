using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators
{
    public class GenericValidator<TEntity> : IValidator<TEntity>
        where TEntity : class, IEntity, new()
    {
        public ValidationResult Validate(TEntity entity)
        {
            return new ValidationResult();
        }
    }
}
