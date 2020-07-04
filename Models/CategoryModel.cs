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
        public EventCategory[] Events { get; set; }
    }

    public partial class EventCategory
    {
        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("referenceLocation")]
        public string ReferenceLocation { get; set; }

        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }

        [JsonProperty("zones")]
        public ZoneCategory[] Zones { get; set; }
    }

    public partial class Duration
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }
    }

    public partial class ZoneCategory
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }
    }

    public partial class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("cost")]
        public long Cost { get; set; }
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
