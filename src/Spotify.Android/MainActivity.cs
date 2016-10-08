using System;
using Android.App;
using Android.Content;
using Android.OS;
using Spotify.Droid.Behaviors;
using Spotify.Droid.Fragments;

namespace Spotify.Droid
{
    [Activity(Label = "Spotify", MainLauncher = true, Icon = "@mipmap/ic_launcher", Theme = "@style/Spotify.Base",
              ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity, IGoToFragment
    {
        protected override void OnCreate(Bundle savedInstance)
        {
            base.OnCreate(savedInstance);
            SetContentView(Resource.Layout.Main);

            var tx = FragmentManager.BeginTransaction();
            tx.Replace(Resource.Id.mainContainer, new ArtistListFragment(), "ArtistList");
            tx.Commit();
        }

        public void GoToFragment(Fragment fragment, string tag)
        {
            var tx = FragmentManager.BeginTransaction();
            tx.Replace(Resource.Id.mainContainer, fragment, tag);
            tx.AddToBackStack(tag);

            tx.Commit();
        }
    }
}

