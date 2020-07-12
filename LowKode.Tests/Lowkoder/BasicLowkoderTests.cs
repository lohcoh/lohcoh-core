using Lowkode.Demo.Application.Data;
using Lowkode.Demo.Application.Pages;
using LowKode.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Lowkode.Demo.Application.Shared;


namespace LowKode.Tests
{

    [TestClass]
    public class BasicLowkoderTests
    {

        /// <summary>
        /// This test was written early on in Lowkoder's development.
        /// It's a basic test of the Lowkoder Starship example.
        /// Initially Lowkoder was so slow that it wasn't clear that Lowkoder was a feasible idea, 
        /// rendering the Starship form example tooks several seconds.
        /// This test just makes sure that the Starship example takes less than .5 seconds to render, 
        /// not good but not irredeemably bad.
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
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var cut = ctx.RenderComponent<LowKodeForm>();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 500);
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
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var cut = ctx.RenderComponent<StarshipForm>();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 500);
            //cut.MarkupMatches("<h1>Hello world from Blazor</h1>");
        }
    }

}
