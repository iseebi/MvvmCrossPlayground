using Cirrious.MvvmCross.ViewModels;
using System;

namespace MvxImageViewBindingSample.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        const string BaseUrlString = "http://half-done.net/misc/delayimage.php?delay={0:#}&text={1}";

        public FirstViewModel()
        {
            Delay = 5;
            MinimumDelay = 0;
            MaximumDelay = 15;

            GetCommand = new MvxCommand(() => {
                var text = Text ?? string.Empty;
                ImageUrl = string.Format(BaseUrlString, Delay, Uri.EscapeDataString(text));
            });
            ResetCommand = new MvxCommand(() => ImageUrl = null);
        }

        #region Commands

        public IMvxCommand GetCommand
        {
            get;
            private set;
        }

        public IMvxCommand ResetCommand
        {
            get;
            private set;
        }

        #endregion

        #region Properties 

        float _delay;
        public float Delay
        {
            get { return _delay; }
            set
            {
                _delay = value;
                RaisePropertyChanged(() => Delay);
            }
        }

        public float MinimumDelay { get; private set; }

        public float MaximumDelay { get; private set; }

        string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged(() => Text);
            }
        }

        string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            private set
            {
                _imageUrl = value;
                RaisePropertyChanged(() => ImageUrl);
            }
        }

        bool _useDefaultImage;
        public bool UseDefaultImage 
        {
            get { return _useDefaultImage; }
            private set
            {
                _useDefaultImage = value;
                RaisePropertyChanged(() => UseDefaultImage);
            }
        }

        #endregion
    }
}

