using System.Collections.Generic;

namespace Infrastructure.SQlite.Statement
{
    public interface IStatementCollection : IStatement, ICollection<IStatement>
    {
    }
}
