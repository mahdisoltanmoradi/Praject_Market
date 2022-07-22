using Data.DTOs.Orders;
using System.Collections.Generic;

namespace Data.Contracts
{
    public interface ICustomerOrdersRepository
    {
        List<MyOrderDto> GetMyOrder(string userId);
    }
}
