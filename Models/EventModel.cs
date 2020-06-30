using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Event_Soft_FrontEnd.Models
{
    public partial class EventModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("referenceLocation")]
        public string ReferenceLocation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("zones")]
        public Zone[] Zones { get; set; }
    }

    public partial class Zone
    {
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }
    }

    public partial class EventModel
    {
        public static EventModel FromJson(string json) => JsonConvert.DeserializeObject<EventModel>(json, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

    public partial class ListEventModel
    {
        public static EventModel[] FromJson(string json) => JsonConvert.DeserializeObject<EventModel[]>(json, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

    public static class SerializeEvent
    {
        public static string ToJson(this EventModel self) => JsonConvert.SerializeObject(self, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

}
