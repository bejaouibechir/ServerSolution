namespace DAL.Repository
{
    //Abstraction
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(int id);

        void Update(int id, T newentity);

        T GetById(int id);
        List<T> GetAll();
        List<T> FindAll(Predicate<T> predicate);
    }
}
