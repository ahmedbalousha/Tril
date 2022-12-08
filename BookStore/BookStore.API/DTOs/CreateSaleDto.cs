using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class CreateSaleDto
    {
        public string AppUserId { get; set; }
        public int BookId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        

    }
}
