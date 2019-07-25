
namespace RedSpark.Thot.Api.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        TRepository GetRepository<TRepository>();
        bool Commit();
    }
}
