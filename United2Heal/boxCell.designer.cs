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
    [Register ("boxCell")]
    partial class boxCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel boxName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel boxNumber { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (boxName != null) {
                boxName.Dispose ();
                boxName = null;
            }

            if (boxNumber != null) {
                boxNumber.Dispose ();
                boxNumber = null;
            }
        }
    }
}