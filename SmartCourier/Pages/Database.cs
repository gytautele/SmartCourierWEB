using System.IO;
using System.Data.SQLite;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

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

        public DataTable GetData()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID, timeChosen, price, status FROM Package"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public SQLiteDataReader select ()
        {
            string query = "SELECT * FROM Package";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            SQLiteDataReader result = myCommand.ExecuteReader();
            return result;
        }

        public void insertUser(string name, string surname, string address, string postalCode, string country)
        {
            int id = Globals.id;
            string query = "INSERT INTO Client ('ID', 'name', 'surname', 'address', 'postalCode', 'country', 'userID') VALUES ('" + id + "','" + name + "','" + surname + "','" + address + "','" + postalCode + "','" + country + "','" + id + "');";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            var result = myCommand.ExecuteNonQuery();
        }

        public void addPackage(int timeChosen, string X, string Y, string eMail)
        {
            string delivered = "-";
            string cId = "1";
            int price = timeChosen * 5;
            string status = "In Shop";
            int id = Globals.id;
            string query = "INSERT INTO Package ('ID', 'clientID', 'timeChosen', 'price', 'deliveredAt', 'status', 'X', 'Y') VALUES ('" + id + "','" + cId + "','" + timeChosen + "','" + price + "','" + delivered + "','" + status + "','" + X + "','" + Y + "');";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            var result = myCommand.ExecuteNonQuery();
        }

        public void Register(string username, string password)
        {
            string bol = "False";
            int id = Globals.id;
            string query = "INSERT INTO User ('ID', 'eMail', 'password', 'Session') VALUES ('" + id + "','" + username + "','" + password + "','" + bol +"');";
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

        public SQLiteDataReader Remember(string username)
        {
            System.Diagnostics.Debug.WriteLine("Remember");
            string query = "SELECT eMail, password FROM User";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            SQLiteDataReader result = myCommand.ExecuteReader();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    if (result["eMail"].ToString() == username)
                    {
                        return result;
                    }
                    else
                        continue;
                }
            }
            else
            {
                result.Close();
                return null;
            }
            result.Close();
            return null;
        }
    }
}
