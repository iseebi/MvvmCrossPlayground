using System;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace RestoreTest.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        const string HelloKey = "Hello";

        public MvxCommand ShowNext
        {
            get {
                return _showNext ?? (_showNext = new MvxCommand(() => ShowViewModel<ThirdViewModel>()));
            }
        }
        MvxCommand _showNext;

        public SecondViewModel()
        {
            Mvx.Trace("********** SecondViewModel..ctor **********");
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            Mvx.Trace("********** SecondViewModel.InitFromBundle **********");
            base.InitFromBundle(parameters);
        }

        public override void Start()
        {
            Mvx.Trace("********** SecondViewModel.Start **********");
            base.Start();
        }

        protected override void ReloadFromBundle(IMvxBundle state)
        {
            Mvx.Trace("********** SecondViewModel.ReloadFromBundle **********");

            base.ReloadFromBundle(state);

            if (state != null)
            {
                Mvx.Trace("-- has state");
                if (state.Data.ContainsKey(HelloKey))
                {
                    Mvx.Trace("-- has value");
                }
            }
        }

        protected override void SaveStateToBundle(IMvxBundle bundle)
        {
            Mvx.Trace("********** SecondViewModel.SaveStateToBundle **********");

            base.SaveStateToBundle(bundle);

            bundle.Data.Add(HelloKey, HelloKey);
        }
    }
}

