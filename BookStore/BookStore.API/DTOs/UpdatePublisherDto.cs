using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class UpdatePublisherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
