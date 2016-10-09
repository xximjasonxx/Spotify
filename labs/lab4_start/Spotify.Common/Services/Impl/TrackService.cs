using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spotify.Common.Models;

namespace Spotify.Common.Services.Impl
{
    public class TrackService : ITrackService
    {
        private List<Track> _cache;

        public List<Track> AvailableTracks
        {
            get
            {
                if (_cache == null)
                    return new List<Track>();

                return _cache;
            }
        }

        public async Task<bool> LoadTracksForAlbum(string albumId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlString = $"https://api.spotify.com/v1/albums/{albumId}/tracks";

                    var response = await client.GetAsync(urlString);
                    var content = await response.Content.ReadAsStringAsync();
                    var root = JObject.Parse(content);


                    _cache = JsonConvert.DeserializeObject<List<Track>>(root["items"].ToString());
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
