using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dia1Ex4
{
	public class Application
	{
		// Este é o ponto de entrada da sua aplicação.
		static void Main (string[] args)
		{
			// se você quer usar um Delegate diferente da classe "AppDelegate" para a aplicação
			// você pode especificá-lo aqui.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
