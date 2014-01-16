using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dia1Ex4
{
	public partial class Dia1_Ex4ViewController : UIViewController
	{
		public Dia1_Ex4ViewController () : base ("Dia1_Ex4ViewController", null)
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
			string url = "http://xamarin.com";
			webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

			string[] tableItems = new string[] {"Vegetais","Frutas","Flores","Legumes","Bulbos","Tubérculos"};
			tableView.Source = new TableSource(tableItems);
		}
	}
}

