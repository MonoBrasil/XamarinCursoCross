// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace WebserviceClient
{
	[Register ("WebserviceClientViewController")]
	partial class WebserviceClientViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton bntLogin { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblStatus { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtLogin { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtSenha { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtLogin != null) {
				txtLogin.Dispose ();
				txtLogin = null;
			}

			if (txtSenha != null) {
				txtSenha.Dispose ();
				txtSenha = null;
			}

			if (bntLogin != null) {
				bntLogin.Dispose ();
				bntLogin = null;
			}

			if (lblStatus != null) {
				lblStatus.Dispose ();
				lblStatus = null;
			}
		}
	}
}
