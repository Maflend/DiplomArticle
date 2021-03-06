using AuthenticationBlazor.Client.Services.AuthService;
using AuthenticationBlazor.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace AuthenticationBlazor.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
       
        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }
        public async Task<string> GetTokenAsync()
            => await _localStorage.GetItemAsync<string>("token");

        public async Task SetTokenAsync(string token)
        {
            if (token != null)
            {
                await _localStorage.SetItemAsync<string>("token", token);
            }
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());
            var token = await GetTokenAsync();
            
            if (!string.IsNullOrEmpty(token))
            {
                var claims = ParseClaimsFromJwt(token);

                var identity = new ClaimsIdentity(claims, "AuthenticationJWT");
                state = new AuthenticationState(new ClaimsPrincipal(identity));
               
            }
            NotifyAuthenticationStateChanged(Task.FromResult(state));


            return state;
        }
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
