using Newtonsoft.Json;

namespace Nadir.Newtonsoft
{
    public class AggregateJsonSerializerSettings : JsonSerializerSettings
    {
        public AggregateJsonSerializerSettings()
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
            TypeNameHandling = TypeNameHandling.Auto;
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full;
        }
    }
}
