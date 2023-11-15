using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Provider;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookStoreApp.Blazor.Server.UI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient HttpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = HttpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> AuthenticateAsync(LoginUserDto loginModel)
        {
            var responce = await _httpClient.LoginAsync(loginModel);

            await _localStorage.SetItemAsync("accessToken", responce.Token);

            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

            return true;
        }

        public async Task logout()
        {
            await((ApiAuthenticationStateProvider)_authenticationStateProvider).loggedOut();
        }
    }
}
