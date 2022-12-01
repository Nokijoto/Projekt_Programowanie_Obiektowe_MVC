using Npgsql;

namespace Projekt_MVC.Services
{
    public class DatabaseConnection
    {
        // Create connection to postgresql database
        NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=test;Password=test123;Database=test");
      //  conn.Open();
      ///      
       // conn.Close();
        //return list from sql query
    }
}
