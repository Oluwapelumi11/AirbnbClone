using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AirbnbClone.Services
{
    public class HostService : IHostable
    {
        private AirbnbContext _context;

        public HostService(AirbnbContext context)
        {
            _context = context;
        }

        async Task<Models.DataLayer.Host> IHostable.Create(HostDto host)
        {
            var newHost = new Models.DataLayer.Host
            {
                PolicyNumber = host.PolicyNumber,
                CreateAt= host.CreateAt,
                Fullname= host.Fullname,
                IsSuperhost= host.IsSuperhost,
                PictureUrl= host.PictureUrl ?? host.ThumbnailUrl,
                ResponseTime= host.ResponseTime,
                About = host.About
            };
            await _context.Hosts.AddAsync(newHost);
            newHost.HostId = await _context.SaveChangesAsync();
            return newHost;
        }

        async Task IHostable.Delete(int id)
        {
            var exists = await _context.Hosts.FirstOrDefaultAsync(h=> h.HostId == id);
            if (exists != null)
            {
                _context.Hosts.Remove(exists);
                await _context.SaveChangesAsync();
            }
        }

        async Task<HostDto?> IHostable.GetbyId(int Id)
        {
            var host = await _context.Hosts.FirstOrDefaultAsync(h => h.HostId == Id);
            if(host != null)
            {
                var newHost = new HostDto
                {
                    PolicyNumber = host.PolicyNumber,
                    CreateAt = host.CreateAt,
                    Fullname = host.Fullname,
                    IsSuperhost = host.IsSuperhost,
                    PictureUrl = host.PictureUrl,
                    ThumbnailUrl = host.PictureUrl,
                    ResponseTime = host.ResponseTime,
                    About = host.About,
                    Location = host.Location,
                    
                };
            return newHost;
            }
            return null;
        }

        async Task<Models.DataLayer.Host?> IHostable.Update(HostDto newhost)
        {
            var oldhost = await _context.Hosts.FirstOrDefaultAsync(h => h.Fullname == newhost.Fullname);
            if (oldhost != null)
            {
                if (newhost.IsSuperhost is not null) oldhost.IsSuperhost = newhost.IsSuperhost;
                if (newhost.CreateAt is not null) oldhost.CreateAt = newhost.CreateAt;
                if (newhost.Fullname is not null) oldhost.Fullname = newhost.Fullname;
                if (newhost.PictureUrl is not null) oldhost.PictureUrl = newhost.PictureUrl;
                if (newhost.PolicyNumber is not null) oldhost.PolicyNumber = newhost.PolicyNumber;
                if (newhost.ResponseTime is not null) oldhost.ResponseTime = newhost.ResponseTime;
                _context.Hosts.Update(oldhost);
                await _context.SaveChangesAsync();
            }
            return oldhost;
        }
    }
}
