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
    [Register ("itemController")]
    partial class itemController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemCategory { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemCode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField itemQuantField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitBtn { get; set; }

        [Action ("SubmitBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton2742_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton2742_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (itemBox != null) {
                itemBox.Dispose ();
                itemBox = null;
            }

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

            if (itemQuantField != null) {
                itemQuantField.Dispose ();
                itemQuantField = null;
            }

            if (SubmitBtn != null) {
                SubmitBtn.Dispose ();
                SubmitBtn = null;
            }
        }
    }
}