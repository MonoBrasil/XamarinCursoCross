using System;

using UIKit;
using System.Text;
using Foundation;
using CoreGraphics;

namespace AulaComponentes
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        int contador = 0;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            btnAdicionar.TouchUpInside += (sender, e) =>
            {
                contador++;
                var str = "ada " + contador.ToString() + "adsas";
                var sb = new StringBuilder();
                sb.Append("adadasdadas");
                sb.Append(contador);
                sb.Append("asdas");
                var str2 = sb.ToString();
                lblTeste.Text = String.Format("Click número {0}", contador);
                if (txtNumero.IsFirstResponder)
                    txtNumero.ResignFirstResponder();
            };

            imgTeste.Image = UIImage.LoadFromData(
                NSData.FromUrl(NSUrl.FromString(
                        "http://www.fillmurray.com/200/200")));

            switchImg.TouchUpInside += (sender, e) =>
            {
                ;
                imgTeste.Hidden = !switchImg.On;
                if (txtNumero.IsFirstResponder)
                    txtNumero.ResignFirstResponder();
            };

            slider.TouchUpInside += (sender, e) =>
            {
                txtNumero.Text = slider.Value.ToString();
                if (txtNumero.IsFirstResponder)
                    txtNumero.ResignFirstResponder();
            };

            txtNumero.Ended += (sender, e) =>
            {
                if (!String.IsNullOrEmpty(txtNumero.Text))
                {
                    slider.Value = float.Parse(txtNumero.Text);
                }
            };

            txtNumero.ShouldReturn = (textField) =>
            {
                txtNumero.ResignFirstResponder();
                return true;
            };

            txtNumero.TouchUpOutside += (sender, e) =>
            {
                txtNumero.ResignFirstResponder();
            };

            txtSenha.ShouldReturn = (textField) =>
            {
                txtSenha.ResignFirstResponder();
                return true;
            };

            txtNumero.ShouldBeginEditing = (textField) =>
            {
                NSNotificationCenter.DefaultCenter.AddObserver(
                    new NSString("keyboardOn"), (obj) =>
                    {
                        View.Frame = new CGRect(0, -110, 320, 460);
                    });

                return true;
            };

            txtSenha.ShouldBeginEditing = (textField) =>
            {
                NSNotificationCenter.DefaultCenter.AddObserver(
                    UIKeyboard.DidShowNotification, (obj) =>
                    {
                        View.Frame = new CGRect(0, -110, 320, 460);
                    });

                return true;
            };

            txtNumero.ShouldEndEditing = (textField) =>
            {
                NSNotificationCenter.DefaultCenter.AddObserver(
                    new NSString("keyboardOff"), (obj) =>
                    {
                        View.Frame = new CGRect(0, 0, 320, 460);
                    });

                return true;
            };

            txtSenha.ShouldEndEditing = (textField) =>
            {
                NSNotificationCenter.DefaultCenter.AddObserver(
                    UIKeyboard.DidHideNotification, (obj) =>
                    {
                        View.Frame = new CGRect(0, 0, 320, 460);
                    });

                return true;
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

