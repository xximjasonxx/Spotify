using Android.OS;
using Android.Views;
using Android.Widget;
using Spotify.Droid.Behaviors;
using Spotify.Droid.Fragments.Abstract;
using System;

namespace Spotify.Droid.Fragments
{
    public class ArtistDetailFragment : FragmentBase
    {
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

        public override void OnResume()
        {
            base.OnResume();
            View.FindViewById<Button>(Resource.Id.nextButton).Click += HandleClick;
        }

        public override void OnPause()
        {
            base.OnPause();
            View.FindViewById<Button>(Resource.Id.nextButton).Click -= HandleClick;
        }

        private void HandleClick(object sender, EventArgs e)
        {
            (Activity as IGoToFragment)?.GoToFragment(new AlbumDetailFragment(), "AlbumDetail");
        }
    }
}
