using System;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Drawing;

namespace PaintCode
{
	public partial class PaintCodeViewController : UIViewController
	{
		public PaintCodeViewController () : base ("PaintCodeViewController", null)
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
			//// General Declarations

			int x = (int) (View.Bounds.Width  - 240) / 2;
			int y = (int) (View.Bounds.Height - 240) / 2;

			PaintCode button = new PaintCode(new RectangleF(x, y, 240, 240));
			Add (button);
		}
	}
}

