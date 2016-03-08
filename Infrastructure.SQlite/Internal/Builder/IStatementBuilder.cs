using Infrastructure.SQlite.Statement;

namespace Infrastructure.SQlite.Builder
{
    internal interface IStatementBuilder<out TStatement>
        where TStatement : IStatement
    {
        TStatement BuildStatement();
    }
}
