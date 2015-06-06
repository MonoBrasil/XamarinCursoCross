using System;

using UIKit;
using System.Text;
using Foundation;

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
            };

            imgTeste.Image = UIImage.LoadFromData(
                NSData.FromUrl(NSUrl.FromString(
                        "http://www.fillmurray.com/200/200")));

            switchImg.TouchUpInside += (sender, e) =>
            {
                ;
                imgTeste.Hidden = !switchImg.On;
            };

            slider.TouchUpInside += (sender, e) =>
            {
                txtNumero.Text = slider.Value.ToString();
            };

            txtNumero.Ended += (sender, e) =>
            {
                slider.Value = float.Parse(txtNumero.Text);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

