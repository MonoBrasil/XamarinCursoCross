using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dia1Ex4
{
    public partial class Dia1Ex4ViewController : UIViewController
    {
        // Construtor que pega o ponteiro para a classe nativa
        // Para podermos especificar o Dia1_Ex4.storyboard
        // Obs.: O método UIStoryboard.FromName("nome_do_arquivo", null) irá
        //       criar uma classe nativa que gerencia o storyboard, por isso
        //       precisamos de trabalhar com os ponteiros.
        public Dia1Ex4ViewController(IntPtr handle)
            : base(handle)
        {
        }

        // Construtor da classe base especificando o Dia1_Ex4ViewController,xib
        public Dia1Ex4ViewController()
            : base("Dia1_Ex4ViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Libera a view da memória se ela não tem uma superview.
            base.DidReceiveMemoryWarning();

            // Libere quaisquer dados em cache, imagens, etc. que não estão em uso.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Execute quaisquer ajustes adicionais depois de carregar a view, tipicamente de uma nib.
            const string url = "http://xamarin.com";
            webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

            string[] tableItems = { "Vegetais", "Frutas", "Flores", "Legumes", "Bulbos", "Tubérculos" };
            tableView.Source = new TableSource(tableItems);
        }
    }
}

