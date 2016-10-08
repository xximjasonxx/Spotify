using Android.OS;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Spotify.Common.IOC;
using Spotify.Common.Services;
using Spotify.Droid.Adapters;
using Spotify.Droid.Fragments.Abstract;

namespace Spotify.Droid.Fragments
{
    public class ArtistListFragment : FragmentBase, SearchView.IOnQueryTextListener
    {
        private readonly IArtistService _artistService;

        private Android.Support.V7.Widget.RecyclerView _artistsList;
        private Android.Support.V7.Widget.RecyclerView.Adapter _adapter;

        public ArtistListFragment()
        {
            _artistService = Container.Instance.Resolve<IArtistService>();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_artist_list, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            _artistsList = View.FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.artistList);
            _artistsList.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(Activity));

            _adapter = new ArtistsViewAdapter();
            _artistsList.SetAdapter(_adapter);
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.main_menu, menu);
            var searchItem = menu.FindItem(Resource.Id.search_action);
            SearchView searchView = (SearchView)MenuItemCompat.GetActionView(searchItem);
            searchView.SetOnQueryTextListener(this);

            base.OnCreateOptionsMenu(menu, inflater);
        }

        public async void PerformSearch(string query)
        {
            ShowProgressDialog();
            try
            {
                var result = await _artistService.SearchArtistsAsync(query);
                if (result)
                {
                    // Load Results
                    _adapter.NotifyDataSetChanged();
                    Activity.CurrentFocus.ClearFocus();
                    DismissSoftKeyboard();
                }

                HideProgressDialog();
            }
            catch
            {
                HideProgressDialog();
            }
        }

        public bool OnQueryTextChange(string newText)
        {
            return true;
        }

        public bool OnQueryTextSubmit(string query)
        {
            if (query.Length > 1)
            {
                PerformSearch(query);
            }
            return true;
        }
    }
}