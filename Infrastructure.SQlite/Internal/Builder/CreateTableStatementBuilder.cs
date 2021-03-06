﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using Infrastructure.SQlite.Builder.NameCreators;
using Infrastructure.SQlite.Statement;
using Infrastructure.SQlite.Utility;

namespace Infrastructure.SQlite.Builder
{
    internal class CreateTableStatementBuilder : IStatementBuilder<CreateTableStatement>
    {
        private readonly EntitySet entitySet;
        private readonly IEnumerable<AssociationTypeWrapper> associationTypes;

        public CreateTableStatementBuilder(EntitySet entitySet, IEnumerable<AssociationTypeWrapper> associationTypes)
        {
            this.entitySet = entitySet;
            this.associationTypes = associationTypes;
        }

        public CreateTableStatement BuildStatement()
        {
            var simpleColumnCollection = new ColumnStatementCollectionBuilder(entitySet.ElementType.Properties).BuildStatement();
            var primaryKeyStatement = new PrimaryKeyStatementBuilder(entitySet.ElementType.KeyMembers).BuildStatement();
            var foreignKeyCollection = new ForeignKeyStatementBuilder(associationTypes).BuildStatement();

            var columnStatements = new List<IStatement>();
            columnStatements.AddRange(simpleColumnCollection);
            columnStatements.Add(primaryKeyStatement);
            columnStatements.AddRange(foreignKeyCollection);

            return new CreateTableStatement
            {
                TableName = TableNameCreator.CreateTableName(entitySet.Table),
                ColumnStatementCollection = new ColumnStatementCollection(columnStatements)
            };
        }
    }
}
