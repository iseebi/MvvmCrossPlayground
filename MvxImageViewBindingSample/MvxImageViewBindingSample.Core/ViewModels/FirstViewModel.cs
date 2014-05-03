using Cirrious.MvvmCross.ViewModels;

namespace MvxImageViewBindingSample.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }
    }
}

