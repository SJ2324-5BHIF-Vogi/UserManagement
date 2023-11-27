namespace Spg.Vogi.Domain.Interfaces.Repository;

public interface IModifyRepositoryBase<T> where T : class, IEntity
{
    void Create(T entity);
    void Delete(int id);
}
