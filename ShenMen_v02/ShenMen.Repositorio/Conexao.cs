using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ShenMen.Repositorio
{
    public class Conexao : IDisposable
    {
        public static SqlConnection Con;

        public Conexao()
        {
			Con = new SqlConnection(@"Data Source=yptmie4trr.database.windows.net;Initial Catalog=DB_AgendaOnline;Persist Security Info=True;User ID=administrador;Password=0wn#r#scritorio");
            Con.Open();
        }

        public void Dispose()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, Con);
            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, Con);
            return cmdComando.ExecuteReader();
        }

    }
}
