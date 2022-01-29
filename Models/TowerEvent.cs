namespace cTower.Models
{
    public class TowerEvent
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImgUrl { get; set; }
        public int Tickets { get; set; }

        public int Price { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }
    }
}