using System;
using System.Linq;
using Android.Views;
using Android.Widget;
using Spotify.Common.IOC;
using Spotify.Common.Extensions;
using Spotify.Common.Services;

namespace Spotify.Droid.Adapters
{
    public class ArtistsViewAdapter : Android.Support.V7.Widget.RecyclerView.Adapter
    {
        private readonly IArtistService _artistService;

        public ArtistsViewAdapter()
        {
            _artistService = Container.Instance.Resolve<IArtistService>();
        }

        public override int ItemCount
        {
            get
            {
                var count = _artistService.LoadedArtists.Count;
                return count;
            }
        }

        public override void OnBindViewHolder(Android.Support.V7.Widget.RecyclerView.ViewHolder holder, int position)
        {
            var vh = (ArtistItemViewHolder)holder;
            var artist = _artistService.LoadedArtists.ElementAt(position);

            vh.ArtistName.Text = artist.Name;

            if (artist.Genres.Any())
            {
                vh.ArtistGenres.Text = artist.Genres.Join(", ");
            }
            else
            {
                vh.ArtistGenres.Visibility = ViewStates.Gone;
            }
        }

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.listitem_artist, parent, false);
            return new ArtistItemViewHolder(view);
        }

        // view holder class
        class ArtistItemViewHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder
        {
            public TextView ArtistName { get; private set; }
            public TextView ArtistGenres { get; private set; }

            public ArtistItemViewHolder(View itemView) : base(itemView)
            {
                ArtistName = itemView.FindViewById<TextView>(Resource.Id.artistName);
                ArtistGenres = itemView.FindViewById<TextView>(Resource.Id.artistGenres);
            }
        }
    }
}
