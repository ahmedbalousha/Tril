using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class CreateAddressDto
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; } = string.Empty;
        public string PostalCode { get; set; }
        public int ZoneId { get; set; }
    }
}
