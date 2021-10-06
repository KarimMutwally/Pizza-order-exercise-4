
using System.Text.Json;

namespace PizzaUI.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            string jsonData = JsonSerializer.Serialize(value);
            session.SetString(key, jsonData);
        }

        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value != null)
                return JsonSerializer.Deserialize<T>(value);
            else return default;
        }
    }
}
