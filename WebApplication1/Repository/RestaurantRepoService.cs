using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Repository
{
    public class RestaurantRepoService : IRepository<Restaurant>
    {
        public ElDbContext Context { get; set; }
        public RestaurantRepoService(ElDbContext context)
        {
            Context = context;

        }

        public List<Restaurant> GetAll()
        {
            return Context.Restaurants.ToList();
        }

        public Restaurant? GetDetails(int id)
        {
            return Context.Restaurants.Find(id);
        }

        public void Insert(Restaurant restaurant)
        {
            Context.Restaurants.Add(restaurant);
            Context.SaveChanges();
        }

        public void Update(int id, Restaurant restaurant)
        {
            Restaurant RestaurantUpdated = Context.Restaurants.Find(id);
            RestaurantUpdated.Name = restaurant.Name;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Restaurants.Remove(Context.Restaurants.Find(id));
            Context.SaveChanges();
        }
    }
}
