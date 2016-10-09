using System;
using Android.App;
using Android.Views;
using Android.Views.InputMethods;

namespace Spotify.Droid.Fragments.Abstract
{
    public class FragmentBase : Fragment
    {
        private ProgressDialog _progressDialog;

        protected void ShowProgressDialog(string message = "")
        {
            if (_progressDialog != null)
                HideProgressDialog();

            _progressDialog = new ProgressDialog(Activity, Resource.Style.ProgressDialog);
            _progressDialog.Window.SetGravity(GravityFlags.Center);
            _progressDialog.SetCancelable(false);

            if (!string.IsNullOrWhiteSpace(message))
                _progressDialog.SetMessage(message);
            
            _progressDialog.Indeterminate = true;
            _progressDialog.Show();
        }

        protected void HideProgressDialog()
        {
            if (_progressDialog != null)
            {
                _progressDialog.Hide();
                _progressDialog = null;
            }
        }

        protected void DismissSoftKeyboard()
        {
            var currentFocus = Activity.CurrentFocus;
            if (currentFocus != null) {
                InputMethodManager imm = (InputMethodManager)Activity.GetSystemService(Android.Content.Context.InputMethodService);
                imm.HideSoftInputFromWindow(currentFocus.WindowToken, 0);
            }
        }
    }
}
