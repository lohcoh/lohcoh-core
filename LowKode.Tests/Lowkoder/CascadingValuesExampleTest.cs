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

        /// <summary>
        /// Verifies that CascadingValues in Blazor are not the same as a global context variable.
        /// The <CascadingValue/> tag creates a context in which the value is stored.
        /// </summary>
        [TestMethod]
        public void Test_CascadingValues()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<CascadingValuesExample>();

            Assert.IsTrue(
                cut.Markup.Contains("<label>context-value-one</label>")
                && cut.Markup.Contains("<label>context-value-two</label>"));
        }
    }

}
