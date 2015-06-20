// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Dia2Ex1
{
	[Register ("TelaTabBarViewController")]
	partial class TelaTabBarViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITabBar btnTabBar { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnTabBar != null) {
				btnTabBar.Dispose ();
				btnTabBar = null;
			}
		}
	}
}
