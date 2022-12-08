namespace BookStore.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int? TranslatorId { get; set; }
        public Translator Translator { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Sale> Sales { get; set; }
        public List<UserFav> UserFavs { get; set; }
        public List<BookReview> BookReviews { get; set; }


    }
}
