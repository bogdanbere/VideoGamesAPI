using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VideoGamesCollection.Models
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public string? Description { get; set; }

    }
}
