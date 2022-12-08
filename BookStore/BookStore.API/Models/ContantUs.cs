namespace BookStore.API.Models
{
    public class ContantUs
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
        public DateTime ReadAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public ContantUs()
        {
            CreatedAt = DateTime.Now;

        }

    }
}
