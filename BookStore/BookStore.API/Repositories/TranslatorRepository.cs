using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class TranslatorRepository : ITranslatorRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public TranslatorRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<TranslatorViewModel>> GetAll(string? serachKey)
        {
            var translators = await _context.Translators.Where(x => x.Name.Contains(serachKey)
            || string.IsNullOrEmpty(serachKey)).Select(x => new TranslatorViewModel()
            {   Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return translators;
        }

        public async Task<CreateTranslatorDto> Create(CreateTranslatorDto dto)
        {
            var translator = _mapper.Map<Translator>(dto);
            await _context.Translators.AddAsync(translator);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateTranslatorDto> Update(UpdateTranslatorDto dto)
        {
            var translator = await _context.Translators.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (translator == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedTranslator = _mapper.Map(dto, translator);
                var updatedTranslatorVM = _mapper.Map<Translator, UpdateTranslatorDto>(translator, dto);
                _context.Translators.Update(updatedTranslator);
                await _context.SaveChangesAsync();
                return updatedTranslatorVM;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var translator = await _context.Translators.FindAsync(id);
            if (translator == null)
                return false;
            else
            {
                _context.Translators.Remove(translator);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
