namespace BookStore.API.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; } = string.Empty;
        public string PostalCode { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
        public List<AppUser> AppUsers { get; set; }

    }
}
