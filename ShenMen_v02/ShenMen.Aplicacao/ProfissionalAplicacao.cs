using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenMen.Dominio;
using ShenMen.Repositorio;

namespace ShenMen.Aplicacao
{
    public class ProfissionalAplicacao
    {
        private Conexao conexao;

        private void Inserir(Profissional usr)
        {
            var strQuery = "";
            strQuery += " INSERT INTO PROFISSIONAL (NOME, TELEFONE, EMAIL, SENHA, ATIVO) ";
            strQuery += string.Format(" VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",
                usr.NOME, usr.TELEFONE, usr.EMAIL, usr.SENHA, 1);

            using (conexao = new Conexao())
            {
                conexao.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Profissional usr)
        {
            var strQuery = "";
            strQuery += "UPDATE PROFISSIONAL SET ";
            strQuery += string.Format(" NOME = '{0}', ", usr.NOME);
            strQuery += string.Format(" TELEFONE = '{0}', ", usr.TELEFONE);
            strQuery += string.Format(" EMAIL = '{0}', ", usr.EMAIL);
            strQuery += string.Format(" SENHA = '{0}', ", usr.SENHA);
            strQuery += string.Format(" ATIVO = '{0}' ", 1);
            strQuery += string.Format(" WHERE ID_PROFISSIONAL = {0} ", usr.ID_PROFISSIONAL);

            using (conexao = new Conexao())
            {
                conexao.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Profissional usr)
        {
            if (usr.ID_PROFISSIONAL > 0)
                Alterar(usr);
            else
                Inserir(usr);
        }

        public void Bloquear(int id)
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("UPDATE PROFISSIONAL SET ATIVO = 0 WHERE ID_PROFISSIONAL = {0}", id);
                conexao.ExecutaComando(strQuery);
            }
        }

        public List<Profissional> listarTodos()
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM PROFISSIONAL WHERE ATIVO = 1");
                var returnoDataReader = conexao.ExecutaComandoRetorno(strQuery);
                return transformaReaderEmLista(returnoDataReader);
            }
        }

        public Profissional ListarPorId(int id)
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM PROFISSIONAL WHERE ID_PROFISSIONAL = {0} ", id);
                var returnoDataReader = conexao.ExecutaComandoRetorno(strQuery);
                return transformaReaderEmLista(returnoDataReader).FirstOrDefault();
            }
        }

        public List<Profissional> ListarPorNome(string nome)
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM PROFISSIONAL WHERE ATIVO = 1 AND NOME LIKE '{0}%' ", nome);
                var returnoDataReader = conexao.ExecutaComandoRetorno(strQuery);
                return transformaReaderEmLista(returnoDataReader);
            }
        }

        private List<Profissional> transformaReaderEmLista(SqlDataReader reader)
        {
            var ListaProfissional = new List<Profissional>();

            while (reader.Read())
            {
                var objeto = new Profissional()
                {
                    ID_PROFISSIONAL = int.Parse(reader["ID_PROFISSIONAL"].ToString()),
                    NOME = reader["NOME"].ToString(),
                    TELEFONE = reader["TELEFONE"].ToString(),
                    EMAIL = reader["EMAIL"].ToString(),
                    SENHA = reader["SENHA"].ToString()
                };
                ListaProfissional.Add(objeto);
            }
            reader.Close();
            return ListaProfissional;
        }
    }
}
