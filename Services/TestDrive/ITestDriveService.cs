using Projekt_MVC.Models.TDriveModel;

namespace Projekt_MVC.Services.TestDrive
{
    public interface ITestDriveService
    {
        public List<TestDriveModel> GetTestDrives();
        void CreateTestDrive(string imie, string nazwisko, string pesel, string data, int nrtel, int CarID);
        void DeleteTestDrive(int id);
        public TestDriveModel GetTestDrives(int id);
        public void EditTestDrive(long id, string imie, string nazwisko, string pesel, string data, int nrtel, int CarID);
       
        
    }
}
