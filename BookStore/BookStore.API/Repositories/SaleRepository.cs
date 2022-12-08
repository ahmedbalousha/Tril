using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interface;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;


        public SaleRepository(BookStoreDbContext context, IMapper mapper , IBookRepository bookRepository)
        { 
            _context = context;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<List<SaleViewModel>> GetAll()
        {
            var sales = await _context.Sales.ToListAsync();
            var salesVM = _mapper.Map<List<SaleViewModel>>(sales);
            return salesVM;
        }

        public async Task<CreateSaleDto> Create(CreateSaleDto dto)
        {
            var bookDetials = await _bookRepository.GetById(dto.BookId);
            var sale = new Sale()
            {
                Amount = bookDetials.Price,
                BookId = dto.BookId,
                AppUserId = dto.AppUserId,
                TotalPrice = dto.Amount
            };
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
            return dto;
        }
       

        public async Task<bool> Delete(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return false;
            else
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
                return true;
            }

        }
    }
}
