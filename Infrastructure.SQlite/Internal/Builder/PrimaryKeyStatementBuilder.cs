using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using Infrastructure.SQlite.Statement;

namespace Infrastructure.SQlite.Builder
{
    internal class PrimaryKeyStatementBuilder : IStatementBuilder<PrimaryKeyStatement>
    {
        private readonly IEnumerable<EdmMember> keyMembers;

        public PrimaryKeyStatementBuilder(IEnumerable<EdmMember> keyMembers)
        {
            this.keyMembers = keyMembers;
        }

        public PrimaryKeyStatement BuildStatement()
        {
            return new PrimaryKeyStatement(keyMembers.Select(km => km.Name));
        }
    }
}
