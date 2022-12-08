namespace BookStore.API.Models
{
    public class UserFav
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
