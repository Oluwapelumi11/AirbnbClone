using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;

namespace AirbnbClone.Services
{
    public class UserService : IManageableUser
    {
        private AirbnbContext _context;

        public UserService(AirbnbContext context)
        {
            _context = context;
        }

        Task<User?> IManageableUser.Delete(User user)
        {
            throw new NotImplementedException();
        }

        Task<User?> IManageableUser.GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        Task<User?> IManageableUser.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<User?> IManageableUser.Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
