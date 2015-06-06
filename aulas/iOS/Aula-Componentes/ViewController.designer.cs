// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AulaComponentes
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnAdicionar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgTeste { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTeste { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISlider slider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch switchImg { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtNumero { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtSenha { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnAdicionar != null) {
				btnAdicionar.Dispose ();
				btnAdicionar = null;
			}
			if (imgTeste != null) {
				imgTeste.Dispose ();
				imgTeste = null;
			}
			if (lblTeste != null) {
				lblTeste.Dispose ();
				lblTeste = null;
			}
			if (slider != null) {
				slider.Dispose ();
				slider = null;
			}
			if (switchImg != null) {
				switchImg.Dispose ();
				switchImg = null;
			}
			if (txtNumero != null) {
				txtNumero.Dispose ();
				txtNumero = null;
			}
			if (txtSenha != null) {
				txtSenha.Dispose ();
				txtSenha = null;
			}
		}
	}
}
