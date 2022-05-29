using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Data.Context
{
    public class AutenticationContext : IdentityDbContext<IdentityUser>
    {
        public AutenticationContext(DbContextOptions<AutenticationContext> options) : base(options)
        {
        }
    }
}
