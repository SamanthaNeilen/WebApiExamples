using IntegrationTests.TestDriver;
using NUnit.Framework;

namespace IntegrationTests
{
    /// <summary>
    /// Be sure to have local instance of the Framework.WebApiExample website running on the url provided in the _localHostUrl constant.
    /// </summary>
    [TestFixture]    
    public class FrameworkWepApiRouteTests
    {
        private const string _localHostUrl = "http://localhost:55528/api/routingapi";
        private RouteTestDriver _testDriver;

        [SetUp]
        public void Setup()
        {
            _testDriver = new RouteTestDriver(_localHostUrl);
        }

        [TearDown]
        public void TearDown()
        {
            _testDriver = null;
        }

        [Test]
       
        [TestCase("abc@")]
        [TestCase("abc@abc")]
        [TestCase("@abc")]
        [TestCase("abc_abc")]
        [TestCase("0")]
        [TestCase("12345")]
        [TestCase("2147483647")]
        public void FrameworkWebApi_Given_Relative_Route_Should_Be_Valid_Route(string relativeUrl)
        {
           Assert.IsTrue(_testDriver.UrlReturnsSuccessStatusCode(relativeUrl));                                          
        }

        [Test]
        [TestCase("")]
        [TestCase("abc")]
        [TestCase("-1")]
        [TestCase("2147483648")]
        public void FrameworkWebApi_Given_Relative_Route_Should_Return_404_Not_Found_StatusCode(string relativeUrl)
        {
            Assert.IsTrue(_testDriver.UrlReturns404NotFoundStatusCode(relativeUrl));
        }
    }
}
