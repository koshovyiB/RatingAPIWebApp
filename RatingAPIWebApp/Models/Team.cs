namespace RatingAPIWebApp.Models
{
    public class Team
    {
        public Team()
        {
            Racers = new List<Racer>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }


        public virtual ICollection<Racer> Racers { get; set; }
    }
}
