using System;
using Android.Views;
using Spotify.Common.IOC;
using Spotify.Common.Services;

namespace Spotify.Droid.Adapters
{
    public class TracksViewAdapter : Android.Support.V7.Widget.RecyclerView.Adapter
    {
        private readonly ITrackService _trackService;

        public TracksViewAdapter()
        {
            _trackService = Container.Instance.Resolve<ITrackService>();
        }

        public override int ItemCount
        {
            get { return _trackService.AvailableTracks.Count; }
        }

        public override void OnBindViewHolder(Android.Support.V7.Widget.RecyclerView.ViewHolder holder, int position)
        {
            throw new NotImplementedException();
        }

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }
    }
}
