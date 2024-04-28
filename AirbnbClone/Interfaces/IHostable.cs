using AirbnbClone;
using AirbnbClone.Models.DTOs;

namespace AirbnbClone.Interfaces
{
    public interface IHostable
    {
        Task<Models.DataLayer.Host> Create(HostDto host);

        Task<Models.DataLayer.Host?> Update(HostDto newhost);

        Task Delete(int id);

        Task<HostDto?> GetbyId(int Id);
    }
}
