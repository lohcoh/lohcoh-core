using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcode.DDD
{

    public class ModelRepository
    {

        private List<IModelPart> _parts = new List<IModelPart>();

        public ModelPart<TImplementation> GetModelPart<TImplementation>(TImplementation implementation)
        {
            var implementationType = implementation.GetType();
            return _parts.Find(p => p.GetType() == implementationType) as ModelPart<TImplementation>;
        }

        public void RegisterModelPart<TImplementation>(ModelPart<TImplementation> part)
        {
            _parts.Add(part);
        }


    }
}
