﻿using System;
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
using Microsoft.OpenApi.Any;

namespace Lowkode.Server.Core.Swashbuckle
{
    /// <summary>
    /// A Swashbuckle extension that adds metadata from System.ComponentModel.DataAnnotations.DisplayAttribute(s) 
    /// to the OpenApi Schemas generated by Swashbuckle.
    /// The Display metadata is added to the Schema properties as an extension named 'x-lowkode-display'
    /// </summary>
    public class AddPropertyDisplayAttributes : ISchemaFilter
    {
        private readonly IModelMetadataProvider modelMetadataProvider;

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null || schema.Properties.Count <= 0)
                return;

            foreach (var property in context.Type.GetProperties())
            {
                var attributes = property.GetCustomAttributes<DisplayAttribute>(true);
                foreach (var displayAttribute in attributes)
                {
                    if (string.IsNullOrWhiteSpace(displayAttribute.Name))
                    {
                        OpenApiSchema schemaProp;
                        if (schema.Properties.TryGetValue(property.Name, out schemaProp))
                        {
                            if (string.IsNullOrWhiteSpace(schemaProp.Title))
                            {
                                schemaProp.Title = displayAttribute.Name;
                            }

                            var displayExtension= new OpenApiObject();

                            if (!string.IsNullOrWhiteSpace(displayAttribute.Name))
                                displayExtension["name"]= new OpenApiString(displayAttribute.Name);
                            if (!string.IsNullOrWhiteSpace(displayAttribute.GroupName))
                                displayExtension["groupName"] = new OpenApiString(displayAttribute.GroupName);
                            if (!string.IsNullOrWhiteSpace(displayAttribute.Description))
                                displayExtension["description"] = new OpenApiString(displayAttribute.Description);
                            if (!string.IsNullOrWhiteSpace(displayAttribute.ShortName))
                                displayExtension["shortName"] = new OpenApiString(displayAttribute.ShortName);
                            if (!string.IsNullOrWhiteSpace(displayAttribute.Prompt))
                                displayExtension["prompt"] = new OpenApiString(displayAttribute.Prompt);
                            if (displayAttribute.GetOrder().HasValue)
                                displayExtension["order"] = new OpenApiInteger(displayAttribute.Order);
                            if (displayAttribute.GetAutoGenerateField().HasValue)
                                displayExtension["autoGenerateField"] = new OpenApiBoolean(displayAttribute.AutoGenerateField);
                            if (displayAttribute.GetAutoGenerateFilter().HasValue)
                                displayExtension["autoGenerateFilter"] = new OpenApiBoolean(displayAttribute.AutoGenerateFilter);

                            schemaProp.Extensions.Add("x-lowkode-display", displayExtension);
                        }
                    }
                }
            }

        }

    }
}