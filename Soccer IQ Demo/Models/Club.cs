namespace Soccer_IQ_Demo.Models
{
    public class Club
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Logo { get; set; }
        public int PlayerId { get; set; }
        public List<Player> Players { get; set; }
    }
}
