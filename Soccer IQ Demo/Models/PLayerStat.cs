using System.Numerics;

namespace Soccer_IQ_Demo.Models
{
    public class PlayerStat
    {
        public int Id { get; set; }
        public int Goals { get; set; }
        public int Asissts { get; set; }
        public int MinutesPlayed { get; set; }
        public int Matches { get; set; }
        public string Season { get; set; }
        public double XG { get; set; }
        public double XA { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
