using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;

namespace roulette
{
    [TestFixture]
    public class HelloWorldStubExampleTest
    {

        [Test]
        public void Iterator_will_return_XKCD()
        {

            var stubEnumerator = new Mock<IEnumerator<String>>();
            IEnumerator<String> enumerator = stubEnumerator.Object;
            stubEnumerator.Setup(d=>d.Current).Returns("XKCD");
            Assert.AreEqual("XKCD", enumerator.Current);
            
        }
        [Test]
        public void With_arguments()
        {
            var stub = new Mock<IComparable<String>>();
            IComparable<String> c = stub.Object;
            stub.Setup(d => d.CompareTo("Test")).Returns(1);
            Assert.AreEqual(1, c.CompareTo("Test"));
        }

        [Test]
        public void With_unspecified_arguments()
        {
            var stub= new Mock<IComparable<int>>();
            IComparable<int> c = stub.Object;
            stub.Setup(d => d.CompareTo(It.IsAny<Int32>())).Returns(-1);
            Assert.AreEqual(-1, c.CompareTo(5));
        }

    }
}
