using BookStore.API.Models;

namespace BookStore.API.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; } = string.Empty;
        public string PostalCode { get; set; }
        public ZoneViewModel Zone { get; set; }
    }
}
