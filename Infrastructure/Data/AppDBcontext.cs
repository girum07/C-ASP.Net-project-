using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class AppDBcontext : IdentityDbContext<User>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {
        }
    }
}
