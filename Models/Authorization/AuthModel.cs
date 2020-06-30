using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Event_Soft_FrontEnd.Models.Authorization
{
    public partial class AuthModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }

    public partial class AuthModel
    {
        public static AuthModel FromJson(string json) => JsonConvert.DeserializeObject<AuthModel>(json, Event_Soft_FrontEnd.Models.Authorization.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AuthModel self) => JsonConvert.SerializeObject(self, Event_Soft_FrontEnd.Models.Authorization.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
