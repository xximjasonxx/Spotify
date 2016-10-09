using Android.App;
using Android.OS;

namespace Spotify.Droid
{
    [Activity(Label = "Spotify", MainLauncher = true, Icon = "@mipmap/ic_launcher", Theme = "@style/Spotify.Base",
              ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstance)
        {
            base.OnCreate(savedInstance);
            SetContentView(Resource.Layout.Main);
        }
    }
}

