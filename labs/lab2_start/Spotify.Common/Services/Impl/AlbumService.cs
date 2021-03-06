﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spotify.Common.Models;

namespace Spotify.Common.Services.Impl
{
    public class AlbumService : IAlbumService
    {
        private List<Album> _cache = new List<Album>();

        public List<Album> CurrentAlbums
        {
            get { return _cache; }
        }

        public async Task<bool> LoadAlbumsForArtistAsync(string artistId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlString = $"https://api.spotify.com/v1/artists/{artistId}/albums";

                    var response = await client.GetAsync(urlString);
                    var content = await response.Content.ReadAsStringAsync();
                    var root = JObject.Parse(content);


                    _cache = JsonConvert.DeserializeObject<List<Album>>(root["items"].ToString());
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
