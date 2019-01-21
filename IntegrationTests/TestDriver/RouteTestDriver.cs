using System;
using System.Net;
using System.Net.Http;

namespace IntegrationTests.TestDriver
{
    public class RouteTestDriver
    {
        private string _localHostBaseUrl;

        public RouteTestDriver(string localHostBaseUrl)
        {
            if (string.IsNullOrWhiteSpace(localHostBaseUrl))
            {
                throw new ArgumentException(nameof(localHostBaseUrl));
            }

            _localHostBaseUrl = AppendBackSlashIfNeeded(localHostBaseUrl);

        }

        public bool UrlReturnsSuccessStatusCode(string relativeUrlForTest)
        {
            var httpCallResult = TestUrl(relativeUrlForTest);
            return httpCallResult.IsSuccessStatusCode;
        }

        public bool UrlReturns404NotFoundStatusCode(string relativeUrlForTest)
        {
            var httpCallResult = TestUrl(relativeUrlForTest);
            return httpCallResult.StatusCode == HttpStatusCode.NotFound;
        }

        public bool UrlReturns400BadRequestStatusCode(string relativeUrlForTest)
        {
            var httpCallResult = TestUrl(relativeUrlForTest);
            return httpCallResult.StatusCode == HttpStatusCode.BadRequest;
        }

        private string AppendBackSlashIfNeeded(string localHostBaseUrl)
        {
            return !localHostBaseUrl.EndsWith("/")
                ? localHostBaseUrl + "/"
                : localHostBaseUrl;
        }

        private HttpResponseMessage TestUrl(string relativeUrlForTest)
        {
            var httpClient = HttpClientFactory.GetInstance();
            var uriToTest = new Uri(_localHostBaseUrl + (relativeUrlForTest ?? string.Empty));
            var httpCallResult = httpClient.GetAsync(uriToTest).Result;
            return httpCallResult;
        }
    }

    internal static class HttpClientFactory
    {
        private static HttpClient _instance;

        public static HttpClient GetInstance()
        {
            if (_instance == null)
            {
                _instance = new HttpClient();
            }

            return _instance;
        }
    }
}
