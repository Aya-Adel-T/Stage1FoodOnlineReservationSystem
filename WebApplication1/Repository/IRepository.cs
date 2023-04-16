using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T? GetDetails(int id);
        public void Insert(T t);
        public void Update(int id, T t);
        public void Delete(int id);
    }
}
