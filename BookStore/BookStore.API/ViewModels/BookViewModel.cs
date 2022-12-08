using BookStore.API.Models;

namespace BookStore.API.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
        public AuthorViewModel Author { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public TranslatorViewModel Translator { get; set; }
        public CategoryViewModel Category { get; set; }
        

    }
}
