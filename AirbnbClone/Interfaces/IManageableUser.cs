using AirbnbClone.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace AirbnbClone.Interfaces
{
    public interface IManageableUser
    {
        Task<User?> Update(User user);

        Task<User?> Delete(User user);

        Task<User?> GetById(int id);

        Task<User?> GetByEmail(string email);
    }
}
