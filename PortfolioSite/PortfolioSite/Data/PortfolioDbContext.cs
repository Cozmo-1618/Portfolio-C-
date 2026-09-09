using Microsoft.EntityFrameworkCore;
using PortfolioSite.Models;

namespace PortfolioSite.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Bio> Bios { get; set; }
    }

    /*Think of PortfolioDbContext as your translator between C# and SQL — 
     * it's the piece that knows how to turn db.Skills.Where(s => s.Category == "Language") 
     * into an actual SELECT * FROM Skills WHERE Category = 'Language' behind the scenes. 
     * Each DbSet<T> corresponds to one table — DbSet<Skill> becomes a Skills table, DbSet<Project> becomes a Projects table, and so on. 
     * You already know what a table is from your MySQL work; 
     * EF just lets you design and query those tables using C# classes instead of raw CREATE TABLE and SELECT statements.*/
}
