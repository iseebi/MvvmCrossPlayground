using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace RestoreTest.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        const string HelloKey = "Hello";

		string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        public MvxCommand ShowNext
        {
            get {
                return _showNext ?? (_showNext = new MvxCommand(() => ShowViewModel<SecondViewModel>()));
            }
        }
        MvxCommand _showNext;

        public FirstViewModel()
        {
            Mvx.Trace("********** FirstViewModel..ctor **********");
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            Mvx.Trace("********** FirstViewModel.InitFromBundle **********");
            base.InitFromBundle(parameters);
        }

        public override void Start()
        {
            Mvx.Trace("********** FirstViewModel.Start **********");
            base.Start();
        }

        protected override void ReloadFromBundle(IMvxBundle state)
        {
            Mvx.Trace("********** FirstViewModel.ReloadFromBundle **********");

            base.ReloadFromBundle(state);

            if (state != null)
            {
                Mvx.Trace("-- has state");
                if (state.Data.ContainsKey(HelloKey))
                {
                    Mvx.Trace("-- has value");
                    Hello = state.Data[HelloKey];
                }
            }
        }

        protected override void SaveStateToBundle(IMvxBundle bundle)
        {
            Mvx.Trace("********** FirstViewModel.SaveStateToBundle **********");

            base.SaveStateToBundle(bundle);

            bundle.Data.Add(HelloKey, Hello);
        }
    }
}
