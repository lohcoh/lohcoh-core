using Lohcoh.Core;
using Lohcoh.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.GraphQL
{
    public class LcGraphQLModule : LcModule
    {
        ILcRegistry registry;
        public LcGraphQLModule(ILcRegistry registry)
        {
            this.registry= registry;
        }


        override protected void OnStart()
        {
            var schemaContributions= registry.Contributions<SchemaContribution>();
        }
    }
}
