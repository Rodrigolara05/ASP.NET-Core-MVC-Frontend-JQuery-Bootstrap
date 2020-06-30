using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Event_Soft_FrontEnd.Models
{
    public partial class UserModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("roles")]
        public string[] Roles { get; set; }
    }

    public partial class UserModel
    {
        public static UserModel FromJson(string json) => JsonConvert.DeserializeObject<UserModel>(json, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

    public static class SerializeUser
    {
        public static string ToJson(this UserModel self) => JsonConvert.SerializeObject(self, Event_Soft_FrontEnd.Models.Converter.Settings);
    }

}
