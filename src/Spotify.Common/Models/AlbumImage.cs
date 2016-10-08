using System;
using Newtonsoft.Json;

namespace Spotify.Common.Models
{
    public class AlbumImage
    {
        [JsonProperty("url")]
        public string Url { get; internal set; }
    }
}
