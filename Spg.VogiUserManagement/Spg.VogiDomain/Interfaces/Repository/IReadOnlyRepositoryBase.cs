namespace Spg.Vogi.Domain.Interfaces.Repository;

public interface IReadOnlyRepositoryBase<T> where T : IEntity
{
    T GetById(int id);
    IEnumerable<T> GetAll();
}
