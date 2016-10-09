using System;
using Android.Views;
using Spotify.Common.IOC;
using Spotify.Common.Services;
using Spotify.Common.Models;

namespace Spotify.Droid.Adapters
{
    public class ArtistsViewAdapter : Android.Support.V7.Widget.RecyclerView.Adapter
    {
        private readonly IArtistService _artistService;

        public ArtistsViewAdapter(Action<Artist> selectAction)
        {
            _artistService = Container.Instance.Resolve<IArtistService>();
        }

        public override int ItemCount
        {
            get { throw new NotImplementedException(); }
        }

        public override void OnBindViewHolder(Android.Support.V7.Widget.RecyclerView.ViewHolder holder, int position)
        {
            throw new NotImplementedException();
        }

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }
    }
}
