using System;
using Android.App;

namespace Spotify.Droid.Behaviors
{
    public interface IGoToFragment
    {
        void GoToFragment(Fragment fragment, string tag);
    }
}
