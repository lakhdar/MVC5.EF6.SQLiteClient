using System.Data.Entity.Core.Metadata.Edm;

namespace Infrastructure.SQlite
{
    public interface ISqlGenerator
    {
        string Generate(EdmModel storeModel);
    }
}