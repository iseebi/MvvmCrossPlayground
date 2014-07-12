using Android.Content;
using Android.Views;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace RestoreTest.Droid.Views.Fragments
{
    public class FragmentBase : MvxFragment, IMvxAndroidView
    {
        public const string ExtrasKey = "MvxLaunchData";

        public void MvxInternalStartActivityForResult(Intent intent, int requestCode)
        {
            Activity.StartActivityForResult(intent, requestCode);
        }

        public LayoutInflater LayoutInflater
        {
            get { return Activity.LayoutInflater; }
        }

        public override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            ViewModel = LoadViewModel(savedInstanceState);
            base.OnCreate(savedInstanceState);
        }

        IMvxViewModel LoadViewModel(Android.OS.Bundle savedInstanceState)
        {
            var viewModelType = this.FindAssociatedViewModelTypeOrNull();
            if (viewModelType == typeof(MvxNullViewModel))
                return new MvxNullViewModel();

            if (viewModelType == null
                || viewModelType == typeof (IMvxViewModel))
            {
                Mvx.Trace("No ViewModel class specified for {0} in LoadViewModel",
                               GetType().Name);
            }

            var extraData = Arguments.GetString(ExtrasKey);
            if (extraData == null)
                return null;

            var savedState = GetSavedStateFromBundle(savedInstanceState);

            var converter = Mvx.Resolve<IMvxNavigationSerializer>();
            var viewModelRequest = converter.Serializer.DeserializeObject<MvxViewModelRequest>(extraData);

            var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
            var viewModel = loaderService.LoadViewModel(viewModelRequest, savedState);
            return viewModel;
        }

        private static IMvxBundle GetSavedStateFromBundle(Android.OS.Bundle bundle)
        {
            if (bundle == null)
                return null;

            IMvxSavedStateConverter converter; 
            if (!Mvx.TryResolve<IMvxSavedStateConverter>(out converter))
            {
                Mvx.Trace("No saved state converter available - this is OK if seen during start");
                return null;
            }
            var savedState = converter.Read(bundle);
            return savedState;
        }

        public override void OnSaveInstanceState(Android.OS.Bundle outState)
        {
            var mvxBundle = this.CreateSaveStateBundle();
            if (mvxBundle != null)
            {
                IMvxSavedStateConverter converter;
                if (!Mvx.TryResolve<IMvxSavedStateConverter>(out converter))
                {
                    Mvx.Warning("Saved state converter not available - saving state will be hard");
                }
                else
                {
                    converter.Write(outState, mvxBundle);
                }
            }
            var cache = Mvx.Resolve<IMvxSingleViewModelCache>();
            cache.Cache(ViewModel, outState);

            this.CreateSaveStateBundle();
        }
    }
}

