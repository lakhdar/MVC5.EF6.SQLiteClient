namespace Application.ServiceGestion
{
    using Domain;
    using System.Collections.Generic;
    /// <summary>
    /// Contrat pour le service de gestion des produits
    /// </summary>
    public interface IServiceGestionProduits
    {

        /// <summary>
        /// Ajouter un produit
        /// </summary>
        /// <param name="produit"> Le produit à ajouter</param>
        void Ajouter(Produit produit);

        /// <summary>
        /// Recupere une liste paginée de produits
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de produit </returns>
        IEnumerable<Produit> ListPaginee(int indexPage, int tailePage);

        /// <summary>
        /// Retrouver un Produit par son Identifiant
        /// </summary>
        /// <param name="id">Identifiant du Produit a retrouver</param>
        /// <returns>Le produit trouve</returns>
        Produit GetElementById(int id);

        /// <summary>
        /// Recupere une liste paginée de produits
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de produit </returns>
        PagedList<Produit> ListPagineeAvecTotal(int indexPage, int tailePage);
         

    }
}
