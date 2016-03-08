using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Infrastructure.Dependances;

namespace Application.ServiceGestion.Tests
{
    [TestClass]
    public class ServiceGestionProduitsTests
    {
        [TestMethod]
        [TestCategory("Application.ServiceGestion.Tests")]
        public void ServiceGestionProduits_Ajouter_Produit_Non_Null_Test()
        {
            Produit produit = new Produit()
            {
                CategorieID = 1,
                Id = 99999,
                Nom = "test",
                FournisseurID = 1

            };
            IServiceGestionProduits srvGestion = DependanceFactory.Instance.ContainerActuel.Resoudre<IServiceGestionProduits>();
            srvGestion.Ajouter(produit);
            Produit produitBD = srvGestion.GetElementById(produit.Id);
            Assert.IsNotNull(produitBD);
            Assert.IsTrue(produit.Id == produitBD.Id);
        }
    }
}
