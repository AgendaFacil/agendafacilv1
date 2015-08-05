using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShenMen.Aplicacao;
using ShenMen.Dominio;

namespace ShenMen.Web.UI.Controllers
{
    public class ConsultaController : Controller
    {
        public ActionResult Index()
        {
            ProfissionalAplicacao Profissionais = new ProfissionalAplicacao();
            ViewBag.ListaProfissionais = new SelectList(Profissionais.listarTodos(), "NOME", "NOME");

            HorarioAplicacao Horarios = new HorarioAplicacao();
            ViewBag.ListaHorarios = new SelectList(Horarios.listarTodos(), "DESCRICAO", "DESCRICAO");

            return View();
        }

        [HttpPost]
        public ActionResult Index(Consulta consulta)
        {
            if (consulta != null)
            {
                var appConsulta = new ConsultaAplicacao();
                var resultado = appConsulta.listarConsulta(consulta);
                return RedirectToAction("Listar", resultado);
            }

            return View();
        }

        //-------------------------------------------------------

        public ActionResult Listar(Consulta consulta)
        {
            return View(consulta);
        }

        //-------------------------------------------------------

        public ActionResult Cadastrar()
        {
            ProfissionalAplicacao Profissionais = new ProfissionalAplicacao();
            ViewBag.ListaProfissionais = new SelectList(Profissionais.listarTodos(), "ID_PROFISSIONAL", "NOME");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Profissional_TratamentoViewModel tto)
        {

            if (tto != null)
            {
                var appTratamento = new TratamentoAplicacao();
                appTratamento.Salvar(tto);
                return RedirectToAction("Index");
            }

            return View(tto);
        }

        //-------------------------------------------------------

        public ActionResult Editar(int id)
        {
            var appTratamento = new TratamentoAplicacao();
            var tratamento = appTratamento.ListarPorId(id).FirstOrDefault();

            if (tratamento == null)
                return HttpNotFound();

            return View(tratamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Profissional_TratamentoViewModel tto)
        {
            if (tto != null)
            {
                var appCliente = new TratamentoAplicacao();
                appCliente.Salvar(tto);
                return RedirectToAction("Index");
            }
            return View(tto);
        }

        //-------------------------------------------------------

        public ActionResult Detalhes(int id)
        {
            var appTratamento = new TratamentoAplicacao();
            var tratamento = appTratamento.ListarPorId(id).FirstOrDefault();

            if (tratamento == null)
                return HttpNotFound();

            return View(tratamento);
        }

        //-------------------------------------------------------

        public ActionResult Excluir(int id)
        {
            var appTratamento = new TratamentoAplicacao();
            var tratamento = appTratamento.ListarPorId(id).FirstOrDefault();

            if (tratamento == null)
                return HttpNotFound();

            return View(tratamento);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirUsuario(int id)
        {
            var appTratamento = new TratamentoAplicacao();
            appTratamento.Bloquear(id);
            return RedirectToAction("Index");

        }

    }
}
