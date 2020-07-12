using Lowkode.Demo.Application.Data;
using Lowkode.Demo.Application.Pages;
using LowKode.Core.Configuration;
using LowKode.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Lowkode.Demo.Application.Shared;


namespace LowKode.Tests
{

    [TestClass]
    public class BasicLowkoderTests
    {

        [TestMethod]
        public void Test_LowkoderFirstExample()
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
            var cut = ctx.RenderComponent<LowkoderFirstExample>();

            // Assert
            cut.Markup.Contains("<h1>Hello world from Blazor</h1>");
        }
    }

}
