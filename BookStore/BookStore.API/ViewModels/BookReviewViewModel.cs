using BookStore.API.Models;

namespace BookStore.API.ViewModels
{
    public class BookReviewViewModel
    {
        public int Id { get; set; }
        public BookViewModel Book { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
