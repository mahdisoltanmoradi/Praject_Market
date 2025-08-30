using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Enums;
using Data.DTOs.Orders;
using Entities.Order;

namespace Data.Contracts
{
    public interface IOrderRepository:IRepository<Order>
    {
        int CreateOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod);
        Task<List<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int orderId);
    }
}
