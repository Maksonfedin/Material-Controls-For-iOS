
using System;

using Foundation;
using MaterialControls.Xamarin.Sample.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using UIKit;


namespace MaterialControls.Xamarin.Sample.iOS.Views
{
	public partial class ProgressView : BaseView<ProgressViewModel>
	{
		public ProgressView () : base ("ProgressView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var _progress = new MDProgress
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
				CircularSize = 20f,// any sizes
				ProgressColor = UIColor.Blue,
				ProgressType = MDProgressType.Indeterminate,
				ProgressStyle = MDProgressStyle.Circular,
				TrackWidth = 2f
			};

			var children = _progress.Layer.Sublayers;
			children[0].RemoveFromSuperLayer();

			_progress.Center = new CoreGraphics.CGPoint(40, 40);
			View.AddSubview(_progress);

			Title="MDProgress";
			var set = this.CreateBindingSet<ProgressView, ProgressViewModel> ();
			set.Bind (CircularProgress).To (vm => vm.Progress).For(v=>v.Progress);
			set.Bind (LinearProgress).To (vm => vm.Progress).For(v=>v.Progress);
			set.Apply ();
		}
	}
}

