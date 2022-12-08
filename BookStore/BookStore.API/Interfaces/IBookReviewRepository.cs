using BookStore.API.DTOs;

namespace BookStore.API.Interfaces
{
    public interface IBookReviewRepository
    {
        Task<CreateBookReviewDto> Create(CreateBookReviewDto dto);
        Task<double> GetBookRating(int bookId);
        Task<bool> Delete(int id);
        Task<UpdateBookReviewDto> Update(UpdateBookReviewDto dto);
    }
}
