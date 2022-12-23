using Projekt_MVC.Context;
using Projekt_MVC.Models.TDriveModel;

namespace Projekt_MVC.Services.TestDrive
{
    public class TestDriveService : ITestDriveService
    {
        private readonly MainContext _TestDriveService;
        public TestDriveService(MainContext context)
        {
            _TestDriveService = context;
        }

        public List<TestDriveModel> GetTestDrives()
        {
            return _TestDriveService.TestDrives.ToList();
        }
        public void CreateTestDrive( string imie, string nazwisko, string pesel, string data, int nrtel)
        {
            var lastId = _TestDriveService.TestDrives.OrderByDescending(x => x.ID).FirstOrDefault()?.ID;
            if (lastId != null)
            {
                var newTD = new TestDriveModel()
                {
                    ID = (int)lastId + 1,
                    Imie = imie,
                    Nazwisko = nazwisko,
                    Pesel = pesel,
                    Data = data,
                    NrTel = nrtel,
                };
                _TestDriveService.TestDrives.Add(newTD);
                _TestDriveService.SaveChanges();
            }

        }
        public async void DeleteTestDrive(int id)
        {

            TestDriveModel TD;
            var tdt = _TestDriveService.TestDrives.Find(id);
            TD = tdt;
            if (TD != null)
            {
                _TestDriveService.TestDrives.Remove(TD);
                _TestDriveService.SaveChanges();
            }
        }

        public TestDriveModel GetTestDrives(int id)
        {
            return _TestDriveService.TestDrives.FirstOrDefault(x => x.ID == id) ?? new TestDriveModel();
        }

        public void EditTestDrive(long id, string imie, string nazwisko, string pesel, string data, int nrtel)
        {
            var TD = _TestDriveService.TestDrives.FirstOrDefault(x => x.ID == id);
            if (TD != null)
            {
                TD.Imie = imie;
               TD.Nazwisko = nazwisko;
                TD.Pesel = pesel;
                TD.Data = data;
                TD.NrTel = nrtel;
                _TestDriveService.Update(TD);
                _TestDriveService.SaveChanges();
            }
        }

    }
}

