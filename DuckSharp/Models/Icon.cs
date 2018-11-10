﻿using Newtonsoft.Json;

namespace DuckSharp.Models
{
    public class Icon
    {
        [JsonProperty("URL")]
        public string Url { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }
    }
}