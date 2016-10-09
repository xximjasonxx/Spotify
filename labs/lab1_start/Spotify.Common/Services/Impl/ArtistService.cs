using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spotify.Common.Models;

namespace Spotify.Common.Services.Impl
{
    public class ArtistService : IArtistService
    {
        private IList<Artist> _cachedArtists;

        public IList<Artist> LoadedArtists
        {
            get
            {
                if (_cachedArtists == null)
                    return new List<Artist>();

                return _cachedArtists;
            }
        }

        public async Task<bool> SearchArtistsAsync(string keyword)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var searchString = System.Uri.EscapeDataString(keyword);
                    var urlString = $"https://api.spotify.com/v1/search?q={searchString}&type=artist";

                    var response = await client.GetAsync(urlString);
                    var content = await response.Content.ReadAsStringAsync();
                    var root = JObject.Parse(content);

                    _cachedArtists = JsonConvert.DeserializeObject<List<Artist>>(root["artists"]["items"].ToString());
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
