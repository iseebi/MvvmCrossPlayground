using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.CrossCore;

namespace RestoreTest.Droid.Views.Fragments
{
    public class ThirdView : FragmentBase 
    {
        public override void OnAttach(Android.App.Activity activity)
        {
            Mvx.Trace("********** ThirdView.OnAttach **********");
            CheckViewModel();
            base.OnAttach(activity);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            Mvx.Trace("********** ThirdView.OnCreate **********");
            CheckViewModel();
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Mvx.Trace("********** ThirdView.OnCreateView **********");
            CheckViewModel();
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.ThirdView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            Mvx.Trace("********** ThirdView.OnViewCreated **********");
            CheckViewModel();
            base.OnViewCreated(view, savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Mvx.Trace("********** ThirdView.OnActivityCreated **********");
            CheckViewModel();
            base.OnActivityCreated(savedInstanceState);
        }

        public override void OnStart()
        {
            Mvx.Trace("********** ThirdView.OnStart **********");
            CheckViewModel();
            base.OnStart();
        }

        public override void OnResume()
        {
            Mvx.Trace("********** ThirdView.OnResume **********");
            CheckViewModel();
            base.OnResume();
        }

        public override void OnPause()
        {
            Mvx.Trace("********** ThirdView.OnPause **********");
            CheckViewModel();
            base.OnPause();
        }

        public override void OnStop()
        {
            Mvx.Trace("********** ThirdView.OnStop **********");
            CheckViewModel();
            base.OnStop();
        }

        public override void OnDestroyView()
        {
            Mvx.Trace("********** ThirdView.OnDestroyView **********");
            CheckViewModel();
            base.OnDestroyView();
        }

        public override void OnDetach()
        {
            Mvx.Trace("********** ThirdView.OnDetach **********");
            CheckViewModel();
            base.OnDetach();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            Mvx.Trace("********** ThirdView.OnSaveInstanceState **********");
            CheckViewModel();
            base.OnSaveInstanceState(outState);
        }

        void CheckViewModel()
        {
            if (ViewModel == null)
            {
                Mvx.Trace("-- ViewModel isn't exist");
            }
            else
            {
                Mvx.Trace("-- ViewModel is exist");
            }
        }
    }
}

