namespace RatingAPIWebApp.Models
{
    public class Racer
    {
        public Racer()
        {
            Races = new List<Race>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Wins { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<Race> Races { get; set; }
    }
}
