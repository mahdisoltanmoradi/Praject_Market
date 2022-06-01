using Data.DTOs.Address;
using Entities.User;
using System.Collections.Generic;

namespace Data.Contracts
{
    public interface IUserAddressRepository : IRepository<UserAddress>
    {
        List<UserAddressDto> GetAddress(string userId);
        void AddnewAddress(AddUserAddressDto address);
    }
}
