using FeedbackApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.DAL
{
    public class ApDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }

        public ApDbContext(DbContextOptions<ApDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

    }
}
