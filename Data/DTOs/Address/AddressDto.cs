using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs.Address
{
    public class UserAddressDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string ReciverName { get; set; }
    }

    public class AddUserAddressDto
    {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string ReciverName { get; private set; }
        public string UserId { get; set; }
    }

}
