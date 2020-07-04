using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Event_Soft_FrontEnd.Models
{
   

    public partial class SubscriptionModel
    {
        [JsonProperty("category")]
        public string Category { get; set; }
    }

    public partial class SubscriptionModel
    {
        public static SubscriptionModel FromJson(string json) => JsonConvert.DeserializeObject<SubscriptionModel>(json, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

    public static class SerializeSubscription
    {
        public static string ToJson(this SubscriptionModel self) => JsonConvert.SerializeObject(self, Event_Soft_FrontEnd.Models.Converter.Settings);
    }
}
