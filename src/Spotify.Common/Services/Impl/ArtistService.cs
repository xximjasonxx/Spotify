using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Common.Services.Impl
{
    internal class ArtistService
    {
        public async Task<IList<Models.Artist>> SearchArtistsAsync(string keyword)
        {
            using (var client = new HttpClient())
            {
                var searchString = System.Uri.EscapeDataString(keyword);
                var urlString = $"https://api.spotify.com/v1/search?q={searchString}&type=artist";

                var response = await client.GetAsync(urlString);
                var content = await response.Content.ReadAsStringAsync();

                return null;
            }
        }
    }
}
