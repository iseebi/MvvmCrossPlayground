using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace RestoreTest.Core.ViewModels
{
    public class ThirdViewModel : MvxViewModel
    {
        const string HelloKey = "Hello";

        string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }

        public ThirdViewModel()
        {
            Mvx.Trace("********** ThirdViewModel..ctor **********");
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            Mvx.Trace("********** ThirdViewModel.InitFromBundle **********");
            base.InitFromBundle(parameters);
        }

        public override void Start()
        {
            Mvx.Trace("********** ThirdViewModel.Start **********");
            base.Start();
        }

        protected override void ReloadFromBundle(IMvxBundle state)
        {
            Mvx.Trace("********** ThirdViewModel.ReloadFromBundle **********");

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
            Mvx.Trace("********** ThirdViewModel.SaveStateToBundle **********");

            base.SaveStateToBundle(bundle);

            bundle.Data.Add(HelloKey, Hello);
        }
    }
}

