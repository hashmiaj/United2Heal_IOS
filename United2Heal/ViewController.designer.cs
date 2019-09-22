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
        UIKit.UILabel ChooseLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton closeBoxBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GMUButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GoBackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GroupLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView GroupPicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView LaunchView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PasswordLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SchoolLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton searchBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SelectGroupLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton VCUButton { get; set; }

        [Action ("AddNewItemBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddNewItemBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("GMUButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GMUButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("GoBackButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GoBackButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("SubmitButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("VCUButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void VCUButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (addNewItemBtn != null) {
                addNewItemBtn.Dispose ();
                addNewItemBtn = null;
            }

            if (ChooseLabel != null) {
                ChooseLabel.Dispose ();
                ChooseLabel = null;
            }

            if (closeBoxBtn != null) {
                closeBoxBtn.Dispose ();
                closeBoxBtn = null;
            }

            if (GMUButton != null) {
                GMUButton.Dispose ();
                GMUButton = null;
            }

            if (GoBackButton != null) {
                GoBackButton.Dispose ();
                GoBackButton = null;
            }

            if (GroupLabel != null) {
                GroupLabel.Dispose ();
                GroupLabel = null;
            }

            if (GroupPicker != null) {
                GroupPicker.Dispose ();
                GroupPicker = null;
            }

            if (LaunchView != null) {
                LaunchView.Dispose ();
                LaunchView = null;
            }

            if (PasswordField != null) {
                PasswordField.Dispose ();
                PasswordField = null;
            }

            if (PasswordLabel != null) {
                PasswordLabel.Dispose ();
                PasswordLabel = null;
            }

            if (SchoolLabel != null) {
                SchoolLabel.Dispose ();
                SchoolLabel = null;
            }

            if (searchBtn != null) {
                searchBtn.Dispose ();
                searchBtn = null;
            }

            if (SelectGroupLabel != null) {
                SelectGroupLabel.Dispose ();
                SelectGroupLabel = null;
            }

            if (SubmitButton != null) {
                SubmitButton.Dispose ();
                SubmitButton = null;
            }

            if (VCUButton != null) {
                VCUButton.Dispose ();
                VCUButton = null;
            }
        }
    }
}