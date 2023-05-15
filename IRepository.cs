namespace PetShopApp.Repositories
{
    public interface IRepository<T>
    {
        T? Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        void Save();
    }
}
