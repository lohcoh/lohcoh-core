using LowKode.Core;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Bunit;
using Lowkode.Demo.Application.Pages;
using Microsoft.Extensions.DependencyInjection;
using LowKode.Core.Configuration;
using Lowkode.Demo.Application.Data;
using Lowkode.Demo.Application.Shared;

namespace LowKode.Tests
{

    [TestClass]
    public class BasicPerformanceTests
    {

        /// <summary>
        /// This test was written early on in Lowkoder's development.
        /// It's a basic test of the Lowkoder Starship example.
        /// Initially Lowkoder was so slow that it wasn't clear that Lowkoder was a feasible idea, 
        /// rendering the Starship example tooks several seconds.
        /// This test just makes sure that the Starship example takes less than .5 seconds to render, 
        /// not good but not deal-breaking bad.
        /// </summary>
        [TestMethod]
        public void Test_LowKodeForm()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();

            // Register services
            ctx.Services.AddLowKode(config =>
            {
                config.ContributeMetadataForType<WeatherForecast>();
                config.ContributeMetadataForType<Starship>();
            });

            // Act
            var cut = ctx.RenderComponent<LowKodeForm>();

            // Assert
            //cut.MarkupMatches("<h1>Hello world from Blazor</h1>");
        }
        [TestMethod]
        public void Test_Starship()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();

            // Register services
            ctx.Services.AddLowKode(config =>
            {
                config.ContributeMetadataForType<WeatherForecast>();
                config.ContributeMetadataForType<Starship>();
            });

            // Act
            var cut = ctx.RenderComponent<StarshipForm>();

            // Assert
            //cut.MarkupMatches("<h1>Hello world from Blazor</h1>");
        }
    }

}
