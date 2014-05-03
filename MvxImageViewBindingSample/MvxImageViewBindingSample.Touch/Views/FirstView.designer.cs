// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace MvxImageViewBindingSample.Touch.Views
{
	[Register ("FirstView")]
	partial class FirstView
	{
		[Outlet]
		MonoTouch.UIKit.UISwitch DefaultImageSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider DelaySlider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel DelayValueLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GetButton { get; set; }

		[Outlet]
		Cirrious.MvvmCross.Binding.Touch.Views.MvxImageView ImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ResetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField TextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DelaySlider != null) {
				DelaySlider.Dispose ();
				DelaySlider = null;
			}

			if (DelayValueLabel != null) {
				DelayValueLabel.Dispose ();
				DelayValueLabel = null;
			}

			if (GetButton != null) {
				GetButton.Dispose ();
				GetButton = null;
			}

			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}

			if (ResetButton != null) {
				ResetButton.Dispose ();
				ResetButton = null;
			}

			if (TextField != null) {
				TextField.Dispose ();
				TextField = null;
			}

			if (DefaultImageSwitch != null) {
				DefaultImageSwitch.Dispose ();
				DefaultImageSwitch = null;
			}
		}
	}
}
