using System;
using System.Linq;
using Android.Media;
using Android.Views;
using Android.Widget;
using Spotify.Common.IOC;
using Spotify.Common.Models;
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
            var vh = (TrackItemViewHolder)holder;
            var track = _trackService.AvailableTracks.ElementAt(position);

            vh.TrackNumber.Text = track.TrackNumber.ToString();
            vh.TrackName.Text = track.Name;
            vh.TrackDuration.Text = track.DurationDisplay;
            vh.Track = track;
        }

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.listitem_track, parent, false);
            return new TrackItemViewHolder(itemView);
        }

        public class TrackItemViewHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder
        {
            private readonly Action<TrackItemViewHolder> _tapAction;

            public Track Track { get; set; }
            public TextView TrackNumber { get; private set; }
            public TextView TrackName { get; private set; }
            public TextView TrackDuration { get; private set; }
            public ImageView ToggleButton { get; private set; }

            public TrackItemViewHolder(View itemView) : base(itemView)
            {
                TrackNumber = itemView.FindViewById<TextView>(Resource.Id.trackNumber);
                TrackName = itemView.FindViewById<TextView>(Resource.Id.trackName);
                TrackDuration = itemView.FindViewById<TextView>(Resource.Id.trackDuration);
                ToggleButton = itemView.FindViewById<ImageView>(Resource.Id.playToggle);
            }
        }
    }
}
