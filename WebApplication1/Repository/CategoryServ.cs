using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CategoryServ : IRepository<Category>
    {

        public ElDbContext Context { get; set; }
        public CategoryServ(ElDbContext context)
        {
            Context = context;
           
        }

        public List<Category> GetAll()
        {
            return Context.Categories.ToList();
        }

        public Category GetDetails(int id)
        {
            return Context.Categories.Find(id);
        }

        public void Insert(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }

        public void Update(int id, Category category)
        {

            Category CategoryUpdated = Context.Categories.Find(id);
            CategoryUpdated.Name = category.Name;     
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Context.Categories.Remove(Context.Categories.Find(id));
            Context.SaveChanges();
        }
    }
}
