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
    public class TratamentoAplicacao
    {
        private Conexao conexao;

        private void Inserir(Profissional_TratamentoViewModel tto)
        {
            using (conexao = new Conexao())
            {
                SqlConnection Con = Conexao.Con;
                SqlCommand Cmd = new SqlCommand("PR_IN_PROFISSIONAL_TRATAMENTO", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@ID_PROFISSIONAL", tto.PROFISSIONAL.ID_PROFISSIONAL);
                Cmd.Parameters.AddWithValue("@DESCRICAO", tto.DESCRICAO);
                Cmd.ExecuteNonQuery();
            }
        }

        private void Alterar(Profissional_TratamentoViewModel tto)
        {
            var strQuery = "";
            strQuery += "UPDATE TRATAMENTO SET ";
            strQuery += string.Format("DESCRICAO = '{0}' ", tto.DESCRICAO);
            strQuery += string.Format(" WHERE ID_TRATAMENTO = {0} ", tto.ID_TRATAMENTO);

            using (conexao = new Conexao())
            {
                conexao.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Profissional_TratamentoViewModel tto)
        {
            if (tto.ID_TRATAMENTO > 0)
                Alterar(tto);
            else
                Inserir(tto);
        }

        public void Bloquear(int id)
        {
            using (conexao = new Conexao())
            {
                var strQuery = string.Format("UPDATE TRATAMENTO SET ATIVO = 0 WHERE ID_TRATAMENTO = {0}", id);
                conexao.ExecutaComando(strQuery);
            }
        }

        public List<Profissional_TratamentoViewModel> listarTodos()
        {
            using (conexao = new Conexao())
            {
                List<Profissional_TratamentoViewModel> ListaTratamentos = new List<Profissional_TratamentoViewModel>();

                SqlConnection Con = Conexao.Con;
                SqlCommand Cmd = new SqlCommand("PR_SEL_PROFISSIONAL_TRATAMENTO", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@PROFISSIONAL", "%");
                Cmd.ExecuteNonQuery();

                SqlDataAdapter ada = new SqlDataAdapter(Cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                DataRowCollection linhas = ds.Tables[0].Rows;

                foreach (DataRow linha in linhas)
                {
                    Profissional_TratamentoViewModel tratamento = new Profissional_TratamentoViewModel();
                    Profissional p = new Profissional();

                    tratamento.ID_TRATAMENTO = int.Parse(linha["ID_TRATAMENTO"].ToString());
                    tratamento.DESCRICAO = linha["TRATAMENTO"].ToString();

                    p.NOME = linha["PROFISSIONAL"].ToString();
                    tratamento.PROFISSIONAL = p;

                    ListaTratamentos.Add(tratamento);
                }

                return ListaTratamentos;
            }
        }

        public List<Profissional_TratamentoViewModel> ListarPorNome(string nome)
        {
            using (conexao = new Conexao())
            {
                List<Profissional_TratamentoViewModel> ListaTratamentos = new List<Profissional_TratamentoViewModel>();

                SqlConnection Con = Conexao.Con;
                SqlCommand Cmd = new SqlCommand("PR_SEL_NOME_PROFISSIONAL_TRATAMENTO", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@PROFISSIONAL", nome);
                Cmd.ExecuteNonQuery();

                SqlDataAdapter ada = new SqlDataAdapter(Cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                DataRowCollection linhas = ds.Tables[0].Rows;

                foreach (DataRow linha in linhas)
                {
                    Profissional_TratamentoViewModel tratamento = new Profissional_TratamentoViewModel();
                    Profissional p = new Profissional();

                    tratamento.ID_TRATAMENTO = int.Parse(linha["ID_TRATAMENTO"].ToString());
                    tratamento.DESCRICAO = linha["DESCRICAO"].ToString();

                    p.NOME = linha["NOME"].ToString();
                    tratamento.PROFISSIONAL = p;

                    ListaTratamentos.Add(tratamento);
                }

                return ListaTratamentos;
            }
        }

        public List<Profissional_TratamentoViewModel> ListarPorId(int id)
        {
            using (conexao = new Conexao())
            {
                List<Profissional_TratamentoViewModel> ListaTratamentos = new List<Profissional_TratamentoViewModel>();

                SqlConnection Con = Conexao.Con;
                SqlCommand Cmd = new SqlCommand("PR_SEL-ID_PROFISSIONAL_TRATAMENTO", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@ID_TRATAMENTO", id);
                Cmd.ExecuteNonQuery();

                SqlDataAdapter ada = new SqlDataAdapter(Cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                DataRowCollection linhas = ds.Tables[0].Rows;

                foreach (DataRow linha in linhas)
                {
                    Profissional_TratamentoViewModel tratamento = new Profissional_TratamentoViewModel();
                    Profissional p = new Profissional();

                    tratamento.ID_TRATAMENTO = int.Parse(linha["ID_TRATAMENTO"].ToString());
                    tratamento.DESCRICAO = linha["TRATAMENTO"].ToString();

                    p.NOME = linha["PROFISSIONAL"].ToString();
                    tratamento.PROFISSIONAL = p;

                    ListaTratamentos.Add(tratamento);
                }

                return ListaTratamentos;
            }
        }
    }
}
