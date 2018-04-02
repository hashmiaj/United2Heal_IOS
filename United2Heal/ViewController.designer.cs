// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace United2Heal
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton addNewItemBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton closeBoxBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton exportExcelBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton searchBtn { get; set; }

        [Action ("AddNewItemBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddNewItemBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("ExportExcelBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ExportExcelBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (addNewItemBtn != null) {
                addNewItemBtn.Dispose ();
                addNewItemBtn = null;
            }

            if (closeBoxBtn != null) {
                closeBoxBtn.Dispose ();
                closeBoxBtn = null;
            }

            if (exportExcelBtn != null) {
                exportExcelBtn.Dispose ();
                exportExcelBtn = null;
            }

            if (searchBtn != null) {
                searchBtn.Dispose ();
                searchBtn = null;
            }
        }
    }
}