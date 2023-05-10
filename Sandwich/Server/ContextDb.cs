using MySql.Data.MySqlClient;
using Sandwich.Shared;
using System.Data;

namespace Sandwich.Server
{
    public class ContextDb
    {
        string conn = "server=10.150.0.123;uid=sa;pwd=burbero2023;database=SandwichQuiz5H";
        public List<Utente> GetUtenti()
        {
            List<Utente> list = new List<Utente>();
            string query = "Select * from Utenti";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new Utente
                        {
                            Mail = Convert.ToString(dr[0]),
                            Username = Convert.ToString(dr[1]),
                            Password = Convert.ToString(dr[2]),
                            Nome = Convert.ToString(dr[3]),
                            Cognome = Convert.ToString(dr[4])
                        });

                    }
                }
            }
            return list;
        }

        public bool Add(Utente obj)
        {
            string query = "insert into Utenti values(@mail,@username,@password,@nome,@cognome)";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.Parameters.AddWithValue("@nome", obj.Nome);
                    cmd.Parameters.AddWithValue("@cognome", obj.Cognome);
                    cmd.Parameters.AddWithValue("@username", obj.Username);
                    cmd.Parameters.AddWithValue("@mail", obj.Mail);
                    cmd.Parameters.AddWithValue("@password", obj.Password);
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
