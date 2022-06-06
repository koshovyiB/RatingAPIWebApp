namespace RatingAPIWebApp.Models
{
    public class Country
    {
        public Country()
        {
            Racers = new List<Racer>();
            Teams = new List<Team>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Racer> Racers { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
