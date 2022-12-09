namespace Projekt_MVC.Models.Car
{
    public class CarModel
    {
        public CarModel()
        {
        }

        //public int ID { get; set; }
        //public string Name { get; set; }
        //public EngineEnum Gender { get; set; }
        //public string City { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public EngineEnum Engine { get; set; }
        public int HorsePower { get; set; }


        //public List<CarModel> Cars { get; set; }
        //public int /*List<CarModel>*/ GetCars()
        //{


        //    var Cartest = new CarModel()
        //    {
        //        ID = 1,
        //        Name = "BMW",
        //        Model = "M3",
        //        Color = "Black",
        //        Year = "2019",
        //        Price = "100000",
        //        Description = "This is a BMW M3",
        //        Engine = (int)EngineEnum.Petrol,
        //        HorsePower = 500
        //    };
        //    return 0;
        //}
    }
}
