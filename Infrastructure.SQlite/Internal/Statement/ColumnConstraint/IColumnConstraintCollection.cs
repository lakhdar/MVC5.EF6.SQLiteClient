using System.Collections.Generic;

namespace Infrastructure.SQlite.Statement.ColumnConstraint
{
    interface IColumnConstraintCollection : ICollection<IColumnConstraint>, IColumnConstraint
    {
    }
}
