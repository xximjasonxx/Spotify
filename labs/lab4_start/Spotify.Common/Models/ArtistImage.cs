using System;
using Newtonsoft.Json;

namespace Spotify.Common.Models
{
    public class ArtistImage
    {
        [JsonProperty("url")]
        public string ImageUrl { get; internal set; }
    }
}
