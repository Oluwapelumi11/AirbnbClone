using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;

namespace AirbnbClone.Services
{
    public class HostService :IHostable
    {
        private AirbnbContext _context;

        public HostService(AirbnbContext context)
        {
            _context = context;
        }

        Task<Models.DataLayer.Host> IHostable.Create(Models.DataLayer.Host host)
        {
            throw new NotImplementedException();
        }

        Task<Models.DataLayer.Host?> IHostable.Delete(Models.DataLayer.Host oldhost, Models.DataLayer.Host newhost)
        {
            throw new NotImplementedException();
        }

        Task<Models.DataLayer.Host> IHostable.GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        Task<Models.DataLayer.Host> IHostable.Update(Models.DataLayer.Host oldhost, Models.DataLayer.Host newhost)
        {
            throw new NotImplementedException();
        }
    }
}
