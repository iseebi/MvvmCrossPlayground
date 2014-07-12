using Cirrious.MvvmCross.Droid.Views;
using Cirrious.CrossCore;
using Android.App;
using Android.OS;

namespace RestoreTest.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Mvx.Trace("********** FirstView.OnCreate **********");
            if (bundle != null)
            {
                Mvx.Trace("-- has bundle: {0}", bundle.ToString());
            }
            else
            {
                Mvx.Trace("-- no bundle");
            }
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            Mvx.Trace("********** FirstView.OnSaveInstanceState **********");
            base.OnSaveInstanceState(outState);
        }
    }
}