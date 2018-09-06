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
    [Register ("itemPage")]
    partial class itemPage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView BoxPicker { get; set; }

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
        UIKit.UIView itemPageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField itemQuantField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton submit { get; set; }

        [Action ("Submit_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Submit_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BoxPicker != null) {
                BoxPicker.Dispose ();
                BoxPicker = null;
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

            if (itemPageView != null) {
                itemPageView.Dispose ();
                itemPageView = null;
            }

            if (itemQuantField != null) {
                itemQuantField.Dispose ();
                itemQuantField = null;
            }

            if (submit != null) {
                submit.Dispose ();
                submit = null;
            }
        }
    }
}