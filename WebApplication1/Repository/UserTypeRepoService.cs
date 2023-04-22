using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public class UserTypeRepoService:IRepository<UserType>
    {
        public ElDbContext Context { get; set; }

        public UserTypeRepoService(ElDbContext context)
        {
            Context = context;
        }

        public List<UserType> GetAll()
        {
            return Context.UserTypes.ToList();
        }

        public UserType? GetDetails(int id)
        {
            return Context.UserTypes.Find(id);
        }

        public void Insert(UserType userType)
        {
            Context.UserTypes.Add(userType);
            Context.SaveChanges();
        }

        public void UpdateBayza(int id, UserType userType)
        {
            UserType userTypeUpdated = Context.UserTypes.Find(id);
            userTypeUpdated.Name = userType.Name;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.UserTypes.Remove(Context.UserTypes.Find(id));
            Context.SaveChanges();
        }

        public void Update(UserType entity)
        {
            throw new NotImplementedException();
        }
    }
}
