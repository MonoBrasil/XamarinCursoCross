using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dia1Ex4
{
    // O Delegate UIApplicationDelegate para a aplicação. Esta classe responde pela inicialização da
    // Interface do Usuário da aplicação, assim como por ouvir (e opcionalmente responder) pelos
    // eventos de aplicação do iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window;

        // Declaração da classe do ViewController para usar no caso do XIB
        //Dia1Ex4ViewController viewController;

        // Este método é invocado quando a aplicação é carregada e está pronta para rodar. Neste
        // método você deveria instanciar a janela, carregar a UI nela e fazê-la visível.
        //
        // Você tem 17 segundos para sair deste método ou o iOS irá finalizar a sua aplicação.
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);
			
            // Definir o ID da View no storyboard e fazer referência aqui.
            // É preciso definir também a classe do ViewController dentro do storyboard
            var storyboard = UIStoryboard.FromName("Dia1_Ex4", null);

            // Caso vá usar o .XIB É preciso criar a classe do View Controller e
            // no construtor dela chamar o base("xib_name.xib", null)
            //viewController = new Dia1Ex4ViewController();
            //window.RootViewController = viewController;
            window.RootViewController = (UIViewController)storyboard.InstantiateViewController("table_web_view");
            window.MakeKeyAndVisible();
			
            return true;
        }
    }
}

