using AutoMapper;
using Common;
using Data.Contracts;
using Data.DTOs.Address;
using Entities.User;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository, IScopedDependency
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserAddressRepository(ApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddnewAddress(AddUserAddressDto address)
        {
            var data = _mapper.Map<UserAddress>(address);
            _context.UserAddresses.Add(data);
            _context.SaveChanges();
        }

        public List<UserAddressDto> GetAddress(string userId)
        {
            var address = _context.UserAddresses.Where(p => p.UserId == userId);
            var data = _mapper.Map<List<UserAddressDto>>(address);
            return data;
        }
    }
}
