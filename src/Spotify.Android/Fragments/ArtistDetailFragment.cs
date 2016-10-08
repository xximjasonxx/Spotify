
using System;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Spotify.Common.Extensions;
using Spotify.Droid.Extensions;
using Spotify.Common.Models;
using Spotify.Droid.Fragments.Abstract;
using System.Threading.Tasks;
using Spotify.Common.Services;
using Spotify.Common.IOC;
using Android.Support.V7.Widget;
using Spotify.Droid.Adapters;

namespace Spotify.Droid.Fragments
{
    public class ArtistDetailFragment : FragmentBase
    {
        private readonly IAlbumService _albumService;
        private RecyclerView.Adapter _adapter;

        public Artist Artist { get; private set; }

        public ArtistDetailFragment(Artist artist)
        {
            Artist = artist;
            _albumService = Container.Instance.Resolve<IAlbumService>();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(false);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_artist_detail, container, false);
        }

        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            /*if (!Artist.Images.Any())
            {
                View.FindViewById<ImageView>(Resource.Id.artistImage).Visibility = ViewStates.Gone;
            }
            else
            {
                View.FindViewById<ImageView>(Resource.Id.artistImage).SetImageURI(new Uri(Artist.Images[0].ImageUrl));
            }*/

            View.FindViewById<TextView>(Resource.Id.artistName).Text = Artist.Name;
            View.FindViewById<TextView>(Resource.Id.artistGenres).Text = Artist.Genres.Join(", ");
            View.FindViewById<TextView>(Resource.Id.artistPopularity).Text = $"Popularity: {Artist.Popularity}";

            var recyclerView = View.FindViewById<RecyclerView>(Resource.Id.albumList);
            recyclerView.SetLayoutManager(new GridLayoutManager(Activity, 2));

            _adapter = new AlbumsViewAdapter(AlbumSelected);
            recyclerView.SetAdapter(_adapter);

            await LoadAlbums();
        }

        async Task LoadAlbums()
        {
            ShowProgressDialog();
            try
            {
                HideProgressDialog();
                var result = await _albumService.LoadAlbumsForArtistAsync(Artist.Id);
                if (result)
                {
                    _adapter.NotifyDataSetChanged();
                }
            }
            catch
            {
                HideProgressDialog();
            }
        }

        void AlbumSelected(Album album)
        {
        }
    }
}
