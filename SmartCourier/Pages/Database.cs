using System.IO;
using System.Data.SQLite;
namespace SmartCourier.Pages
{
    public class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            System.Diagnostics.Debug.WriteLine("Susikure");
            

            if (!File.Exists("./database.sqlite3"))
            {
                System.Diagnostics.Debug.WriteLine("neegzistuoja");
                SQLiteConnection.CreateFile("database.sqlite3");
            }
        }

        public void OpenConnection ()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                System.Diagnostics.Debug.WriteLine("Open");
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
            string query = "SELECT * FROM Package";
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

        public void update(string session, string username)
        {
            string query = "UPDATE User SET Session=@session WHERE eMail=@username";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            var result = myCommand.ExecuteNonQuery();
        }

        public bool LogIn(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine("Loginas");
            string query = "SELECT eMail, password FROM User";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            SQLiteDataReader result = myCommand.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    if (result["eMail"].ToString() == username && result["password"].ToString() == password)
                    {
                        result.Close();
                        return true;
                    }
                    else
                        continue;
                }
            }
            else
            {
                result.Close();
                return false;
            }
            result.Close();
            return false;
        }

    }
}
