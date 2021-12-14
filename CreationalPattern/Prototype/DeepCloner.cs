using Newtonsoft.Json;

namespace CreationalPattern.Prototype;

public static class DeepCloner
{
    public static T? Clone<T>(this T @this)
    {
        return @this == null ? default : JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(@this));
    }
}