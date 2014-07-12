using Cirrious.MvvmCross.Droid.Views;
using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using RestoreTest.Core.ViewModels;
using RestoreTest.Droid.Views.Fragments;

namespace RestoreTest.Droid.Views
{
    [Activity(Label = "View for SecondViewModel")]
    public class SecondView : MvxActivity, IFragmentHost
    {
        ThirdView _thirdViewFragment;

        protected override void OnCreate(Bundle bundle)
        {
            Mvx.Trace("********** SecondView.OnCreate **********");
            if (bundle != null)
            {
                Mvx.Trace("-- has bundle: {0}", bundle.ToString());
            }
            else
            {
                Mvx.Trace("-- no bundle");
            }
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SecondView);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            Mvx.Trace("********** SecondView.OnSaveInstanceState **********");
            base.OnSaveInstanceState(outState);
        }

        #region IFragmentHost implementation

        public bool Show(MvxViewModelRequest request)
        {
            if (request.ViewModelType == typeof(ThirdViewModel))
            {
                if (_thirdViewFragment == null)
                {
                    _thirdViewFragment = new ThirdView();
                    var trans = FragmentManager.BeginTransaction();
                    trans.Add(Resource.Id.fragmentFrame, _thirdViewFragment);
                    trans.Commit();
                }

                var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
                var viewModel = loaderService.LoadViewModel(request, null /* saved state */);
                _thirdViewFragment.ViewModel = viewModel;

                return true;
            }
            return false;
        }

        #endregion
    }
}

