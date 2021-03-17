using System.IO;
using System.Data.SQLite;
namespace SmartCourier.Pages
{
    public class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            myConnection = new SQLiteConnection("Data Souurce=database.sqlite3");

            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
            }
        }

        public void OpenConnection ()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        public SQLiteDataReader select ()
        {
            string query = "SELECT * FROM albms";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            SQLiteDataReader result = myCommand.ExecuteReader();
            return result;
        }

        public void insert(string username, string password)
        {
            string query = "INSERT INTO albums ('title, 'artist') VALUES (@username, @password)";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            var result = myCommand.ExecuteNonQuery();
        }

    }
}
