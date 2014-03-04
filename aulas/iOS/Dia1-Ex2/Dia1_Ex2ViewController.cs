using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.CoreAnimation;

namespace Dia1Ex2
{
	public partial class Dia1_Ex2ViewController : UIViewController
	{
		private int modo = 0;

		public Dia1_Ex2ViewController () : base ("Dia1_Ex2ViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Libera a view da memória se ela não tem uma superview.
			base.DidReceiveMemoryWarning ();
			
			// Libere quaisquer dados em cache, imagens, etc. que não estão em uso.
		}

		void Shadow (bool active, UIView view)
		{
			if (active) {
				view.Layer.ShadowColor = UIColor.DarkGray.CGColor;
				view.Layer.ShadowOpacity = 0.9f;
				view.Layer.ShadowRadius = 6.0f;
				view.Layer.ShadowOffset = new SizeF (0f, 3f);
				view.Layer.MasksToBounds = false;
			} else {
				if (view.Layer.ShadowColor == UIColor.DarkGray.CGColor) {
					view.Layer.ShadowColor = UIColor.Clear.CGColor;
					view.Layer.ShadowOpacity = 0.0f;
					view.Layer.ShadowRadius = 0.0f;
					view.Layer.ShadowOffset = SizeF.Empty;
					view.Layer.MasksToBounds = false;
				}
			}
		}

		void TextGlow (bool active, UIButton buttonView)
		{
			if (active) {
				buttonView.TitleLabel.Layer.ShadowColor = UIColor.Blue.CGColor;
				buttonView.TitleLabel.Layer.ShadowRadius = 4.0f;
				buttonView.TitleLabel.Layer.ShadowOpacity = 0.9f;
				buttonView.TitleLabel.Layer.ShadowOffset = SizeF.Empty;
				buttonView.TitleLabel.Layer.MasksToBounds = false;
			} else {
				if (buttonView.TitleLabel.Layer.ShadowColor == UIColor.Blue.CGColor) {
					buttonView.TitleLabel.Layer.ShadowColor = UIColor.Clear.CGColor;
					buttonView.TitleLabel.Layer.ShadowRadius = 0.0f;
					buttonView.TitleLabel.Layer.ShadowOpacity = 0.0f;
					buttonView.TitleLabel.Layer.ShadowOffset = SizeF.Empty;
					buttonView.TitleLabel.Layer.MasksToBounds = false;
				}
			}
		}

		void Shine(bool active, UIView view) {
			if (view == null)
				throw new ArgumentNullException ("view");

			if (active) {
				view.Layer.ShadowColor = UIColor.Blue.CGColor;
				view.Layer.ShadowOpacity = 0.0f;
				view.Layer.ShadowRadius = 6.0f;
				view.Layer.ShadowOffset = SizeF.Empty;
				view.Layer.MasksToBounds = false;

				var glow = CABasicAnimation.FromKeyPath("shadowOpacity");
				glow.AutoReverses = true;
				glow.Duration = 0.5;
				glow.To = NSNumber.FromDouble (0.9);
				glow.RepeatCount = int.MaxValue;

				view.Layer.AddAnimation (glow, "glow");

			} else {
				view.Layer.RemoveAnimation ("glow");

				if (view.Layer.ShadowColor == UIColor.Blue.CGColor) {
					view.Layer.ShadowColor = UIColor.Clear.CGColor;
					view.Layer.ShadowOpacity = 0.0f;
					view.Layer.ShadowRadius = 0.0f;
					view.Layer.ShadowOffset = SizeF.Empty;
					view.Layer.MasksToBounds = false;
				}
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Execute quaisquer ajustes adicionais depois de carregar a view, tipicamente de uma nib.
			button.SetTitle("Button " + modo, UIControlState.Normal);
			button.SizeToFit ();
			button.Center = new PointF(View.Center.X, button.Center.Y);

			button.TouchUpInside += (object sender, EventArgs e) => {
				modo++;
				if (modo > 3) {
					if (textField.IsFirstResponder)
						textField.ResignFirstResponder();
					if (textView.IsFirstResponder)
						textView.ResignFirstResponder();
					View.BecomeFirstResponder();

					modo = 0;
				}

				button.SetTitle("Button " + modo, UIControlState.Normal);

				Shadow (modo == 1, textField);
				TextGlow (modo == 2, button);
				Shine (modo == 3, textField);
			};

			textField.ShouldReturn += delegate(UITextField field) {
				textView.BecomeFirstResponder();

				return true;
			};
		}

	}
}

