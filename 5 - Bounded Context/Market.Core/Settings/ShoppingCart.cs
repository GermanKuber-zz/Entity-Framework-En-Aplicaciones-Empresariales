using System;

namespace Market.Core.Settings
{
    public static class ShoppingCartSettings
    {
        public static TimeSpan CookieExpiration { get; private set; }

        public static void ShouldBeProtectedCookieExpirationSetter(TimeSpan expiration)
        {
            CookieExpiration = expiration;
        }
    }
}