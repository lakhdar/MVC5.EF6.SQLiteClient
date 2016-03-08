using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Infrastructure.Dependances;
using System.IO;

namespace Infrastructure.Donnee.Tests
{
    [TestClass]
    public class ProduitTests
    {
        [TestMethod]
        public void ProduitRepository_GetElementById_Avec_Id_Valid_Test()
        {
           
            Produit produit = DependanceFactory.Instance.ContainerActuel.Resoudre<ProduitRepository>().GetElementById(1);
            Assert.IsNotNull(produit);
            Assert.IsTrue(produit.Id == 1);
        }


        [TestMethod]
        [TestCategory("Infrastructure.Donnee.Tests")]
        public void ProduitRepository_Ajouter_Produit_Non_Null_Test()
        {
            Produit produit = new Produit()
            {
                CategorieID = 1,
                Id = 9999 ,
                Nom="test",
                FournisseurID=1

            };
            IProduitRepository repo= DependanceFactory.Instance.ContainerActuel.Resoudre<IProduitRepository>();
            repo.Ajouter(produit);
            repo.UnitOfWork.Engager();
            Produit produitBD= repo.GetElementById(produit.Id);
            Assert.IsNotNull(produitBD);
            Assert.IsTrue(produit.Id == produitBD.Id);
        }
    }
}
