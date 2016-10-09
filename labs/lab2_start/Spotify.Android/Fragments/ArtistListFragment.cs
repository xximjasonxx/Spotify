using Android.OS;
using Android.Views;
using Spotify.Droid.Fragments.Abstract;

namespace Spotify.Droid.Fragments
{
    public class ArtistListFragment : FragmentBase
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_artist_list, container, false);
        }
    }
}