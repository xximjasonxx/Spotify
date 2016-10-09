using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Common.Models;

namespace Spotify.Common.Services
{
    public interface ITrackService
    {
        List<Track> AvailableTracks { get; }

        Task<bool> LoadTracksForAlbum(string albumId);
    }
}
