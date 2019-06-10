using System.Collections.Generic;

namespace MicroService.ApiGateway.Authentication
{
    public class AuthenticationConsts
    {
        public const string CookieName = "MicroService.ApiGateway";
        public const string OidcClientId = "MicroService.ApiGateway";
        public const string OidcAuthenticationScheme = "oidc";
        public const string OidcResponseType = "id_token";

        public const string ScopeOpenId = "openid";
        public const string ScopeProfile = "profile";
        public const string ScopeEmail = "email";
        public const string ScopeRoles = "roles";
        public const string ScopeCustomProfile = "custom.profile";
        public const string ScopeRefreshToken = "offline_access";

        public const string AccountLoginPage = "Account/Login";

        public const string AdministrationPolicy = "OcelotAdministrationPolicy";
        public const string AdministrationRole = "OcelotAdmin";
    }
}
