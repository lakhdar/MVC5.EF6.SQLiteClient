namespace Domain
{
    using System;

    /// <summary>
    /// Contrat pour ‘UnitOfWork pattern’ 
    /// </summary>
    public interface IUnitOfWork
        : IDisposable
    {
        /// <summary>
        /// Sauvegarder toutes les modifications vers la base 
        /// </summary>
        void Engager();
    }
}
