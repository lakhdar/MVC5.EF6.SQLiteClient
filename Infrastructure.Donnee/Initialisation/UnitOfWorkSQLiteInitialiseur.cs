using Domain;
using Newtonsoft.Json;
using SQLite.CodeFirst;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Donnee
{
    public class UnitOfWorkSQLiteInitialiseur : SqliteDropCreateDatabaseWhenModelChanges<UnitOfWorkSQLite>
    {
        public UnitOfWorkSQLiteInitialiseur(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        { }
        

        protected override void Seed(UnitOfWorkSQLite unitOfWork)
        {
            BaseEnMemoire baseENMemoire = new BaseEnMemoire();

            foreach (Client client in baseENMemoire.Clients)
            {
                unitOfWork.Clients.Add(client);
            }
            
            foreach (Fournisseur fournisseur  in baseENMemoire.Fournisseurs)
            {
                unitOfWork.Fournisseurs.Add(fournisseur);
            }

            unitOfWork.Engager();
        }
    }
}
