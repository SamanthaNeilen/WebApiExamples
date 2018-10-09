using IntegrationTests.TestDriver;
using NUnit.Framework;

namespace IntegrationTests
{
    /// <summary>
    /// Be sure to have local instance of the Framework.WebApiExample website running on the url provided in the _localHostUrl constant.
    /// </summary>
    [TestFixture]    
    public class FrameworkMvcRouteTests
    {
        private const string _localHostUrl = "http://localhost:55528/";
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
        [TestCase("GetEmail/abc@")]
        [TestCase("GetEmail/abc@abc")]
        [TestCase("GetEmail/@abc")]
        [TestCase("GetNumber/0")]
        [TestCase("GetNumber/12")]
        [TestCase("GetNumber/123")]
        public void FrameworkMvc_Given_Relative_MVC_Convention_Based_Route_Should_Be_Valid_Route(string relativeUrl)
        {
           Assert.IsTrue(_testDriver.UrlReturnsSuccessStatusCode(relativeUrl));                                          
        }

        [Test]        
        [TestCase("abc")]
        [TestCase("GetEmail")]
        [TestCase("GetEmail/abc")]
        [TestCase("GetEmail/123")]
        [TestCase("GetNumber")]
        [TestCase("GetNumber/1234")]
        public void FrameworkMvc_Given_Relative_MVC_Convention_Based_Route_Should_Return_404_Not_Found_StatusCode(string relativeUrl)
        {
            Assert.IsTrue(_testDriver.UrlReturns404NotFoundStatusCode(relativeUrl));
        }


        [Test]   
        [TestCase("Attr/abc@")]
        [TestCase("Attr/abc@abc")]
        [TestCase("Attr/@abc")]
        [TestCase("Attr/0")]
        [TestCase("Attr/12345")]
        [TestCase("Attr/2147483647")]
        public void FrameworkMvc_Given_Relative_MVC_Attribute_Based_Route_Should_Be_Valid_Route(string relativeUrl)
        {
            Assert.IsTrue(_testDriver.UrlReturnsSuccessStatusCode(relativeUrl));
        }

        [Test]
        [TestCase("Attr")]
        [TestCase("Attr/abc")]
        [TestCase("Attr/-1")]
        [TestCase("Attr/2147483648")]
        public void FrameworkMvc_Given_Relative_MVC_Attribute_Based_Route_Should_Return_404_Not_Found_StatusCode(string relativeUrl)
        {
            Assert.IsTrue(_testDriver.UrlReturns404NotFoundStatusCode(relativeUrl));
        }
    }
}
