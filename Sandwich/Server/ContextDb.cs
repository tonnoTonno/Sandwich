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

        public List<Test> GetTest()
        {
            List<Test> list = new List<Test>();
            string query = "Select * from Tests";
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
                        list.Add(new Test
                        {
                            IdTest = Convert.ToInt32(dr[0]),
                            creatore = Convert.ToString(dr[1]),
                            Aperto = Convert.ToBoolean(dr[2]),
                            Durata = Convert.ToInt32(dr[3]),
                            Nome = Convert.ToString(dr[4])
                        });

                    }
                }
            }
            return list;
        }

        public List<Domanda> GetQuestion()
        {
            List<Domanda> list = new List<Domanda>();
            string query = "Select * from Domande";
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
                        list.Add(new Domanda
                        {
                            Progressivo = Convert.ToInt32(dr[0]),
                            Consegna = Convert.ToString(dr[1]),
                            IdTest = Convert.ToInt32(dr[2])
                        });

                    }
                }
            }
            return list;
        }

        public List<Opzione> GetAnswer()
        {
            List<Opzione> list = new List<Opzione>();
            string query = "Select * from Opzioni";
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
                        list.Add(new Opzione
                        {
                            ProgressivoOpzione = Convert.ToInt32(dr[0]),
                            Testo = Convert.ToString(dr[1]),
                            OpzioneCorretta = Convert.ToBoolean(dr[2]),
                            ProgDomanda = Convert.ToInt32(dr[3]),
                            IdTest = Convert.ToInt32(dr[4])
                        }) ;

                    }
                }
            }
            return list;
        }

        public bool AddUtente(Utente obj)
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

        public bool AddTest(Test obj)
        {
            string query = "insert into Tests values(@IdTest,@creatore,@Aperto,@Durata,@Nome)";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.Parameters.AddWithValue("@IdTest", obj.IdTest);
                    cmd.Parameters.AddWithValue("@creatore", obj.creatore);
                    cmd.Parameters.AddWithValue("@Aperto", obj.Aperto);
                    cmd.Parameters.AddWithValue("@Durata", obj.Durata);
                    cmd.Parameters.AddWithValue("@Nome", obj.Nome);
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

        public bool AddQuestion(Domanda obj)
        {
            string query = "insert into Domande values(@Progressivo,@Consegna,@IdTest)";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.Parameters.AddWithValue("@Progressivo", obj.Progressivo);
                    cmd.Parameters.AddWithValue("@Consegna", obj.Consegna);
                    cmd.Parameters.AddWithValue("@IdTest", obj.IdTest);
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

        public bool AddAnswer(Opzione obj)
        {
            string query = "insert into Opzioni values(@ProgressivoOpzione,@Testo,@OpzioneCorretta,@ProgDomanda,@IdTest)";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.Parameters.AddWithValue("@ProgressivoOpzione", obj.ProgressivoOpzione);
                    cmd.Parameters.AddWithValue("@Testo", obj.Testo);
                    cmd.Parameters.AddWithValue("@OpzioneCorretta", obj.OpzioneCorretta);
                    cmd.Parameters.AddWithValue("@ProgDomanda", obj.ProgDomanda);
                    cmd.Parameters.AddWithValue("@IdTest", obj.IdTest);
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
