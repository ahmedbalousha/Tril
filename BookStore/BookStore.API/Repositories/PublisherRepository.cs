using AutoMapper;
using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Services;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public PublisherRepository(BookStoreDbContext context, IMapper mapper, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }



        public async Task<List<PublisherViewModel>> GetAll(string? serachKey)
        {
            var publishers = await _context.Publishers.Where(x => x.Name.Contains(serachKey)
            || string.IsNullOrEmpty(serachKey)).Select(x => new PublisherViewModel()
            {   Id = x.Id,
                Name = x.Name,
                Logo = x.Logo,
            }).ToListAsync();
            return publishers;
        }

        public async Task<CreatePublisherDto> Create(CreatePublisherDto dto)
        {
            var publisher = _mapper.Map<Publisher>(dto);
            if (dto.Logo != null)
            {
                publisher.Logo = await _fileService.SaveFile(dto.Logo, "Images");
            }
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdatePublisherDto> Update(UpdatePublisherDto dto)
        {
            var publisher = await _context.Publishers.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (publisher == null)
                throw new ArgumentException("Item Not Found");
            else
            {

                var updatedPublisher = _mapper.Map(dto, publisher);
                var updatedPublisherVM = _mapper.Map<Publisher, UpdatePublisherDto>(publisher, dto);
                _context.Publishers.Update(updatedPublisher);
                await _context.SaveChangesAsync();
                return updatedPublisherVM;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
                return false;
            else
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
