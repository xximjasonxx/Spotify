using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Common.Models;

namespace Spotify.Common.Services
{
    public interface IAlbumService
    {
        List<Album> CurrentAlbums { get; }

        Task<bool> LoadAlbumsForArtistAsync(string id);
    }
}
