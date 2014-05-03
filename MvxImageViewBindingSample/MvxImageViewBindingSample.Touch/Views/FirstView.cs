using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using MvxImageViewBindingSample.Core.ViewModels;
using MonoTouch.UIKit;

namespace MvxImageViewBindingSample.Touch.Views
{
    public partial class FirstView : MvxViewController
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = true;


            View.AddGestureRecognizer(new UITapGestureRecognizer(() => { 
                if (TextField.IsFirstResponder) {
                    TextField.ResignFirstResponder(); 
                }
            }));

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(TextField).To(vm => vm.Text).TwoWay();
            set.Bind(DelaySlider).For(ctl => ctl.MinValue).To(vm => vm.MinimumDelay);
            set.Bind(DelaySlider).For(ctl => ctl.MaxValue).To(vm => vm.MaximumDelay);
            set.Bind(DelaySlider).To(vm => vm.Delay).TwoWay();
            set.Bind(DelayValueLabel).To(vm => vm.Delay).WithConversion("FloatIntegerDisplay");
            set.Bind(DefaultImageSwitch).To(vm => vm.UseDefaultImage);
            set.Bind(ImageView).To(vm => vm.ImageUrl);
            set.Bind(ImageView).For(ctl => ctl.DefaultImagePath).To(vm => vm.UseDefaultImage).WithConversion("BoolString", "res:pic_empty.png");
            set.Bind(GetButton).For("TouchUpInside").To("GetCommand");
            set.Bind(ResetButton).For("TouchUpInside").To("ResetCommand");
            set.Apply();
        }
    }
}
