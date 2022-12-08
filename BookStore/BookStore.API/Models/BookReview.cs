namespace BookStore.API.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }

    }
}
