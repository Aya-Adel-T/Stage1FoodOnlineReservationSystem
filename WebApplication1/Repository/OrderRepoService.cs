using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class OrderRepoService: IRepository<Order>
    {
        public ElDbContext Context { get; set; }

        public OrderRepoService(ElDbContext context)
        {
            Context = context;
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order? GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order t)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Order t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
