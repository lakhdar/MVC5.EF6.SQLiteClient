namespace Application.ServiceGestion
{
    using Domain;
    using System.Collections.Generic;
    /// <summary>
    /// Contrat pour le service de gestion des Commande
    /// </summary>
    public interface IServiceGestionCommandes
    {

        /// <summary>
        /// Ajouter un Commande
        /// </summary>
        /// <param name="commande"> Le Commande à ajouter</param>
        void Ajouter(Commande commande);

        /// <summary>
        /// Recupere une liste paginée de Commande
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de produit </returns>
        IEnumerable<Commande> ListPaginee(int indexPage, int tailePage);

        /// <summary>
        /// Retrouver une Commande par son Identifiant
        /// </summary>
        /// <param name="id">Identifiant du Commande a retrouver</param>
        /// <returns>Le Commande trouve</returns>
        Commande GetElementById(int id);

        /// <summary>
        /// Recupere une liste paginée des Commandes
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de Commandes </returns>
        PagedList<Commande> ListPagineeAvecTotal(int indexPage, int tailePage);
         

    }
}
