using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dia1Ex1
{
	public partial class Dia1_Ex1ViewController : UIViewController
	{
		protected int _numberOfTimesClicked = 0;

		public Dia1_Ex1ViewController () : base ("Dia1_Ex1ViewController", null)
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
			btnMeClique.TouchUpInside += (sender, e) => {
				_numberOfTimesClicked++;
				lblSaida.Text = "Clicado [" +
					_numberOfTimesClicked.ToString() + "] vezes!";
			};
		}

		/// ESte é o nosso manipulador de ações comum. Dois botões chamam ela via um método de ação.
		partial void actionButtonClick (NSObject sender)
		{
			lblSaida.Text = "Ação " +  ((UIButton)sender).CurrentTitle + " clicacda.";
		}
	}
}

