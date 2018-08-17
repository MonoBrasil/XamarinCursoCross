// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Dia1Ex1
{
	[Register ("Dia1_Ex1ViewController")]
	partial class Dia1_Ex1ViewController
	{
		[Outlet]
		UIKit.UIButton btnMeClique { get; set; }

		[Outlet]
		UIKit.UILabel lblSaida { get; set; }

		[Action ("actionButtonClick:")]
		partial void actionButtonClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (lblSaida != null) {
				lblSaida.Dispose ();
				lblSaida = null;
			}

			if (btnMeClique != null) {
				btnMeClique.Dispose ();
				btnMeClique = null;
			}
		}
	}
}
