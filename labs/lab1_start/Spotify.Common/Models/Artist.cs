using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spotify.Common.Models
{
    public class Artist
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("genres")]
        public IList<string> Genres { get; internal set; }

        [JsonProperty("uri")]
        public string SpotifyUri { get; internal set; }

        [JsonProperty("images")]
        public IList<ArtistImage> Images { get; internal set; }

        [JsonProperty("popularity")]
        public int Popularity { get; internal set; }
    }
}
