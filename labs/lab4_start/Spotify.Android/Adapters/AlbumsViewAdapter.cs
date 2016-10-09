using System;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Spotify.Common.IOC;
using Spotify.Droid.Extensions;
using Spotify.Common.Models;
using Spotify.Common.Services;
using Com.Bumptech.Glide;
using Android.Content;
using Android.App;

namespace Spotify.Droid.Adapters
{
    public class AlbumsViewAdapter : Android.Support.V7.Widget.RecyclerView.Adapter
    {
        private readonly Action<Album> _selectAction;
        private readonly IAlbumService _albumService;
        private readonly WeakReference<Fragment> _parentFragment;

        public override int ItemCount
        {
            get { return _albumService.CurrentAlbums.Count; }
        }

        public AlbumsViewAdapter(Fragment fragment, Action<Album> selectAction)
        {
            _selectAction = selectAction;
            _albumService = Container.Instance.Resolve<IAlbumService>();
            _parentFragment = new WeakReference<Fragment>(fragment);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = (AlbumItemViewHolder)holder;
            var album = _albumService.CurrentAlbums.ElementAt(position);
            Fragment parentFragment;
            _parentFragment.TryGetTarget(out parentFragment);

            if (album.Images.Any() && parentFragment != null)
            {
                
                Glide.With(parentFragment)
                     .Load(album.Images[0].Url)
                     .FitCenter()
                     .CrossFade()
                     .Into(vh.AlbumImage);
            }
            else
            {
                vh.AlbumImage.Visibility = ViewStates.Gone;
            }

            vh.AlbumName.Text = album.Name;
            vh.TheAlbum = album;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.carditem_album, parent, false);
            return new AlbumItemViewHolder(view, _selectAction);
        }

        class AlbumItemViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
        {
            private readonly Action<Album> _tapAction;

            public Album TheAlbum { get; set; }
            public ImageView AlbumImage { get; private set; }
            public TextView AlbumName { get; private set; }

            public AlbumItemViewHolder(View itemView, Action<Album> tapAction) : base(itemView)
            {
                _tapAction = tapAction;
                itemView.SetOnClickListener(this);

                AlbumImage = itemView.FindViewById<ImageView>(Resource.Id.albumImage);
                AlbumName = itemView.FindViewById<TextView>(Resource.Id.albumName);
            }

            public void OnClick(View v)
            {
                _tapAction.Invoke(TheAlbum);
            }
        }
    }
}
