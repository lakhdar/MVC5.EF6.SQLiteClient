namespace Application.ServiceGestion
{
    using Domain;
    using System.Collections.Generic;
    /// <summary>
    /// Contrat pour le service de gestion des Client
    /// </summary>
    public interface IServiceGestionClients
    {

        /// <summary>
        /// Ajouter un Client
        /// </summary>
        /// <param name="client"> Le Commande à ajouter</param>
        void Ajouter(Client client);

        /// <summary>
        /// Recupere une liste paginée de Client
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste de Client </returns>
        IEnumerable<Client> ListPaginee(int indexPage, int tailePage);

        /// <summary>
        /// Retrouver une Client par son Identifiant
        /// </summary>
        /// <param name="id">Identifiant du Client a retrouver</param>
        /// <returns>Le Client trouve</returns>
        Client GetElementById(int id);

        /// <summary>
        /// Recupere une liste paginée des Client
        /// </summary>
        /// <param name="indexPage">index de la page </param>
        /// <param name="tailePage">taille de la page </param>
        /// <returns>Liste des Clients </returns>
        PagedList<Client> ListPagineeAvecTotal(int indexPage, int tailePage);
         

    }
}
