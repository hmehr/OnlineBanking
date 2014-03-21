using System;
using System.Web;

namespace INSE6260.OnlineBanking.Infrastructure.CookieStorage
{
    public class CookieStorageService : ICookieStorageService
    {
        public void Save(string key, string value, DateTime expires)
        {
            var httpCookie = HttpContext.Current.Response.Cookies[key];
            if (httpCookie == null) return;
            httpCookie.Value = value;
            httpCookie.Expires = expires;
        }

        public string Retrieve(string key)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            return cookie != null ? cookie.Value : "";
        }
    }

}
