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
    public class ClienteAplicacao
    {
        private Conexao conexao;

        private void Inserir(Cliente usr)
        {
            var strQuery = "";
            strQuery += " INSERT INTO CLIENTE (NOME, ENDERECO, TELEFONE, EMAIL, DTNASC, ATIVO) ";
            strQuery += string.Format(" VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                usr.NOME, usr.ENDERECO, usr.TELEFONE, usr.EMAIL, usr.DTNASC, 1);

            using (conexao = new Conexao())
            {
                conexao.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Cliente usr)
        {
            var strQuery = "";
            strQuery += "UPDATE CLIENTE SET ";
            strQuery += string.Format(" NOME = '{0}', ", usr.NOME);
            strQuery += string.Format(" ENDERECO = '{0}', ", usr.ENDERECO);
            strQuery += string.Format(" TELEFONE = '{0}', ", usr.TELEFONE);
            strQuery += string.Format(" EMAIL = '{0}', ", usr.EMAIL);
            strQuery += string.Format(" DTNASC = '{0}', ", usr.DTNASC);
            strQuery += string.Format(" ATIVO = '{0}' ", 1);
            strQuery += string.Format(" WHERE ID_CLIENTE = {0} ", usr.ID_CLIENTE);

            using (conexao = new Conexao())
            {
                conexao.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Cliente usr)
        {
            if (usr.ID_CLIENTE > 0)
                Alterar(usr);
            else
                Inserir(usr);
        }

        public void Bloquear(int id)
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("UPDATE CLIENTE SET ATIVO = 0 WHERE ID_CLIENTE = {0}", id);
                conexao.ExecutaComando(strQuery);
            }
        }

        public List<Cliente> listarTodos()
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM CLIENTE WHERE ATIVO = 1");
                var returnoDataReader = conexao.ExecutaComandoRetorno(strQuery);
                return transformaReaderEmLista(returnoDataReader);
            }
        }

        public Cliente ListarPorId(int id)
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM CLIENTE WHERE ID_CLIENTE = {0} ", id);
                var returnoDataReader = conexao.ExecutaComandoRetorno(strQuery);
                return transformaReaderEmLista(returnoDataReader).FirstOrDefault();
            }
        }

        public List<Cliente> ListarPorNome(string nome)
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM CLIENTE WHERE ATIVO = 1 AND NOME LIKE '{0}%' ", nome);
                var returnoDataReader = conexao.ExecutaComandoRetorno(strQuery);
                return transformaReaderEmLista(returnoDataReader);
            }
        }

        private List<Cliente> transformaReaderEmLista(SqlDataReader reader)
        {
            var ListaClientes = new List<Cliente>();

            while (reader.Read())
            {
                var objeto = new Cliente()
                {
                    ID_CLIENTE = int.Parse(reader["ID_CLIENTE"].ToString()),
                    NOME = reader["NOME"].ToString(),
                    ENDERECO = reader["ENDERECO"].ToString(),
                    TELEFONE = reader["TELEFONE"].ToString(),
                    EMAIL = reader["EMAIL"].ToString(),
                    DTNASC = DateTime.Parse(reader["DTNASC"].ToString())
                };
                ListaClientes.Add(objeto);
            }
            reader.Close();
            return ListaClientes;
        }

    }
}
