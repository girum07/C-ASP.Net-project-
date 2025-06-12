using Domain.Entity;
using Infrastructure.Extension;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.Net.Sockets;

namespace infrastructure.Data
{
    public class AppDBcontext : IdentityDbContext<User>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        { }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Attachment> Attachments { get; set; }
        DbSet<Disscussion> Disscussions { get; set; }
        DbSet<Priority> priorties { get; set; }
        DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.GenerateSeed();
            builder.Entity<Ticket>().HasOne(e => e.RaisedbyUser).
                WithMany().
                OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
            builder.Entity<Disscussion>().HasOne(m => m.Ticket).
                WithMany().
                OnDelete(DeleteBehavior.NoAction);

        }

    }
}