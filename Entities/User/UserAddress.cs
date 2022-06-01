using Entities.Common;

namespace Entities.User
{
    public class UserAddress : BaseEntity<int>
    {
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string UserId { get; private set; }
        public string ReciverName { get; private set; }

        public UserAddress(string city, string state,
            string zipCode, string postalAddress,
            string userId, string recivername)
        {
            this.City = city;
            State = state;
            ZipCode = zipCode;
            PostalAddress = postalAddress;
            UserId = userId;
            ReciverName = recivername;
        }

        public UserAddress()
        {

        }
    }
}
