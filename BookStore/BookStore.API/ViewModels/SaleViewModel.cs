using BookStore.API.Models;

namespace BookStore.API.ViewModels
{
    public class SaleViewModel
    {
        public BookViewModel Book { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        

    }
}
