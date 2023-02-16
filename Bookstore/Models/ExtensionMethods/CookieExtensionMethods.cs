using System.Text.Json;

namespace Bookstore.Models
{
    // extension methods that make working with request and response cookies 
    // similar to working with session

    public static class CookieExtensions
    {
        public static string GetString(this IRequestCookieCollection cookies, string key) => 
            cookies[key] ?? string.Empty;

        public static int? GetInt32(this IRequestCookieCollection cookies, string key)
        {
            var value = cookies.GetString(key);
            return int.TryParse(value, out int i) ? i : (int?)null;
        }

        public static T? GetObject<T>(this IRequestCookieCollection cookies, string key)
        {
            var value = cookies.GetString(key);
            return (string.IsNullOrEmpty(value)) ? default(T) : JsonSerializer.Deserialize<T>(value);
        }


        public static void SetString(this IResponseCookies cookies, string key, 
            string value, int days = 30)
        {
            cookies.Delete(key); // delete old value first
            if (days == 0) {
                cookies.Append(key, value);
            }
            else {
                CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(days) };
                cookies.Append(key, value, options);
            }
            
        }
        public static void SetInt32(this IResponseCookies cookies, string key, 
            int value, int days = 30) =>
            cookies.SetString(key, value.ToString(), days);

        public static void SetObject<T>(this IResponseCookies cookies, string key, 
            T value, int days = 30) =>
            cookies.SetString(key, JsonSerializer.Serialize(value), days);

    }
}
