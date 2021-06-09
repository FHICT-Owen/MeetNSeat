using System;
using MeetNSeat.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;
using RestSharp;

namespace MeetNSeat.Client
{
    public class CustomUserClaimsPrincipal : AccountClaimsPrincipalFactory<CustomRemoteUserAccount>
    {
        private IAccessTokenProviderAccessor Accessor { get; }
        private HttpClient Client { get; }

        public CustomUserClaimsPrincipal(IAccessTokenProviderAccessor accessor, HttpClient client) : base(accessor)
        {
            Accessor = accessor;
            Client = client;
        }

        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(CustomRemoteUserAccount account,
            RemoteAuthenticationUserOptions options)
        {
            var user = await base.CreateUserAsync(account, options);
            if (user.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = (ClaimsIdentity) user.Identity;
                var userId = claimsIdentity.Claims.Single(res => res.Type == "sub").Value.Split("|")[1];
                var role = await AuthService.GetUserRole(userId);
                if (role == 0)
                {
                    var nickname = user.Identity?.Name;
                    await AuthService.AddUser(new UserModel(userId, nickname, 1));
                    role = 1;
                }
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
            }
            return user;
        }
    }
}
