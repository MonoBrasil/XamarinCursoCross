using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Dia1Ex3
{
	public partial class Dia1_Ex3ViewController : UIViewController
	{
		public Dia1_Ex3ViewController () : base ("Dia1_Ex3ViewController", null)
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
		}
	}
}

