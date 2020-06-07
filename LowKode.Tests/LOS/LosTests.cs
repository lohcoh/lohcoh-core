using LowKode.Core.LOS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LowKode.Tests
{
    public interface Application 
    {
        public string Title { get; set; }
        public Navigation Navigation { get; set; }
    }

    public interface Navigation
    {
        public string HomeUrl { get; set; }
        public IList<NavigationItem> Items { get; }
    }
    
    public interface NavigationItem
    {
        public string Label { get; set; }
        public string Uri { get; set; }
    }
    public interface Hello 
    {
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
    }

    public interface GoodBye 
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
            
            // The prime branch should always have revision == -1
            Assert.AreEqual(-1, LOS.Prime.Revision);

            // populate the object system with some data
            LOS.Prime.Put<Application>(a => a.Title = "TPS Report Manager 3000");

            var master= LOS.Prime.Save(); // save the data to create the master branch
            Assert.AreEqual(0, master.Revision); /// the master branch always has revision 0

            // we should get the title that we created
            Assert.AreEqual("TPS Report Manager 3000", master.Get<Application>().Title);

            // now change the title
            master.Get<Application>(a => a.Title = "TPS Report Manager 3000 + 1");
            var branch= master.Save();
            Assert.AreEqual(1, branch.Revision); 

            // the branch title should be updated and the master title should not have changed
            Assert.AreEqual("TPS Report Manager 3000", master.Get<Application>().Title);
            Assert.AreEqual("TPS Report Manager 3000 + 1", branch.Get<Application>().Title);
        }

        [TestMethod]
        public void TestNesting()
        {         
            var LOS = new LosObjectSystem();

            // populate the object system with some data
            LOS.Prime.Create<Application>(a => {
                a.Title = "TPS Report Manager 3000";
                a.Navigation= 
            });

            var master = LOS.Prime.Save(); // save the data to create the master branch
            Assert.AreEqual(0, master.Revision); /// the master branch always has revision 0

            // we should get the title that we created
            Assert.AreEqual("TPS Report Manager 3000", master.Get<Application>().Title);

            // now change the title
            master.Get<Application>(a => a.Title = "TPS Report Manager 3000 + 1");
            var branch = master.Save();
            Assert.AreEqual(1, branch.Revision);

            // the branch title should be updated and the master title should not have changed
            Assert.AreEqual("TPS Report Manager 3000", master.Get<Application>().Title);
            Assert.AreEqual("TPS Report Manager 3000 + 1", branch.Get<Application>().Title);
        }


        [TestMethod]
        public void TestBranching()
        {
            var LOS = new LosObjectSystem();
            var prime = LOS.Prime; 

            prime.Put<Hello>(h => 
            {
                h.One = "Howdy";
                h.Two = "Hi";
                h.Three = "Hello";
            });

            prime.Put<GoodBye>(g =>
            {
                g.One = "Bye";
                g.Two = "Goodby";
                g.Three = "Later";
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
