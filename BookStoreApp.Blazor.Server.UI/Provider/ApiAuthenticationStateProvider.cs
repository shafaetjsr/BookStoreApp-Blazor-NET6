using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookStoreApp.Blazor.Server.UI.Provider
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var saveToken = await _localStorage.GetItemAsync<string>("accessToken");
            if(saveToken == null)
            {
                return new AuthenticationState(user);
            }

            var tokencontent = _jwtSecurityTokenHandler.ReadJwtToken(saveToken);
            if(tokencontent.ValidTo<DateTime.Now)
            {
                return new AuthenticationState(user);
            }

            var claims = await getClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims,"jwt"));
            return new AuthenticationState(user);
        }

        public async Task LoggedIn()
        {

            var claims =await getClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authStatus = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authStatus);
        }

        public async Task loggedOut()
        {
            _localStorage.RemoveItemAsync("accessToken");
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authStatus = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authStatus);
        }

        private async Task<List<Claim>> getClaims()
        {
            var saveToken = await _localStorage.GetItemAsync<string>("accessToken");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(saveToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }

    }
}
