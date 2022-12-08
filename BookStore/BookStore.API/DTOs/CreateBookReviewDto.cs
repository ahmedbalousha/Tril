using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class CreateBookReviewDto
    {
        public string AppUserId { get; set; }
        public int BookId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
