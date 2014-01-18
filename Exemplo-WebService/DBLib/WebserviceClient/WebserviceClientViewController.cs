using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace WebserviceClient
{
	public partial class WebserviceClientViewController : UIViewController
	{
		public WebserviceClientViewController () : base ("WebserviceClientViewController", null)
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
			
			// Perform any additional setup after loading the view, typically from a nib.

			bntLogin.TouchUpInside += (object sender, EventArgs e) => {
				string usuario = txtLogin.Text;
				string senha = txtSenha.Text;

				webserviceTeste.Service1 ws = new webserviceTeste.Service1 ();
				lblStatus.Text = ws.MakeLogin (usuario, senha) ? "OK" : "Não OK";
			};
		}
	}
}

