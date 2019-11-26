using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcoh.Core
{
    public class MyPerson
    {
        private Func<object, object> p;

        public MyPerson(Action<object> p)
        {
            this.p = p;
        }
    }

    static class Example
    {
        static public void example()
        {
            var xxxx= "";

            var person= new MyPerson(person => {
                xxxx= "";
            });

            person.As<SomeInterface>().xxxx= "";

        }
    }

    public class LohcohCoreModule
    {
        /// <summary>
        /// //////////////////
        /// </summary>

        public class ContributionPointAttribute : Attribute
        {
            public ContributionPointAttribute() { }
        }

        public class ContributionAttribute : Attribute
        {
            public ContributionAttribute() { }
        }

        public class ContributionPoint<TContributionType>
        {
        }

        public interface ISayHello
        {
            string MyName { get; }
        }

        public class MyContributionPoint : ContributionPoint<ISayHello>
        {
        }

        [Contribution]
        public class MyContribution : ISayHello

        {

            public string MyName => "I am that I am";

        }



        public class SayHelloEveryone
        {
            public SayHelloEveryone(IEnumerable<ISayHello> contributions)

            {
            }
        }
    }
}
