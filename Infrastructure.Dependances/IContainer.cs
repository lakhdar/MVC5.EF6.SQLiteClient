namespace Infrastructure.Dependances
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///contrat de Base  pour la gestion des dependances
    /// </summary>
    public interface IContainer : IDisposable
    {
        /// <summary>
        /// Resoudre la dependance  TObject
        /// </summary>
        /// <typeparam name="TObject">Type de dependance</typeparam>
        /// <returns>instance de TObject</returns>
        TObject Resoudre<TObject>();

        /// <summary>
        /// Resoudre la construction d'un  type  et renvoyer l'object  
        /// </summary>
        /// <param name="type"> le Type a Resoudre</param>
        /// <returns>instance de ce type</returns>
        object Resoudre(Type type);

        /// <summary>
        /// Enregister le type idans la gestion de dependance
        /// </summary>
        /// <param name="type"> le Type a Enregister</param>
        void EnregisterType(Type type);

        /// <summary>
        /// Resoudre la construction d'un  type  et renvoyer la liste d'objects retrouves
        /// </summary>
        /// <param name="type"> le Type a Resoudre</param>
        /// <returns>liste d'objects retrouves</returns>
        IEnumerable<object> ResoudreTout(Type type);

        /// <summary>
        /// Creer un container enfant 
        /// </summary>
        /// <returns>le container enfantcomme instance de IContainer</returns>
        IContainer CreerContainerEnfant();

        /// <summary>
        /// Enregister un mappage de type avec un container donné 
        /// </summary>
        /// <typeparam name="TFrom"> le type d'interface </typeparam>
        /// <typeparam name="TTo">le type d'instance </typeparam>
        void EnregisterInstance<TFrom, TTo>() where TTo : TFrom;

    }
}

