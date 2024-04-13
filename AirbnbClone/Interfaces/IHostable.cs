using AirbnbClone;

namespace AirbnbClone.Interfaces
{
    public interface IHostable
    {
        Task<Models.DataLayer.Host> Create(Models.DataLayer.Host host);

        Task<Models.DataLayer.Host> Update(Models.DataLayer.Host oldhost, Models.DataLayer.Host newhost);

        Task<Models.DataLayer.Host?> Delete(Models.DataLayer.Host oldhost, Models.DataLayer.Host newhost);

        Task<Models.DataLayer.Host> GetbyId(int Id);
    }
}
