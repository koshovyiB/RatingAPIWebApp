using System.ComponentModel.DataAnnotations;

namespace RatingAPIWebApp.Models
{
    public class Race
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public int Year { get; set; }
        public int RacerId { get; set; }
        public virtual Racer Racer { get; set; }
    }
}
