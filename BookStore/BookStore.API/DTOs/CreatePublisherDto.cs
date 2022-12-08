using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class CreatePublisherDto
    {
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
    }
}
