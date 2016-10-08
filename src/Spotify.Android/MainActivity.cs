using Android.App;
using Android.Content;
using Android.OS;
using Spotify.Droid.Fragments;

namespace Spotify.Android
{
    [Activity(Label = "Spotify", MainLauncher = true, Icon = "@mipmap/ic_launcher", Theme = "@style/Spotify.Base")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var tx = FragmentManager.BeginTransaction();
            tx.Replace(Resource.Id.mainContainer, new ArtistListFragment(), "ArtistList");
            tx.Commit();
        }
    }
}

