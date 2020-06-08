using LowKode.Core.LOS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LowKode.Tests
{
    public class Application 
    {
        public virtual string Title { get; set; }
        public virtual Navigation Navigation { get; set; }
    }

    public class Navigation
    {
        public virtual string HomeUrl { get; set; }
        public virtual IList<NavigationItem> Items { get; set; }
    }
    
    public class NavigationItem
    {
        public virtual string Label { get; set; }
        public virtual string Uri { get; set; }
    }
    public class Hello 
    {
        public virtual string One { get; set; }
        public virtual string Two { get; set; }
        public virtual string Three { get; set; }
    }

    public class GoodBye 
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
            var application = new Application()
            {
                Title = "TPS Report Manager 3000"
            };

            var los = new LosObjectSystem();
            var prime= los.Open();  
            prime.Put(application);
            var master= prime.Save();

            Assert.AreEqual("TPS Report Manager 3000", master.Get<Application>().Title);

            // now change the title
            var application2= master.Get<Application>();
            application2.Title = "TPS Report Manager 3000 + 1";
            var branch= master.Save();

            // the branch title should be updated and the master title should not have changed
            Assert.AreEqual("TPS Report Manager 3000", master.Get<Application>().Title);
            Assert.AreEqual("TPS Report Manager 3000 + 1", branch.Get<Application>().Title);
        }

        [TestMethod]
        public void TestNesting()
        {         
            var los = new LosObjectSystem();
            var prime= los.Open();

            // populate the object system with some data
            prime.Put(new Application()
            { 
                Title = "TPS Report Manager 3000",
                Navigation= new Navigation()
                {
                    HomeUrl= "http://localhost:8080/Lowkoder",
                    Items= new List<NavigationItem>() { 
                        new NavigationItem()
                        {
                            Label= "Home",
                            Uri= "/"
                        }
                    }
                }
            });

            var master = prime.Save(); // save the data to create the master branch
            Assert.AreEqual(0, master.Revision); /// the master branch always has revision 0

            // we should get the title that we created
            Assert.AreEqual("TPS Report Manager 3000", master.Get<Application>().Title);

            // now change the title
            master.Get<Application>().Title = "TPS Report Manager 3000 + 1";
            var branch = master.Save();
            Assert.AreEqual(1, branch.Revision);

            // the branch title should be updated and the master title should not have changed
            Assert.AreEqual("TPS Report Manager 3000", master.Get<Application>().Title);
            Assert.AreEqual("TPS Report Manager 3000 + 1", branch.Get<Application>().Title);
        }


        [TestMethod]
        public void TestBranching()
        {
            var los = new LosObjectSystem();
            var prime = los.Open(); 

            prime.Put(new Hello() 
            {
                One = "Howdy",
                Two = "Hi",
                Three = "Hello"
            });

            prime.Put(new GoodBye()
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
