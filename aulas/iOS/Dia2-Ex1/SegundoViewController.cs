using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Dia2Ex1
{
    partial class SegundoViewController : UIViewController
    {
        public SegundoViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.SetNavigationBarHidden(false, true);
        }
    }
}
