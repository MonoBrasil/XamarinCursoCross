using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dia1Ex2
{
	public partial class Dia1_Ex2ViewController : UIViewController
	{
		public Dia1_Ex2ViewController () : base ("Dia1_Ex2ViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Libera a view da memória se ela não tem uma superview.
			base.DidReceiveMemoryWarning ();
			
			// Libere quaisquer dados em cache, imagens, etc. que não estão em uso.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Execute quaisquer ajustes adicionais depois de carregar a view, tipicamente de uma nib.

			button.TouchUpInside += (object sender, EventArgs e) => {
				textView.ResignFirstResponder();
			};

			textField.ShouldReturn += delegate(UITextField field) {
				textView.BecomeFirstResponder();

				return true;
			};
		}

	}
}

