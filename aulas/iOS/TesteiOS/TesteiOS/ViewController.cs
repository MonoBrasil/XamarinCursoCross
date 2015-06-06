using System;

using UIKit;

namespace TesteiOS
{
	public partial class ViewController : UIViewController
	{
		private int count = 0;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnTeste.TouchUpInside += (sender, e) => {
				count++;

				lblTexto.Text = String.Format("Clique número {0}", count);
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

	}
}

