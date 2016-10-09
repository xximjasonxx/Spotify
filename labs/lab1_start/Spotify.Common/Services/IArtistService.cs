using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Common.Models;

namespace Spotify.Common.Services
{
    public interface IArtistService
    {
        // properties
        IList<Artist> LoadedArtists { get; }

        // metjods
        Task<bool> SearchArtistsAsync(string query);
    }
}
