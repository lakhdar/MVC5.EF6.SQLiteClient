namespace Domain
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contrat de base pour toutes les entités 
    /// </summary>
    public abstract class EntiteBase
    {
        /// <summary>
        /// identifiant 
        /// </summary>
        [Key]
        public  int Id { get; set; }
    }
}
