using Common.Enums;
using Entities.Order;

namespace Data.Contracts
{
    public interface IOrderRepository:IRepository<Order>
    {
        int CreateOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod);
    }
}
