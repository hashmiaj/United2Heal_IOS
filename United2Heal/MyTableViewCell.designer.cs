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
    [Register ("MyTableViewCell")]
    partial class MyTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemCategory { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemCode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (itemCategory != null) {
                itemCategory.Dispose ();
                itemCategory = null;
            }

            if (itemCode != null) {
                itemCode.Dispose ();
                itemCode = null;
            }

            if (itemName != null) {
                itemName.Dispose ();
                itemName = null;
            }
        }
    }
}