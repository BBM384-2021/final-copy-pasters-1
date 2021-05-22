using Web_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Web_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Choice> Choices { get; set; }
        public DbSet<BanRecord> BanRecords { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<OfflineEvent> OfflineEvents { get; set; }
        
        public DbSet<OnlineEvent> OnlineEvents { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReviewAndRate> ReviewAndRates { get; set; }
        public DbSet<SubClub> SubClubs { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<SubClubUser> SubClubUsers { get; set; }
        
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().OwnsMany(p => p.Choices, a =>
            {
                a.WithOwner().HasForeignKey("QuestionId");
                a.Property<int>("Id");
                a.HasKey("Id");
            });
        
            modelBuilder.Entity<Post>().OwnsMany(p => p.Comments, a =>
            {
                a.WithOwner().HasForeignKey("PostId");
                a.Property<int>("Id");
                a.HasKey("Id");
            });

            modelBuilder.Entity<SubClubUser>().HasKey(p => new {p.SubClubId, p.UserId});
        }
    }
}