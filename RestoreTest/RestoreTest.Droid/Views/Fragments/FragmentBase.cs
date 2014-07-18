using Android.Views;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;

namespace RestoreTest.Droid.Views.Fragments
{
    public class FragmentBase : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            this.CreateViewCalled(inflater, container, savedInstanceState);
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnSaveInstanceState(Android.OS.Bundle outState)
        {
            this.SaveInstanceStateCalled(outState);
        }
    }
}

