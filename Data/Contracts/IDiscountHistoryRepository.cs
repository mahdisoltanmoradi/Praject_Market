using Data.DTOs;
using Entities.Discount;

namespace Data.Contracts
{
    public interface IDiscountHistoryRepository
    {
        void InsertDiscountUsageHistory(int DiscountId, int OrderId);

        DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId);
        PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId,
       string? userId, int pageIndex, int pageSize);
    }
}
