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
    [Register ("itemStatCell")]
    partial class itemStatCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemQuantity { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (itemName != null) {
                itemName.Dispose ();
                itemName = null;
            }

            if (itemQuantity != null) {
                itemQuantity.Dispose ();
                itemQuantity = null;
            }
        }
    }
}