using IntegrationTests.TestDriver;
using NUnit.Framework;

namespace IntegrationTests
{
    /// <summary>
    /// Be sure to have local instance of the NetCore.WebApiExample website running on the url provided in the _localHostUrl constant.
    /// </summary>
    [TestFixture]    
    public class NetCoreMvcRouteTests
    {
        private const string _localHostUrl = "https://localhost:44314/";
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
        [TestCase("")] //Home/Index route
        [TestCase("abc@")]
        [TestCase("abc@abc")]
        [TestCase("@abc")]
        public void NetCoreMvc_Given_Relative_MVC_Route_Should_Be_Valid_Route(string relativeUrl)
        {
           Assert.IsTrue(_testDriver.UrlReturnsSuccessStatusCode(relativeUrl));                                          
        }

        [Test]        
        [TestCase("abc")]
        [TestCase("123")]
        public void NetCoreMvc_Given_Relative_MVC_Route_Should_Return_404_Not_Found_StatusCode(string relativeUrl)
        {
            Assert.IsTrue(_testDriver.UrlReturns404NotFoundStatusCode(relativeUrl));
        }
    }
}
