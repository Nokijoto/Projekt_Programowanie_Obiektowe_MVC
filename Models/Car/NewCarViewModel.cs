namespace Projekt_MVC.Models.Car
{
    public class NewPersonViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public EngineEnum Engine { get; set; }
        public int HorsePower { get; set; }
    }
}
