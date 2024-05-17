using Azure;
using Microsoft.AspNetCore.Components;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace BlazorApp.Extensions
{
    public class ApiHttpClient
    {
        private static readonly JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private HttpClient httpClient;
        private readonly NavigationManager navigationManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiHttpClient(NavigationManager navigationManager, IHttpContextAccessor httpContextAccessor)
        {
            this.navigationManager = navigationManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public ApiHttpClient SetHttpClient(HttpClient client)
        {
            httpClient = client;
            AddRefererHeader();
            return this;
        }

        public Cookie? getJWTToket()
        {

            var context = _httpContextAccessor.HttpContext;

            // Отримання токену з кукі
            var token = context.Request.Cookies.FirstOrDefault(p=>p.Key == "Bearer");
            Cookie? cookie = null;
            if (token.Value is not null && token.Key is not null)
            cookie = new Cookie(token.Key,token.Value);



            return cookie;
        }


        public void SetJWTToken(string token)
        {
            var context = _httpContextAccessor.HttpContext;

            if (context == null)
            {
                throw new InvalidOperationException("HttpContext is null");
            }

            var options = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(1) // Set the expiration date as required
            };

            context.Response.Cookies.Append("Bearer", token, options);
            

        }

        private void AddRefererHeader()
        {
            var referer = navigationManager.Uri;
            httpClient.DefaultRequestHeaders.Referrer = new Uri(referer);
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            ValidateAndLogUri(requestUri);

            var response = await httpClient.GetAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            ExtractBearerFromCookies(requestUri, response);
            return responseBody.Deserialize<T>(options);
        }

        public async Task PostAsync<T>(string requestUri, T viewModel)
        {
            ValidateAndLogUri(requestUri);

            var response = await httpClient.PostAsJsonAsync(requestUri, viewModel, options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            ExtractBearerFromCookies(requestUri, response);
        }

        public async Task<TOut> PostAsync<T, TOut>(string requestUri, T viewModel)
        {
            ValidateAndLogUri(requestUri);
            var response = await httpClient.PostAsJsonAsync(requestUri, viewModel, options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            ExtractBearerFromCookies(requestUri, response);
            return responseBody.Deserialize<TOut>(options);
        }

        public async Task PostFormDataAsync(string requestUri, MultipartFormDataContent content)
        {
            ValidateAndLogUri(requestUri);

            var response = await httpClient.PostAsync(requestUri, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            ExtractBearerFromCookies(requestUri, response);
        }

        public async Task PutAsync<T>(string requestUri, T viewModel)
        {
            ValidateAndLogUri(requestUri);

            var response = await httpClient.PutAsJsonAsync(requestUri, viewModel, options);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            ExtractBearerFromCookies(requestUri, response);
        }

        public async Task DeleteAsync(string requestUri)
        {
            ValidateAndLogUri(requestUri);

            var response = await httpClient.DeleteAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            ExtractBearerFromCookies(requestUri, response);
        }

        private void ValidateAndLogUri(string requestUri)
        {
            if (string.IsNullOrWhiteSpace(requestUri) || !Uri.IsWellFormedUriString(requestUri, UriKind.RelativeOrAbsolute))
            {
                throw new UriFormatException($"Invalid URI: The format of the URI '{requestUri}' could not be determined.");
            }
        }

        public IEnumerable<Cookie> ExtractBearerFromCookies(string requestUri, HttpResponseMessage response)
        {
            var baseUri = httpClient.BaseAddress;
            var fullUri = new Uri(baseUri, requestUri);

            CookieContainer cookies = new CookieContainer();
            foreach (var cookieHeader in response.Headers.GetValues("Set-Cookie"))
                cookies.SetCookies(fullUri, cookieHeader);

            List<Cookie> cookies1 = new List<Cookie>();
            foreach (Cookie cookie in cookies.GetCookies(fullUri))
            {
                cookies1.Add(cookie);
                if (cookie.Name == "Bearer")
                    SetJWTToken(cookie.Value);
            }
            return cookies1;
        }


    }
}
