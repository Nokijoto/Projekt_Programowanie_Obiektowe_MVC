using Projekt_MVC.Models.TDriveModel;

namespace Projekt_MVC.Services.TestDrive
{
    public interface ITestDriveService
    {
        void CreateTestDrive(string imie, string nazwisko, string pesel, string data, int nrtel);
        void DeleteTestDrive(int id);
        void EditTestDrive(long id, string imie, string nazwisko, string pesel, string data, int nrtel);
        List<TestDriveModel> GetTestDrives();
        public TestDriveModel GetTestDrives(int id);
    }
}
