using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Infrastructure.SQlite
{
    public interface IDatabaseCreator
    {
        void Create(Database db, DbModel model);
    }
}