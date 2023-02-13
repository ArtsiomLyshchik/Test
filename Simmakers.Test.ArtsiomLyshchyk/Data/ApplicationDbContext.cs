using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simmakers.Test.ArtsiomLyshchyk.Models;

namespace Simmakers.Test.ArtsiomLyshchyk.Data;

public class ApplicationDbContext : IdentityDbContext<BaseUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}