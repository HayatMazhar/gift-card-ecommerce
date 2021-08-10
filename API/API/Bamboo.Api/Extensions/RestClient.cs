using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Api.Extensions
{
    public class RestClient<TResource, TIdentifier> : IDisposable where TResource : class
    {
        private HttpClient httpClient;
        protected readonly string _baseAddress;
        private readonly string _addressSuffix;
        private bool disposed = false;

        public RestClient(string baseAddress, string addressSuffix)
        {
            _baseAddress = baseAddress;
            _addressSuffix = addressSuffix;
            httpClient = CreateHttpClient(_baseAddress);
        }
        protected virtual HttpClient CreateHttpClient(string serviceBaseAddress)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serviceBaseAddress);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "VEVTVDpjZDI1NDRiNS0yZTc1LTRlYzMtYWNiYS04NTUzZGRiZjQwY2M=");
            return httpClient;
        }
        public async Task<TResource> GetAsync(TIdentifier identifier)
        {
            var responseMessage = await httpClient.GetAsync(_addressSuffix + identifier.ToString());
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsAsync<TResource>();
        }
        public async Task<IEnumerable<TResource>> GetAll()
        {
            var responseMessage = await httpClient.GetAsync(_addressSuffix);
            responseMessage.EnsureSuccessStatusCode();
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            var myDeserializedClass = JsonConvert.DeserializeObject<IEnumerable<TResource>>(responseString);
            return myDeserializedClass;
        }
        public async Task<HTTPResponse> Post(TResource model)
        {
            HTTPResponse result = new HTTPResponse();
            using (var request = new HttpRequestMessage(HttpMethod.Post, _addressSuffix))
            {
                var json = JsonConvert.SerializeObject(model);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        result.StatusCode = response.StatusCode;
                        result.Message = response.Content.ReadAsStringAsync().Result.ToString();

                    }
                }
            }
            return result;

        }





        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                }
                disposed = true;
            }
        }
    }

    public class HTTPResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
