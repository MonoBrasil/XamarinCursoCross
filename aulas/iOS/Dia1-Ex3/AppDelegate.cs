using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dia1Ex3
{
	// O Delegate UIApplicationDelegate para a aplicação. Esta classe responde pela inicialização da
	// Interface do Usuário da aplicação, assim como por ouvir (e opcionalmente responder) pelos
	// eventos de aplicação do iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		Dia1_Ex3ViewController viewController;

		// Este método é invocado quando a aplicação é carregada e está pronta para rodar. Neste
		// método você deveria instanciar a janela, carregar a UI nela e fazê-la visível.
		//
		// Você tem 17 segundos para sair deste método ou o iOS irá finalizar a sua aplicação.
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new Dia1_Ex3ViewController ();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

