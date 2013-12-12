using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace DBLib
{
    public class LoginDB
    {
        private System.Data.SqlClient.SqlDataReader reader;

        
        public long ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Logado { get; set; }


        public LoginDB ()
		{
			
        }

        public LoginDB(System.Data.SqlClient.SqlDataReader reader)
        {
            this.reader = reader;
            this.ID = reader.GetInt64(reader.GetOrdinal("Id"));
            this.Login = reader.GetString(reader.GetOrdinal("Login"));
            this.Senha = reader.GetString(reader.GetOrdinal("Senha"));

        }

        public LoginDB(string l, string s)
        {
            this.Login = l;
            this.Senha = s;

        }
        public bool Autenticar ()
        {
            if (Login == "binhara" && Senha == "123")
                return Logado = true;

            return false;
                
        }

        public static LoginDB[] GetAll()
        {
            var sql = "SELECT * FROM PERSON ORDER BY Login;";
            List<LoginDB> result = new List<LoginDB>();

            using (var conn = Repository.GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            result.Add(new LoginDB(reader));
                    }
                }
            }

            return result.ToArray();
        }

        public static LoginDB Get(long id)
        {
            var sql = string.Format("SELECT * FROM Login WHERE Id = {0};", id);

            using (var conn = Repository.GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return new LoginDB(reader);
                        else
                            return null;
                    }
                }
            }
        }

        public void Delete()
        {
            var sql = string.Format("DELETE FROM Login WHERE Id = {0};", this.ID);

            using (var conn = Repository.GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Save()
        {
            using (var conn = Repository.GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {

                    if (this.ID <= 0)
                    {
                        cmd.CommandText = @"INSERT INTO Login ( Id, login, senha)  VALUES (@Id,@Login,	@Senha)";
                        Parameters(cmd);
                        this.ID = (long)cmd.ExecuteScalar();
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE Login SET  Login = @Login, Senha = @Senha WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", this.ID);
                        Parameters(cmd);

                        cmd.ExecuteNonQuery();

                    }
                }
            }
        }

        void Parameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", this.ID);
            cmd.Parameters.AddWithValue("@Login", this.Login);
            cmd.Parameters.AddWithValue("@Senha", this.Senha);

        }
    }
}
