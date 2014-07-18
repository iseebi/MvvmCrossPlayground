using System;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;

namespace RestoreTest.Droid.Views.Fragments
{
    public static class FragmentExtensions
    {
        public const string ExtrasKey = "MvxLaunchData";

        public static void ProvideViewModelRequest(this MvxFragment fragment, MvxViewModelRequest request)
        {
            var bundle = new Bundle();

            var converter = Mvx.Resolve<IMvxNavigationSerializer>();
            var requestText = converter.Serializer.SerializeObject(request);
            bundle.PutString(ExtrasKey, requestText);

            fragment.Arguments = bundle;
        }

        public static void CreateViewCalled(this MvxFragment fragment, LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            fragment.ViewModel = fragment.LoadViewModel(savedInstanceState);
        }

        public static void SaveInstanceStateCalled(this MvxFragment fragment, Bundle outState)
        {
            var mvxBundle = fragment.CreateSaveStateBundle();
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
            cache.Cache(fragment.ViewModel, outState);
        }

        static IMvxViewModel LoadViewModel(this MvxFragment fragment, Bundle savedInstanceState)
        {
            var viewModelType = fragment.FindAssociatedViewModelTypeOrNull();
            if (viewModelType == typeof(MvxNullViewModel))
                return new MvxNullViewModel();

            if (viewModelType == null
                || viewModelType == typeof (IMvxViewModel))
            {
                Mvx.Trace("No ViewModel class specified for {0} in LoadViewModel",
                               fragment.GetType().Name);
            }

            var extraData = fragment.Arguments.GetString(ExtrasKey);
            if (extraData == null)
                return null;

            var savedState = GetSavedStateFromBundle(savedInstanceState);

            var converter = Mvx.Resolve<IMvxNavigationSerializer>();
            var viewModelRequest = converter.Serializer.DeserializeObject<MvxViewModelRequest>(extraData);

            var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
            var viewModel = loaderService.LoadViewModel(viewModelRequest, savedState);
            return viewModel;
        }

        static IMvxBundle GetSavedStateFromBundle(Bundle bundle)
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
    }
}

