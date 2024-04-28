using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace AirbnbClone.Services
{
    public class OrderService : IOrderable
    {
        private AirbnbContext _context;

        public OrderService(AirbnbContext context)
        {
            _context = context;
        }

   
       

       

        public async Task<Order> Create(OrderDto dto)
        {
            var order = ConvertToOrder(dto);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> Update(OrderDto dto)
        {
            var exists = await _context.Orders.FirstOrDefaultAsync(o => o._id == dto._id);
            if (exists != null)
            {
                UpdateOrder(dto, exists);
                _context.Orders.Update(exists);
                await _context.SaveChangesAsync();
            }
            return exists;
        }

        public async Task<Order?> Delete(int id)
        {
            var exists = await _context.Orders.FirstOrDefaultAsync(o=> o._id== id);
            if(exists != null)
            {
                 _context.Orders.Remove(exists);
                await _context.SaveChangesAsync();
            }
            return exists;
        }

        public  Task<List<OrderDto>> Filter(string label)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDto?> Get(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o._id == id);
            return ConvertToOrderDto(order);
        }

        public async Task<List<OrderDto?>?> Get(string user)
        {
            var orders = await _context.Orders.Where(o => o.BuyerName == user).ToListAsync();
            var orderDtos = new List<OrderDto> { };
            if (orders != null)
            {
                foreach(var order in orders)
                {
                    if(order != null)
                    {
                        orderDtos.Add(ConvertToOrderDto(order));
                    }
                }
            }
            return orderDtos;
        }






        private static OrderDto? ConvertToOrderDto(Order order)
        {
            if (order == null) return null;
            var dto = new OrderDto
            {
                _id = order._id,
                buyer = new Buyer
                {
                    _id = order.BuyerId,
                    fullname =order.BuyerName
                },
                totalPrice = order.TotalPrice,
                startDate = order.StartDate,
                endDate = order.EndDate,
                guests = new Guest
                {
                    Adults = order.GuestAdult,
                    Children = order.Guestchildren,
                    Infants = order.Guestinfant,
                    Pets = order.Guestpets
                },
                stay = new Sta
                {
                    _id = order.StayId,
                    name = order.StayName,
                    price = order.price,
                },
                host = new Hos
                {
                    _id = order.HostId,
                    fullname = order.HostName,
                },
                status = order.Status,
            };
            return dto;
        }

        private static Order ConvertToOrder(OrderDto dto)
        {
            if(dto == null) return null;
            var order = new Order
            {
                _id = dto._id,
                BuyerId = dto.buyer._id,
                BuyerName = dto.buyer.fullname,
                TotalPrice = dto.totalPrice,
                StartDate = dto.startDate,
                EndDate = dto.endDate,
                GuestAdult = dto.guests.Adults,
                Guestchildren = dto.guests.Children,
                Guestinfant = dto.guests.Infants,
                Guestpets = dto.guests.Pets,
                StayId = dto.stay._id,
                StayName = dto.stay.name,
                price = dto.stay.price,
                HostId = dto.host._id,
                HostName = dto.host.fullname,
                Status = dto.status
            };
            return order;
        }

        private static void UpdateOrder(OrderDto dto,Order order)
        {
            if (dto == null) return;
            order.BuyerId = dto.buyer._id;
            order.BuyerName = dto.buyer.fullname;
            order.TotalPrice = dto.totalPrice;
            order.StartDate = dto.startDate;
            order.EndDate = dto.endDate;
            order.GuestAdult = dto.guests.Adults;
            order.Guestchildren = dto.guests.Children;
            order.Guestinfant = dto.guests.Infants;
            order.Guestpets = dto.guests.Pets;
            order.StayId = dto.stay._id;
            order.StayName = dto.stay.name;
            order.price = dto.stay.price;
            order.HostId = dto.host._id;
            order.HostName = dto.host.fullname;
            order.Status = dto.status;
        }
    }
}
