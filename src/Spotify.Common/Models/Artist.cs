using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Common.Models
{
    public class Artist
    {
        public async Task<IList<Artist>> GetArtists()
        {
            using (var client = new HttpClient())
            {
                return null;
            }
        }
    }
}
