using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain 
{
    /// <summary>
    /// Contrat de base pour IProduitRepository
    /// <see cref="Domain.IRepository{Produit}""/>
    /// </summary>
    public interface IProduitRepository : IRepository<Produit>
    {
    }
}
