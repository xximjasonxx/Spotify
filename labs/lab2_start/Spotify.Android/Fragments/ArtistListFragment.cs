using System;
using Android.OS;
using Android.Views;
using Spotify.Droid.Fragments.Abstract;
using Android.Widget;
using Spotify.Droid.Behaviors;

namespace Spotify.Droid.Fragments
{
    public class ArtistListFragment : FragmentBase
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_artist_list, container, false);
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
            (Activity as IGoToFragment)?.GoToFragment(new ArtistDetailFragment(), "ArtistDetail");
        }
    }
}