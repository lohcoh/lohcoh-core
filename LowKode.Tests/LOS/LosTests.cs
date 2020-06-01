using LowKode.Core.LOS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LowKode.Tests
{
    class Application 
    {
        public string Title { get; set; }
    }
    class Hello 
    {
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
    }

    class GoodBye 
    {
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
    }

    /// <summary>
    /// These tests were originally used to develop LOS.
    /// </summary>
    [TestClass]
    public class LosTests
    {
        [TestMethod]
        public void TestPriming()
        {

            var LOS = new LosObjectSystem();
            var prime = LOS.Prime; // get the prime branch

            var app = new Application() {
                Title= "TPS Report Manager 3000"
            };
            prime.Add(app);
            var master= prime.Save();

            var title = master.Get<Application>().Title;  // get the application title
            Assert.AreEqual("TPS Report Manager 3000", title);
        }

        [TestMethod]
        public void TestBranching()
        {
            var LOS = new LosObjectSystem();
            var prime = LOS.Prime; 

            prime.Add(new Hello()
            {
                One = "Howdy",
                Two = "Hi",
                Three = "Hello",
            });

            prime.Add(new GoodBye()
            {
                One = "Bye",
                Two = "Goodby",
                Three = "Later"
            });

            var master= prime.Save();

            // creates a branch of the root and changes some properties
            var hello = master.Get<Hello>();
            hello.One = "Yo";
            hello.Two = null;

            var branch= master.Save();

            var bHello= branch.Get<Hello>();

            // all these assertions are true
            Assert.AreEqual("Yo", bHello.One);
            Assert.IsNull(bHello.Two);
            // note that Three was never set in the branch, therefore 
            // the current value in the master cascades to the branch
            Assert.AreEqual("Hello", bHello.Three);

            // Note that changing properties in the branch did not change the master
            var mHello = master.Get<Hello>();
            Assert.AreEqual("Howdy", mHello.One);
            Assert.AreEqual("Hi", mHello.Two);
            Assert.AreEqual("Hello", mHello.Three);
        }
    }
}
