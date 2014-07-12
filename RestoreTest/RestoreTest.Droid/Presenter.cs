using System;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;

namespace RestoreTest.Droid
{
    public interface IFragmentHost
    {
        bool Show(MvxViewModelRequest request);
    }

    public class Presenter : MvxAndroidViewPresenter
    {
        public override void Show(MvxViewModelRequest request)
        {
            var host = Activity as IFragmentHost;
            if (host != null)
            {
                if (host.Show(request))
                {
                    return;
                }
            }

            base.Show(request);
        }
    }
}

