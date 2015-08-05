using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShenMen.Aplicacao;
using ShenMen.Dominio;
using System.Web.Script.Serialization;

namespace ShenMen.Web.UI.Controllers
{
    public class ClienteController : Controller
    {

        public ActionResult Index()
        {
            var appCliente = new ClienteAplicacao();
            var listaCliente = appCliente.listarTodos();

            return View(listaCliente);
        }

        [HttpPost]
        public string Pesquisar(string nome)
        {
            var appCliente = new ClienteAplicacao();
            var listaCliente = appCliente.ListarPorNome(nome);
            return new JavaScriptSerializer().Serialize(listaCliente);
        }

        //-------------------------------------------------------

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Cliente usr)
        {
            if (ModelState.IsValid)
            {
                var appCliente = new ClienteAplicacao();
                appCliente.Salvar(usr);
                return RedirectToAction("Index");
            }
            return View(usr);
        }

        //-------------------------------------------------------

        public ActionResult Editar(int id)
        {
            var appCliente = new ClienteAplicacao();
            var cliente = appCliente.ListarPorId(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente usr)
        {
            if (ModelState.IsValid)
            {
                var appCliente = new ClienteAplicacao();
                appCliente.Salvar(usr);
                return RedirectToAction("Index");
            }
            return View(usr);
        }

        //-------------------------------------------------------

        public ActionResult Detalhes(int id)
        {
            var appCliente = new ClienteAplicacao();
            var cliente = appCliente.ListarPorId(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        //-------------------------------------------------------

        public ActionResult Bloquear(int id)
        {
            var appCliente = new ClienteAplicacao();
            var cliente = appCliente.ListarPorId(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Bloquear")]
        [ValidateAntiForgeryToken]
        public ActionResult BloquearCliente(int id)
        {
            var appCliente = new ClienteAplicacao();
            appCliente.Bloquear(id);
            return RedirectToAction("Index");

        }

    }
}

