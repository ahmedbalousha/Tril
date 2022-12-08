using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Services.Auth
{
    public interface IJwtTokenGenerator
    {
        string Generate(AppUser user);
    }
}
