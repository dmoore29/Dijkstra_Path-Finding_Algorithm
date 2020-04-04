using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcPathContext : DbContext
    {
        public MvcPathContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Grid> G { get; set; }
    }
}