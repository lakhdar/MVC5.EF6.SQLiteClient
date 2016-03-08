using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    /// Description du produit 
    /// </summary>
    public class Categorie: EntiteBase
    {
        /// <summary>
        /// Nom de la Categorie 
        /// </summary>
        [MaxLength(100)]
        public string Nom  { get; set; }
        /// <summary>
        /// la Description de la Categorie 
        /// </summary>
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
