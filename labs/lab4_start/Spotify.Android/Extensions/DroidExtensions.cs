using System;
namespace Spotify.Droid.Extensions
{
    public static class DroidExtensions
    {
        public static void SetImageURI(this Android.Widget.ImageView imageView, Uri imageUri)
        {
            try
            {
                var uri = Android.Net.Uri.Parse(imageUri.ToString());
                imageView.SetImageURI(uri);
            }
            catch
            {
                // not a valid uri - do nothing
            }
        }
    }
}
