using Application.ServiceGestion;
using Domain;
using SQLiteClient.Extension;
using SQLiteClient.Models;
using System;
using System.Web.Mvc;

namespace SQLiteClient.Controllers
{
    public class CommandeController : Controller
    {
        private IServiceGestionCommandes _serviceGestionCommandes;

        public CommandeController(IServiceGestionCommandes serviceGestionCommandes)
        {
            if (serviceGestionCommandes == (IServiceGestionCommandes)null)
                throw new ArgumentNullException("serviceGestionCommandes");
            this._serviceGestionCommandes = serviceGestionCommandes;
        }


        // GET: Fournisseur
        public ActionResult Index(int? pageindex)
        {
            ViewBag.ActiveMenu = "Commande";
            PagedList<CommandeElementDeListeVM> viewModel = this._serviceGestionCommandes.ListPagineeAvecTotal(pageindex ?? 0, 10).ToViewModel();
            return View(viewModel);
        }

        // GET: Commande/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ActiveMenu = "Commande";
            CommandeDetailsVM viewModel = this._serviceGestionCommandes.GetElementById(id).ToDetailViewModel();
            return View(viewModel);
        }

        // GET: Commande/Create
        public ActionResult Create()
        {
            ViewBag.ActiveMenu = "Commande";
            CommandeCreationVM viewModel = new CommandeCreationVM();
            return View(viewModel);
        }

        // POST: Commande/Create
        [HttpPost]
        public ActionResult Create(CommandeCreationVM model)
        {
            ViewBag.ActiveMenu = "Commande";
            try
            {
                 this._serviceGestionCommandes.Ajouter(model.ToDataModel());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commande/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Commande/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commande/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Commande/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
