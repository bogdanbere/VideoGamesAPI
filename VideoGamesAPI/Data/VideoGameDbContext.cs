using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VideoGamesCollection.Models;

namespace VideoGamesCollection.Data
{
    public class VideoGameDbContext : DbContext
    {
        public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : base(options) { }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
}