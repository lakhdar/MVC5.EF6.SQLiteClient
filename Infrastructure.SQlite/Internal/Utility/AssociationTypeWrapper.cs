﻿using System.Data.Entity.Core.Metadata.Edm;

namespace Infrastructure.SQlite.Utility
{
    internal class AssociationTypeWrapper
    {
        public AssociationType AssociationType { get; set; }
        public string FromTableName { get; set; }
        public string ToTableName { get; set; }
    }
}
