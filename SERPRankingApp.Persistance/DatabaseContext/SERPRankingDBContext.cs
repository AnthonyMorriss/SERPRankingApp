using Microsoft.EntityFrameworkCore;
using SERPRankingApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERPRankingApp.Persistance.DatabaseContext
{
    public class SERPRankingDBContext : DbContext
    {
        public SERPRankingDBContext(DbContextOptions<SERPRankingDBContext> options) : base(options)
        {
        }

        public DbSet<SearchResult> SearchResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SearchResult>(entity =>
            {
                entity.HasKey(e => e.Id); // Ensure primary key is set
                entity.Property(e => e.SearchTerm).IsRequired(); // Ensure SearchTerm is not null
                entity.Property(e => e.TargetUrl).IsRequired(); // Ensure TargetUrl is not null
                entity.Property(e => e.SearchDate).IsRequired(); // Ensure SearchDate is not null
            });

            modelBuilder.Entity<SearchResult>().HasData(
               new SearchResult
               {
                   Id = 1,
                   SearchTerm = "Land",
                   TargetUrl = "https://www.infotrack.co.uk",
                   RankResults = new List<int> { 1, 2, 3 },
                   SearchDate = new DateTime(2025, 05, 06)
               },
               new SearchResult
               {
                   Id = 2,
                   SearchTerm = "Info",
                   TargetUrl = "https://www.infotrack.co.uk",
                   RankResults = new List<int> { 1, 4, 5 },
                   SearchDate = new DateTime(2025, 05,06)
               }
           );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
