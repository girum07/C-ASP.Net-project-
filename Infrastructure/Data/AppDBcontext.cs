using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class AppDBcontext : IdentityDbContext<User>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        { }
            DbSet<Ticket> Tickets { get; set; }
            DbSet<Catagory> Catagories { get; set; }
            DbSet<Attachment> Attachments { get; set; }
            DbSet<Disscussion> Disscussions { get; set; }
            DbSet<Priorty> priorties { get; set; }  
            DbSet <Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Ticket>().HasOne(e=>e.RaisedbyUser).
                WithMany().
                OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
            builder.Entity<Disscussion>().HasOne(m => m.Ticket).
                WithMany().
                OnDelete(DeleteBehavior.NoAction);

        }

        }
    }

