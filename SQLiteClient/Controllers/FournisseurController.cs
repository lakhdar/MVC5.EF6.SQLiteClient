using Application.ServiceGestion;
using Domain;
using SQLiteClient.Extension;
using SQLiteClient.Models;
using System;
using System.Web.Mvc;

namespace SQLiteClient.Controllers
{
    public class FournisseurController : Controller
    {

        private IServiceGestionFournisseurs _serviceGestionFournisseurs;


        public FournisseurController(IServiceGestionFournisseurs serviceGestionFournisseurs)
        {
            if (serviceGestionFournisseurs == (IServiceGestionFournisseurs)null)
                throw new ArgumentNullException("serviceGestionFournisseurs");
            this._serviceGestionFournisseurs = serviceGestionFournisseurs;
        }


        // GET: Fournisseur
        public ActionResult Index(int? pageindex)
        {
            ViewBag.ActiveMenu = "Fournisseur";
            PagedList<FournisseurElementDeListeVM> viewModel = this._serviceGestionFournisseurs.ListPagineeAvecTotal(pageindex ?? 0, 10).ToViewModel();
            return View(viewModel);
        }

        // GET: Fournisseur/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ActiveMenu = "Fournisseur";
            FournisseurDetailsVM viewModel = this._serviceGestionFournisseurs.GetElementById(id).ToDetailViewModel();
            return View(viewModel);
        }

        // GET: Fournisseur/Create
        public ActionResult Create()
        {
            ViewBag.ActiveMenu = "Fournisseur";
            FournisseurCreationVM viewModel = new FournisseurCreationVM();
            return View(viewModel);
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(FournisseurCreationVM model)
        {
            try
            {
                ViewBag.ActiveMenu = "Fournisseur";
                this._serviceGestionFournisseurs.Ajouter(model.ToDataModel());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fournisseur/Edit/5
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

        // GET: Fournisseur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fournisseur/Delete/5
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
