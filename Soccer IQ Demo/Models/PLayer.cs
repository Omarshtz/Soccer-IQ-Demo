namespace Soccer_IQ_Demo.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }

        public int Height { get; set; }
        public int Age { get; set; }
        public string MainPosition { get; set; }
        public string OtherPosition { get; set; }
        public string StrongFoot { get; set; }
        public int MarketValue { get; set; }




        public int PLayerStatId { get; set; }
        public List<PlayerStat> PlayerStats { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }


    }
}
