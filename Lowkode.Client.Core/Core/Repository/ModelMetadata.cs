using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Lowkode.Client.Core
{
    public class ModelMetadata : IModelMetadata
    {
        public ModelMetadata(Type type)
        {           
            var properties = new List<IModelMetadata>();
            foreach (var property in type.GetProperties())
            {
                properties.Add(new ModelMetadata(property));
            }
            Properties= new ReadOnlyCollection<IModelMetadata>(properties);
            ModelType = type;
            OtherInitialization();
        }

        protected ModelMetadata(PropertyInfo property)
        {
            PropertyInfo = property;
            OtherInitialization();
        }

        protected void OtherInitialization()
        {
            if (Properties == null)
                Properties = new ReadOnlyCollection<IModelMetadata>(new List<IModelMetadata>());
        }

        public IModelTemplateProvider TemplateProvider => throw new System.NotImplementedException();

        public ReadOnlyCollection<IModelMetadata> Properties { get; private set; }

        public Type ModelType { get; private set; }

        public PropertyInfo PropertyInfo { get; private set; }

    }
}