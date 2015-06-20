using System;

using UIKit;

namespace Dia2Ex1
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            btnAcao.TouchUpInside += (sender, e) =>
            {
                var viewController = Storyboard.InstantiateViewController("tab_bar");

                // Usando o NavigationController precisamos mostrar usando este método para telas principais
                NavigationController.ShowViewController(viewController, this);

                // Usando o NavigationController precisamos mostrar usando este método para telas de detalhe secundárias
//                NavigationController.ShowDetailViewController(viewController, this);

                // Para trocar de tela, sem o NavigationController, usamos este método
//                PresentViewController(viewController, true, null);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

