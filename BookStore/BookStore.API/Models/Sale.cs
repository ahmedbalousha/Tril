namespace BookStore.API.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Sale()
        {
            OrderDate = DateTime.Now;   
        }

    }
   
}
