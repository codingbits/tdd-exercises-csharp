using System;
using MbUnit.Framework;

namespace roulette
{
    [TestFixture]
    public class HelloWorldTest
    {

        // this would normally be in a separate (domain) class
        private String Concatenate(String s1, String s2)
        {
            return s1 + " " + s2;
        }
        [SetUp]
        public void This_Gets_Executed_Before_Each_Test()
        {
            // initialise common variables
        }
        [Test]
        public void Concatenation_appends_second_string()
        {
            // arrange
            // act
            String result = Concatenate("Hello", "World");
            // assert
            Assert.AreEqual("Hello World", result);
        }
        private void Burp()
        {
            throw new ArgumentException("Exception");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Burp_throws_an_exception()
        {
            // arrange
            // act
            Burp();
            // assert
        }
    }
}