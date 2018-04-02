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
    [Register ("addNewItemPage")]
    partial class addNewItemPage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView categoryPicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton generateBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel itemBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField itemCodeField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField itemNameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton submitBtn { get; set; }

        [Action ("GenerateBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GenerateBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (categoryPicker != null) {
                categoryPicker.Dispose ();
                categoryPicker = null;
            }

            if (generateBtn != null) {
                generateBtn.Dispose ();
                generateBtn = null;
            }

            if (itemBox != null) {
                itemBox.Dispose ();
                itemBox = null;
            }

            if (itemCodeField != null) {
                itemCodeField.Dispose ();
                itemCodeField = null;
            }

            if (itemNameField != null) {
                itemNameField.Dispose ();
                itemNameField = null;
            }

            if (submitBtn != null) {
                submitBtn.Dispose ();
                submitBtn = null;
            }
        }
    }
}