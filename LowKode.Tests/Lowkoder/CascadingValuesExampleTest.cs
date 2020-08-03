using Lowkode.Demo.Application.Data;
using Lowkode.Demo.Application.Pages;
using LowKode.Core.Configuration;
using LowKode.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Lowkode.Demo.Application.Shared;
using CascadingValuesExample = LowKode.Tests.Fixtures.CascadingValuesExample;

namespace LowKode.Tests
{

    [TestClass]
    public class CascadingValuesExampleTest
    {

        [TestMethod]
        public void Test_CascadingValues()
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
            var cut = ctx.RenderComponent<CascadingValuesExample>();

            // Assert
            Assert.IsTrue(
                cut.Markup.Contains("<label>context-value-one</label>")
                && cut.Markup.Contains("<label>context-value-two</label>"));
        }
    }

}
