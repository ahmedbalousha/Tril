using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class UpdateBookReviewDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
