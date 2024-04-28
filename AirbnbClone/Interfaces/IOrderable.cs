using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;

namespace AirbnbClone.Interfaces
{
    public interface IOrderable
    {
        Task<Order> Create(OrderDto listing);
        Task<Order?> Update(OrderDto listing);
        Task<Order?> Delete(int id);
        Task<List<OrderDto>> Filter(string label);
        Task<OrderDto?> Get(int id);
        Task<List<OrderDto?>?> Get(string user);
    }
}
