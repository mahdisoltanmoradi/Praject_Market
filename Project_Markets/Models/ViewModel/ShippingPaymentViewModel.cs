using Data.DTOs.Address;
using Data.DTOs.Baskets;
using System.Collections.Generic;

namespace Project_Markets.Models.ViewModels
{
    public class ShippingPaymentViewModel
    {
        public BasketDto Basket { get; set; }
        public List<UserAddressDto> UserAddresses { get; set; }

    }
}
