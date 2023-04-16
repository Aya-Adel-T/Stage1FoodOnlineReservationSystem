using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class FoodServedRepoService:IRepository<FoodServed>
    {
        public ElDbContext Context { get; set; }

        public FoodServedRepoService(ElDbContext context)
        {
            Context = context;
        }

        public List<FoodServed> GetAll()
        {
            return Context.FoodServed.ToList();
        }

        public FoodServed? GetDetails(int id)
        {
            return Context.FoodServed.Find(id);
        }

        public void Insert(FoodServed foodServed)
        {
            Context.FoodServed.Add(foodServed);
            Context.SaveChanges();
        }

        public void Update(int id, FoodServed t)
        {
            FoodServed foodUpdated = Context.FoodServed.Find(id);
            foodUpdated.Name = t.Name;     
            Context.SaveChanges();        }

        public void Delete(int id)
        {
            Context.FoodServed.Remove(Context.FoodServed.Find(id));
            Context.SaveChanges();
        }
    }
}
