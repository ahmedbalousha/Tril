﻿namespace BookStore.API.DTOs
{
    public class UpdateBookSuggestionDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Email { get; set; }
        public string PublisherName { get; set; }
        public string AuthorName { get; set; }
        public string Notes { get; set; }
    }
}
