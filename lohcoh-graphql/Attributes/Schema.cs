using Lohcoh.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.GraphQL
{
    [MetadataSource]
    public class Schema : Attribute
    {
        public string Root { get; private set; }
        public Schema() {  }
        public Schema(string Root)
        {
            this.Root= Root;
        }
    }
}
