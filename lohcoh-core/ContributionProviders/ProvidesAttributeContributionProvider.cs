using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.Core.ContributionProviders
{
    public class ProvidesAttributeHandler 
    {
        /// <summary>
        /// Registers the services export from a module 
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public void RegisterServiceProviders(IServiceCollection services, Type moduleType)
        {
            var dependencies = new List<Type>();
            var providesAttributes = moduleType.GetCustomAttributes(typeof(ProvidesAttribute), true) as ProvidesAttribute[];
            foreach (var providesAttribute in providesAttributes)
            {
                services.AddSingleton(providesAttribute.InterfaceType, providesAttribute.ImplementationType);
            }
        }
    }
}
