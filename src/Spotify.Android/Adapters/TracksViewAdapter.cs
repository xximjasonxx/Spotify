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
        private readonly Action<TrackItemViewHolder> _tapAction;

        public TracksViewAdapter(Action<TrackItemViewHolder> tapAction)
        {
            _trackService = Container.Instance.Resolve<ITrackService>();
            _tapAction = tapAction;
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
            return new TrackItemViewHolder(itemView, _tapAction);
        }

        public class TrackItemViewHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder, View.IOnClickListener
        {
            private readonly Action<TrackItemViewHolder> _tapAction;

            public Track Track { get; set; }
            public TextView TrackNumber { get; private set; }
            public TextView TrackName { get; private set; }
            public TextView TrackDuration { get; private set; }
            public ImageView ToggleButton { get; private set; }

            public TrackItemViewHolder(View itemView, Action<TrackItemViewHolder> tapAction) : base(itemView)
            {
                TrackNumber = itemView.FindViewById<TextView>(Resource.Id.trackNumber);
                TrackName = itemView.FindViewById<TextView>(Resource.Id.trackName);
                TrackDuration = itemView.FindViewById<TextView>(Resource.Id.trackDuration);
                ToggleButton = itemView.FindViewById<ImageView>(Resource.Id.playToggle);

                _tapAction = tapAction;
                itemView.SetOnClickListener(this);
            }

            public void OnClick(View v)
            {
                _tapAction.Invoke(this);
            }

            public void StopTrack()
            {
                ToggleButton.SetImageResource(Resource.Drawable.ic_play_arrow);
            }

            public void StartTrack()
            {
                ToggleButton.SetImageResource(Resource.Drawable.ic_stop);
            }
        }
    }
}
