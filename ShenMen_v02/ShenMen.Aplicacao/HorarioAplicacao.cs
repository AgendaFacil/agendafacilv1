using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using ShenMen.Dominio;
using ShenMen.Repositorio;

namespace ShenMen.Aplicacao
{
    public class HorarioAplicacao
    {
        private Conexao conexao;

        public List<Horario> listarTodos()
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM HORARIO");
                var returnoDataReader = conexao.ExecutaComandoRetorno(strQuery);
                return transformaReaderEmLista(returnoDataReader);
            }
        }

        private List<Horario> transformaReaderEmLista(SqlDataReader reader)
        {
            var ListaHorario = new List<Horario>();

            while (reader.Read())
            {
                var objeto = new Horario()
                {
                    ID_HORARIO = int.Parse(reader["ID_HORARIO"].ToString()),
                    DESCRICAO = reader["DESCRICAO"].ToString(),
                };
                ListaHorario.Add(objeto);
            }
            reader.Close();
            return ListaHorario;
        }

    }
}