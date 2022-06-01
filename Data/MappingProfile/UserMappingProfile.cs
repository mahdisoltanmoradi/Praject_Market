using AutoMapper;
using Data.DTOs.Address;
using Entities.Order;
using Entities.User;

namespace Data.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<AddUserAddressDto, UserAddress>();
            CreateMap<UserAddress, Address>();
        }
    }
}
