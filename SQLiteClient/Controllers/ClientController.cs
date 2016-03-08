using Application.ServiceGestion;
using Domain;
using SQLiteClient.Extension;
using SQLiteClient.Models;
using System;
using System.Web.Mvc;

namespace SQLiteClient.Controllers
{
    public class ClientController : Controller
    {

        private IServiceGestionClients _serviceGestionClients;


        public ClientController(IServiceGestionClients serviceGestionClients)
        {
            if (serviceGestionClients == (IServiceGestionClients)null)
                throw new ArgumentNullException("serviceGestionClients");
            this._serviceGestionClients = serviceGestionClients;
        }




        // GET: Client
        public ActionResult Index(int? pageindex)
        {
            ViewBag.ActiveMenu = "Client";
            PagedList<ClientElementDeListeVM> viewModel = this._serviceGestionClients.ListPagineeAvecTotal(pageindex ?? 0, 10).ToViewModel();
            return View(viewModel);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ActiveMenu = "Client";
            ClientElementDeListeVM viewModel = this._serviceGestionClients.GetElementById(id).ToViewModel();
            return View(viewModel);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ViewBag.ActiveMenu = "Client";
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ViewBag.ActiveMenu = "Client";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
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

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
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
