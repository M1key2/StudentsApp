using System.Net.Http.Json;
using System.Net.Http.Headers;
using Microsoft.JSInterop;
using StudentsApp.DTOs;

namespace StudentsApp.Services
{
    public class AuthApiService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        public bool IsAuthenticated => !string.IsNullOrEmpty(_token);
        private const string TokenKey = "authToken";
        private string? _token;

        public AuthApiService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
        }

        public async Task InitializeAsync()
        {
            _token = await _js.InvokeAsync<string>("localStorage.getItem", TokenKey);

            if (!string.IsNullOrEmpty(_token))
            {
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _token);
            }
        }

        public async Task<bool> Login(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResult>();
            _token = result?.Token;

            if (string.IsNullOrEmpty(_token)) return false;

            await _js.InvokeVoidAsync("localStorage.setItem", "authToken", _token);

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            return true;
        }
        public async Task<bool> Register(RegisterRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", request);

            return response.IsSuccessStatusCode;
        }
        public async Task Logout()
        {
            _token = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
            _http.DefaultRequestHeaders.Authorization = null;
        }
    }
}
