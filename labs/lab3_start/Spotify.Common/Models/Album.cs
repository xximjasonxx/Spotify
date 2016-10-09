using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spotify.Common.Models
{
    public class Album
    {
        [JsonProperty("id")]
        public string AlbumId { get; internal set; }

        [JsonProperty("images")]
        public List<AlbumImage> Images
        { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}
