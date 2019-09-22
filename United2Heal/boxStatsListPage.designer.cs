// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace United2Heal
{
    [Register ("boxStatsListPage")]
    partial class boxStatsListPage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView boxStatsTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (boxStatsTableView != null) {
                boxStatsTableView.Dispose ();
                boxStatsTableView = null;
            }
        }
    }
}