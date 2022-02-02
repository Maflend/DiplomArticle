using AuthenticationBlazor.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AuthenticationBlazor.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public string ErrorMessage { get; set; } = string.Empty;
        public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }
        public async Task<bool> Login(UserLogin request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            var desegializingResponse = await response.Content.ReadFromJsonAsync<ServerResponse<string>>();
            if(!desegializingResponse.Success)
            {
                ErrorMessage = desegializingResponse.Message;
                return false;
            }
            SetToken(desegializingResponse.Data);
            return true;
            
        }

        public async Task<bool> Register(UserRegister request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", request);
            var desegializingResponse = await response.Content.ReadFromJsonAsync<ServerResponse<User>>();
            if (!desegializingResponse.Success)
            {
                ErrorMessage = desegializingResponse.Message;
                return false;
            }
            return true;
            
        }

        public async void SetToken(string token)
        {
            await _localStorage.RemoveItemAsync("token");
            await _localStorage.SetItemAsync("token", token);
            
        }

        public async Task<string> GetToken()
        {
            var token = await _localStorage.GetItemAsync<string>("token");
            return token;
        }
    }
}
