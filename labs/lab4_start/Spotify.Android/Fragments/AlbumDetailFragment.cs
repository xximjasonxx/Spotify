using System;
using System.Linq;
using System.Threading.Tasks;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Spotify.Common.IOC;
using Spotify.Common.Models;
using Spotify.Common.Services;
using Spotify.Droid.Adapters;
using Spotify.Droid.Fragments.Abstract;

namespace Spotify.Droid.Fragments
{
    public class AlbumDetailFragment : FragmentBase
    {
        private readonly ITrackService _trackService;
        private Android.Support.V7.Widget.RecyclerView.Adapter _adapter;

        public Album TheAlbum { get; private set; }

        public AlbumDetailFragment(Album album)
        {
            TheAlbum = album;
            _trackService = Container.Instance.Resolve<ITrackService>();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(false);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_album_detail, container, false);
        }

        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            if (TheAlbum.Images.Any())
            {
                var albumImage = View.FindViewById<ImageView>(Resource.Id.albumImage);
                Glide.With(this)
                     .Load(TheAlbum.Images[0].Url)
                     .CenterCrop()
                     .CrossFade()
                     .Into(albumImage);
            }
            else
            {
                View.FindViewById<ImageView>(Resource.Id.albumImage).Visibility = ViewStates.Gone;
            }

            View.FindViewById<TextView>(Resource.Id.albumName).Text = TheAlbum.Name;

            var recyclerView = View.FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.trackList);
            recyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(Activity));

            _adapter = new TracksViewAdapter();
            recyclerView.SetAdapter(_adapter);

            await LoadTracks();
        }

        async Task LoadTracks()
        {
            ShowProgressDialog();
            try
            {
                var result = await _trackService.LoadTracksForAlbum(TheAlbum.AlbumId);
                if (result)
                {
                    _adapter.NotifyDataSetChanged();
                }

                HideProgressDialog();
            }
            catch
            {
                HideProgressDialog();
            }
        }
    }
}
