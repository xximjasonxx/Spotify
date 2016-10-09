using System;
using System.Linq;
using Android.Views;
using Android.Widget;
using Spotify.Common.IOC;
using Spotify.Common.Extensions;
using Spotify.Common.Services;
using Spotify.Common.Models;

namespace Spotify.Droid.Adapters
{
    public class ArtistsViewAdapter : Android.Support.V7.Widget.RecyclerView.Adapter
    {
        private readonly IArtistService _artistService;
        private readonly Action<Artist> _selectAction;

        public ArtistsViewAdapter(Action<Artist> selectAction)
        {
            _artistService = Container.Instance.Resolve<IArtistService>();
            _selectAction = selectAction;
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
            vh.TheArtist = artist;

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
            return new ArtistItemViewHolder(view, _selectAction);
        }

        // view holder class
        class ArtistItemViewHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder, View.IOnClickListener
        {
            private readonly Action<Artist> _clickAction;
            public Artist TheArtist { get; set; }

            public TextView ArtistName { get; private set; }
            public TextView ArtistGenres { get; private set; }

            public ArtistItemViewHolder(View itemView, Action<Artist> clickAction) : base(itemView)
            {
                ArtistName = itemView.FindViewById<TextView>(Resource.Id.artistName);
                ArtistGenres = itemView.FindViewById<TextView>(Resource.Id.artistGenres);
                itemView.SetOnClickListener(this);

                _clickAction = clickAction;
            }

            public void OnClick(View v)
            {
                _clickAction.Invoke(TheArtist);
            }
        }
    }
}
