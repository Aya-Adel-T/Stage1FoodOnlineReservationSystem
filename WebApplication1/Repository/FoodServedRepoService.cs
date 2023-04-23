using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class FoodServedRepoService: BaseRepoService, IRepository<FoodServed>
    {
        public FoodServedRepoService(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }

        public List<FoodServed> GetAll()
        {
            List<FoodServed> foodServedList = new List<FoodServed>();

            using (var customContext = Context.CreateDbContext())
            {
                foodServedList = customContext.FoodServed.ToList();
            }

            using (var customContext = Context.CreateDbContext())
            {
                foreach (var foodServed in foodServedList)
                {
                    foodServed.Restaurant = customContext.Restaurants.First(r => r.Id == foodServed.RestaurantID);
                    foodServed.Category = customContext.Categories.First(c => c.Id == foodServed.CategoryID);
                }
            }

            return foodServedList;
        }

        public FoodServed? GetDetails(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                return customContext.FoodServed.Find(id);
            }
        }

        public void Insert(FoodServed foodServed)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.FoodServed.Add(foodServed);
                customContext.SaveChanges();
            }
        }

        public void UpdateBayza(int id, FoodServed t)
        {
            using (var customContext = Context.CreateDbContext())
            {
                FoodServed foodUpdated = customContext.FoodServed.Find(id);
                foodUpdated.Name = t.Name;
                customContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.FoodServed.Remove(new FoodServed() { Id = id});
                customContext.SaveChanges();
            }
        }

        public void Update(FoodServed entity)
        {
            throw new NotImplementedException();
        }
    }
}
