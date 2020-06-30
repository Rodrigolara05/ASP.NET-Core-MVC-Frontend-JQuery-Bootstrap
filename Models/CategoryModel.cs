﻿using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Event_Soft_FrontEnd.Models
{
    public partial class Category
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

    public partial class Category
    {
        public static Category FromJson(string json) => JsonConvert.DeserializeObject<Category>(json, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

    public static class SerializeCategory
    {
        public static string ToJson(this Category self) => JsonConvert.SerializeObject(self, Event_Soft_FrontEnd.Models.Converter.Settings);
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
