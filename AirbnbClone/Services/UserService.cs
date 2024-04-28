using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Services
{
    public class UserService : IManageableUser
    {
        private AirbnbContext _context;

        public UserService(AirbnbContext context)
        {
            _context = context;
        }

        async Task<User?> IManageableUser.Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        async Task<User?> IManageableUser.GetByEmail(string username)
        {
            var exists = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return exists;
        }

        async Task<User?> IManageableUser.GetById(int id)
        {
            var exists = await _context.Users.FirstOrDefaultAsync(u => u._id == id);
            return exists;
        }

        async Task<User?> IManageableUser.Update(User user)
        {
            var olduser = await _context.Users.FirstOrDefaultAsync(u => u._id == user._id);
            if (olduser != null)
            {
                if (user.Listings is not null) olduser.Listings = user.Listings;
                if (user.Password is not null) olduser.Password = user.Password;
                if (user.UserMsg is not null) olduser.UserMsg = user.UserMsg;
                if (user.HostMsg is not null) olduser.UserMsg = user.HostMsg;
                //if (user.Reviews is not null) olduser.Reviews = user.Reviews;
                if (user.Username is not null) olduser.Username = user.Username;
                if (user.Fullname is not null) olduser.Fullname = user.Fullname;
                if (user.ImgUrl is not null) olduser.ImgUrl = user.ImgUrl;
                _context.Users.Update(olduser);
                await _context.SaveChangesAsync();
            }
            return olduser;
        }
    }
}
