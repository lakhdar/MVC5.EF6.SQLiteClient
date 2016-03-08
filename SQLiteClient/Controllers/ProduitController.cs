using Application.ServiceGestion;
using SQLiteClient.Models;
using SQLiteClient.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace SQLiteClient.Controllers
{
    public class ProduitController : Controller
    {
        private IServiceGestionProduits _serviceGestionProduits;
        private IServiceGestionCategories _serviceGestionCategories;
        private IServiceGestionFournisseurs _serviceGestionFournisseurs;


        public ProduitController(IServiceGestionProduits serviceGestionProduits, IServiceGestionFournisseurs serviceGestionFournisseurs, IServiceGestionCategories serviceGestionCategories)
        {
            if (serviceGestionProduits == (IServiceGestionProduits)null)
                throw new ArgumentNullException("serviceGestionProduits");

            if (serviceGestionFournisseurs == (IServiceGestionFournisseurs)null)
                throw new ArgumentNullException("serviceGestionFournisseurs");

            if (serviceGestionCategories == (IServiceGestionCategories)null)
                throw new ArgumentNullException("serviceGestionCategories");

            this._serviceGestionProduits = serviceGestionProduits;
            this._serviceGestionCategories = serviceGestionCategories;
            this._serviceGestionFournisseurs = serviceGestionFournisseurs;

        }


        // GET: Produit
        public ActionResult Index(int? pageIndex)
        {
            ViewBag.ActiveMenu = "Produit";
            PagedList<ProduitElementDeListeVM> viewModel = this._serviceGestionProduits.ListPagineeAvecTotal(pageIndex??0, 10).ToViewModel();
            return View(viewModel);
        }

        // GET: Produit/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ActiveMenu = "Produit";
            ProduitElementDeListeVM viewModel = this._serviceGestionProduits.GetElementById(id).ToViewModel();
            return View(viewModel);
        }

        // GET: Produit/Create
        public ActionResult Create()
        {
            ProduitCreationVM viewModel = new ProduitCreationVM();
            ViewBag.ActiveMenu = "Produit";
            ViewBag.Categories = this._serviceGestionCategories.ListPaginee(0, 100).ToSelectListItem();
            ViewBag.Fournisseurs = this._serviceGestionFournisseurs.ListPaginee(0, 100).ToSelectListItem();
            return View(viewModel);
        }

        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(ProduitCreationVM model)
        {
            try
            {

                // TODO: Add insert logic here
                ViewBag.ActiveMenu = "Produit";
                this._serviceGestionProduits.Ajouter(model.ToDataModel());


                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produit/Edit/5
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

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produit/Delete/5
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
