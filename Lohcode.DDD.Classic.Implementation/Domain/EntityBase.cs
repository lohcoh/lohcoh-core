using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcode.DDD
{
    public class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get ; set; }
    }
}
