using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Event_Soft_FrontEnd.Models
{
    public partial class CategoryModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("events")]
        public EventModel[] Events { get; set; }
    }
    public partial class ListCategoryModel
    {
        public static CategoryModel[] FromJson(string json) => JsonConvert.DeserializeObject<CategoryModel[]>(json, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

    public partial class CategoryModel
    {
        public static CategoryModel FromJson(string json) => JsonConvert.DeserializeObject<CategoryModel>(json, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

    public static class SerializeCategory
    {
        public static string ToJson(this CategoryModel self) => JsonConvert.SerializeObject(self, Event_Soft_FrontEnd.Models.Converter.Settings);
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
