using Cirrious.MvvmCross.ViewModels;

namespace RestoreTest.Droid
{
    public interface IFragmentHost
    {
        bool Show(MvxViewModelRequest request);
    }
}

