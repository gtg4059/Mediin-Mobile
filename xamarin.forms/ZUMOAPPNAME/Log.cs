using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
//using System.Linq;

namespace MediinApp
{
	public class Log
	{
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("names")]
        public string names { get; set; }

        [Newtonsoft.Json.JsonProperty("passwords")]
        public string passwords { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public string date { get; set; }

        [Newtonsoft.Json.JsonProperty("age")]
        public string age { get; set; }

        [Newtonsoft.Json.JsonProperty("sex")]
        public string sex { get; set; }

        [Newtonsoft.Json.JsonProperty("weight")]
        public string weight { get; set; }

        [Newtonsoft.Json.JsonProperty("height")]
        public string height { get; set; }

        [Newtonsoft.Json.JsonProperty("arm")]
        public int arm { get; set; }

        [Newtonsoft.Json.JsonProperty("sit")]
        public int sit { get; set; }

        [Newtonsoft.Json.JsonProperty("yoga")]
        public int yoga { get; set; }

        [Newtonsoft.Json.JsonProperty("praise")]
        public int praise { get; set; }

        [Newtonsoft.Json.JsonProperty("foot")]
        public string foot { get; set; }


        [Version]
        public string Version { get; set; }
    }
}

