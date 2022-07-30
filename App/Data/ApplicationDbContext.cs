using App.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using App.Models;

namespace App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext([NotNullAttribute] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<GeneralData> GeneralDatas { get; set; }
    }
}
