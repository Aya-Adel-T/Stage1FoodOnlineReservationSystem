using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public class UserRepoService:IRepository<User>
    {
        public ElDbContext Context { get; set; }

        public UserRepoService(ElDbContext context)
        {
            Context = context;
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public User? GetDetails(int id)
        {
            return Context.Users.Find(id);
        }

        public void Insert(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public void UpdateBayza(int id, User user)
        {
            User userUpdated = Context.Users.Find(id);
            userUpdated.UserName = user.UserName;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Users.Remove(Context.Users.Find(id));
            Context.SaveChanges();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
