namespace Application.ServiceGestion
{
    using Domain;
    using System.Collections.Generic;
    /// <summary>
    /// Contrat pour le service de gestion des produits
    /// </summary>
    public interface IServiceGestionCategories
    {

        /// <summary>
        /// Ajouter un Categorie
        /// </summary>
        /// <param name="categorie"> Le Categorie à ajouter</param>
        void Ajouter(Categorie categorie);

        /// <summary>
        /// Recupere une liste paginée de Categories
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de produit </returns>
        IEnumerable<Categorie> ListPaginee(int indexPage, int tailePage);

        /// <summary>
        /// Retrouver une Categorie par son Identifiant
        /// </summary>
        /// <param name="id">Identifiant du Produit a retrouver</param>
        /// <returns>Le produit trouve</returns>
        Categorie GetElementById(int id);

        /// <summary>
        /// Recupere une liste paginée des Categories
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de produit </returns>
        PagedList<Categorie> ListPagineeAvecTotal(int indexPage, int tailePage);
         

    }
}
