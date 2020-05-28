using LowKode.Core.LOS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LowKode.Tests
{
    interface Application
    {
        string Title { get; set; }
    }
    interface Hello
    {
        string One { get; set; }
        string Two { get; set; }
        string Three { get; set; }
    }

    interface GoodBye
    {
        string One { get; set; }
        string Two { get; set; }
        string Three { get; set; }
    }

    /// <summary>
    /// These tests were originally used to develop LOS.
    /// </summary>
    [TestClass]
    public class LosTests
    {
        [TestMethod]
        public void TestAddMethod()
        {

            var LOS = new LosObjectSystem();
            var root = LOS.Master; // get the root object
            // Create a new object with the <Application> interface type, assign it to the "Application" property, and the return it
            var app = root.Add<Application>(app => app.Title = "TPS Report Manager 3000");

            var title = root.Get<Application>().Title;  // get the application title
            Assert.AreEqual("TPS Report Manager 3000", title);
        }

        [TestMethod]
        public void TestBranching()
        {
            var LOS = new LosObjectSystem();
            var root = LOS.Master; // get the root object

            root.Add<Hello>(hello => 
            {
                hello.One = "Howdy";
                hello.Two = "Hi";
                hello.Three = "Hello";
            });
            root.Add<GoodBye>(bye => 
            {
                bye.One = "Bye";
                bye.Two = "Goodby";
                bye.Three = "Later";
            });

            // creates a branch of the root and changes some properties
            var branch = root.Branch(branch => 
            {
                branch.One = "Yo";
                branch.Two = null;
            });

            // all these assertions are true
            Assert.AreEqual("Yo", branch.One);

            Assert.IsNull(branch.Two);

            // note that the Hello3 property was never set in the branch, therefore 
            // the current value in the root cascades to the child
            Assert.AreEqual("Hello", branch.Three);

            // Note that changing properties in the branch did not change the root.
            Assert.AreEqual("Howdy", branch.One);

            Assert.AreEqual("Hi", branch.Two);

            Assert.AreEqual("Hello", branch.Three);
        }
    }
}
