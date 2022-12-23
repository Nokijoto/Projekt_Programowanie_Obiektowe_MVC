namespace Projekt_MVC.Models.Salon
{
    public class SalonViewModel
    {
        public SalonViewModel()
        {
        }
        public List<SalonModel> Salons { get; set; }
        public List<SalonModel> GetSalons()
        {
            Salons = new List<SalonModel>();
            // TODO: Add data from database
            Salons.Add(new SalonModel
            {
                Name = "Salon 1",
                Address = "Adres 1",
                Phone = "123456789",
                Email = "",
            });
            return Salons;
        }
    }
}
