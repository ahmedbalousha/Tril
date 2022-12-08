namespace BookStore.API.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
