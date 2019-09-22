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
        UIKit.UILabel ExpirationLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker ExpirationPicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch ExpirationSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemCode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ItemName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView itemPageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField itemQuantField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton submit { get; set; }

        [Action ("ExpirationSwitchValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ExpirationSwitchValueChanged (UIKit.UISwitch sender);

        [Action ("Submit_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Submit_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BoxPicker != null) {
                BoxPicker.Dispose ();
                BoxPicker = null;
            }

            if (ExpirationLabel != null) {
                ExpirationLabel.Dispose ();
                ExpirationLabel = null;
            }

            if (ExpirationPicker != null) {
                ExpirationPicker.Dispose ();
                ExpirationPicker = null;
            }

            if (ExpirationSwitch != null) {
                ExpirationSwitch.Dispose ();
                ExpirationSwitch = null;
            }

            if (itemCode != null) {
                itemCode.Dispose ();
                itemCode = null;
            }

            if (ItemName != null) {
                ItemName.Dispose ();
                ItemName = null;
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