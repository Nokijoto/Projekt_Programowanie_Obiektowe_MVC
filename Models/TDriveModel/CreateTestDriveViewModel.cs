using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt_MVC.Models.TDriveModel
{
    public class CreateTestDriveViewModel
    {
        

            public int ID { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Pesel { get; set; }
            public string Data { get; set; }
            public int NrTel { get; set; }

    }
}
