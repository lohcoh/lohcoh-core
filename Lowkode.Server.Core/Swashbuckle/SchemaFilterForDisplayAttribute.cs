using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Lowkode.Server.Core.Swashbuckle
{
	public class AddRequiredToNonNullables : ISchemaFilter
	{
		private readonly IModelMetadataProvider modelMetadataProvider;

		public AddRequiredToNonNullables(IModelMetadataProvider modelMetadataProvider)
		{
			this.modelMetadataProvider = modelMetadataProvider;
		}

		public void Apply(OpenApiSchema schema, SchemaFilterContext context)
		{
			foreach (var property in context.Type.GetProperties())
			{
				object[] attributes = property.GetCustomAttributes(true);
				foreach (object attribute in attributes)
				{
					DisplayAttribute displayAttribute = attribute as DisplayAttribute;
					if (displayAttribute != null)
					{
						if (string.IsNullOrWhiteSpace(displayAttribute.Name))
						{
							OpenApiSchema schemaProp;
							if (schema.Properties.TryGetValue(property.Name, out schemaProp))
							{
								schemaProp.
							}
						}
					}
				}

			}
		}

	}
}
