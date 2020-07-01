using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.API.Identity
{
    public sealed class IdentityDb : IdentityDbContext<IdentityUser>
    {
        public IdentityDb(DbContextOptions<IdentityDb> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}