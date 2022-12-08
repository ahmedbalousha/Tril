namespace BookStore.API.DTOs
{
    public class CreateContantUsDto
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
