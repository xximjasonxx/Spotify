using System;
using Android.Support.V7.Widget;
using Android.Views;
using Spotify.Common.IOC;
using Spotify.Common.Services;

namespace Spotify.Droid.Adapters
{
    public class AlbumsViewAdapter : Android.Support.V7.Widget.RecyclerView.Adapter
    {
        private readonly IAlbumService _albumService;
        
        public override int ItemCount
        {
            get { return _albumService.CurrentAlbums.Count; }
        }

        public AlbumsViewAdapter()
        {
            _albumService = Container.Instance.Resolve<IAlbumService>();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }
    }
}
