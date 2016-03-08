namespace Application.ServiceGestion
{
    using Domain;
    using System.Collections.Generic;
    /// <summary>
    /// Contrat pour le service de gestion des Fournisseur
    /// </summary>
    public interface IServiceGestionFournisseurs
    {

        /// <summary>
        /// Ajouter un Fournisseur
        /// </summary>
        /// <param name="fournisseur"> Le Fournisseur à ajouter</param>
        void Ajouter(Fournisseur fournisseur);

        /// <summary>
        /// Recupere une liste paginée de Fournisseurs
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de produit </returns>
        IEnumerable<Fournisseur> ListPaginee(int indexPage, int tailePage);

        /// <summary>
        /// Retrouver un  Fournisseur par son Identifiant
        /// </summary>
        /// <param name="id">Identifiant du Produit a retrouver</param>
        /// <returns>Le fournisseur trouve</returns>
        Fournisseur GetElementById(int id);

        /// <summary>
        /// Recupere une liste paginée des Fournisseur
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de fournisseurs </returns>
        PagedList<Fournisseur> ListPagineeAvecTotal(int indexPage, int tailePage);
         

    }
}
