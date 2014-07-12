using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.CrossCore;

namespace RestoreTest.Droid.Views.Fragments
{
    public class ThirdView : MvxFragment
    {
        public override void OnAttach(Android.App.Activity activity)
        {
            Mvx.Trace("********** ThirdView.OnAttach **********");
            base.OnAttach(activity);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            Mvx.Trace("********** ThirdView.OnCreate **********");
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Mvx.Trace("********** ThirdView.OnCreateView **********");
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.ThirdView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            Mvx.Trace("********** ThirdView.OnViewCreated **********");
            base.OnViewCreated(view, savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Mvx.Trace("********** ThirdView.OnActivityCreated **********");
            base.OnActivityCreated(savedInstanceState);
        }

        public override void OnStart()
        {
            Mvx.Trace("********** ThirdView.OnStart **********");
            base.OnStart();
        }

        public override void OnResume()
        {
            Mvx.Trace("********** ThirdView.OnResume **********");
            base.OnResume();
        }

        public override void OnPause()
        {
            Mvx.Trace("********** ThirdView.OnPause **********");
            base.OnPause();
        }

        public override void OnStop()
        {
            Mvx.Trace("********** ThirdView.OnStop **********");
            base.OnStop();
        }

        public override void OnDestroyView()
        {
            Mvx.Trace("********** ThirdView.OnDestroyView **********");
            base.OnDestroyView();
        }

        public override void OnDetach()
        {
            Mvx.Trace("********** ThirdView.OnDetach **********");
            base.OnDetach();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            Mvx.Trace("********** ThirdView.OnSaveInstanceState **********");
            base.OnSaveInstanceState(outState);
        }
    }
}

