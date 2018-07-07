using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyTrade.Models
{
    public class LeftMenuItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentId")]
        public int? ParentId { get; set; }

        [JsonProperty("indexNumber")]
        public int IndexNumber { get; set; }

        [JsonProperty("children")]
        public List<LeftMenuItem> Children { get; set; }

        [JsonProperty("levelClass")]
        public string LevelClass { get; set; }

        [JsonProperty("iconClass")]
        public string IconClass { get; set; }

        [JsonProperty("iconClass")]
        public string Url { get; set; }
    }
}