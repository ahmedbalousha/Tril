using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string About { get; set; }
        public IFormFile Image { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int? TranslatorId { get; set; }
        public int CategoryId { get; set; }
       

    }
}
