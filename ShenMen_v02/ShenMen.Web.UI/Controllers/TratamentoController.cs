using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShenMen.Aplicacao;
using ShenMen.Dominio;
using System.Data;
using System.Web.Script.Serialization;

namespace ShenMen.Web.UI.Controllers
{
    public class TratamentoController : Controller
    {
        public ActionResult Index()
        {
            var appTratamento = new TratamentoAplicacao();
            var listaTratamento = appTratamento.listarTodos();

            return View(listaTratamento);
        }

        [HttpPost]
        public string Pesquisar(string nome)
        {
            var appTratamento = new TratamentoAplicacao();
            var listaTratamento = appTratamento.ListarPorNome(nome);
            return new JavaScriptSerializer().Serialize(listaTratamento);
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

        public ActionResult Bloquear(int id)
        {
            var appTratamento = new TratamentoAplicacao();
            var tratamento = appTratamento.ListarPorId(id).FirstOrDefault();

            if (tratamento == null)
                return HttpNotFound();

            return View(tratamento);
        }

        [HttpPost, ActionName("Bloquear")]
        [ValidateAntiForgeryToken]
        public ActionResult BloquearUsuario(int id)
        {
            var appTratamento = new TratamentoAplicacao();
            appTratamento.Bloquear(id);
            return RedirectToAction("Index");

        }

    }
}
