namespace ShoppingCartRazor.Helpers;

using System.Text.Json;

public static class SessionExtensions
{
    // Extensions method to set an object in the session
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    // Extension method to get an object from the session
    public static T? Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }
}