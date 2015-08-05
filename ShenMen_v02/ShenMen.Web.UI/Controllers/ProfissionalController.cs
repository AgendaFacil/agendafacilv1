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
    public class ProfissionalController : Controller
    {

        public ActionResult Index()
        {
            var appProfissional = new ProfissionalAplicacao();
            var listaProfissional = appProfissional.listarTodos();

            return View(listaProfissional);
        }

        [HttpPost]
        public string Pesquisar(string nome)
        {
            var appProfissional = new ProfissionalAplicacao();
            var listaProfissional = appProfissional.ListarPorNome(nome);
            return new JavaScriptSerializer().Serialize(listaProfissional);
        }

        //-------------------------------------------------------

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Profissional usr)
        {
            if (ModelState.IsValid)
            {
                var appProfissional = new ProfissionalAplicacao();
                appProfissional.Salvar(usr);
                return RedirectToAction("Index");
            }
            return View(usr);
        }

        //-------------------------------------------------------

        public ActionResult Editar(int id)
        {
            var appProfissional = new ProfissionalAplicacao();
            var profissional = appProfissional.ListarPorId(id);

            if (profissional == null)
                return HttpNotFound();

            return View(profissional);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Profissional usr)
        {
            if (ModelState.IsValid)
            {
                var appProfissional = new ProfissionalAplicacao();
                appProfissional.Salvar(usr);
                return RedirectToAction("Index");
            }
            return View(usr);
        }

        //-------------------------------------------------------

        public ActionResult Detalhes(int id)
        {
            var appProfissional = new ProfissionalAplicacao();
            var profissional = appProfissional.ListarPorId(id);

            if (profissional == null)
                return HttpNotFound();

            return View(profissional);
        }

        //-------------------------------------------------------

        public ActionResult Bloquear(int id)
        {
            var appProfissional = new ProfissionalAplicacao();
            var profissional = appProfissional.ListarPorId(id);

            if (profissional == null)
                return HttpNotFound();

            return View(profissional);
        }

        [HttpPost, ActionName("Bloquear")]
        [ValidateAntiForgeryToken]
        public ActionResult BloquearUsuario(int id)
        {
            var appProfissional = new ProfissionalAplicacao();
            appProfissional.Bloquear(id);
            return RedirectToAction("Index");

        }

    }
}
