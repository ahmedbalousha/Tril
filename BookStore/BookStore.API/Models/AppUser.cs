using Microsoft.AspNetCore.Identity;
using System.Net;

namespace BookStore.API.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public List<UserFav> UserFavs { get; set; }
        public List<Sale> Sales { get; set; }



    }
}
