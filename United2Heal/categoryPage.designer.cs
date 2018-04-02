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
    [Register ("categoryPage")]
    partial class categoryPage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel categoryBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel categoryName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitBtn { get; set; }

        [Action ("SubmitBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (categoryBox != null) {
                categoryBox.Dispose ();
                categoryBox = null;
            }

            if (categoryName != null) {
                categoryName.Dispose ();
                categoryName = null;
            }

            if (SubmitBtn != null) {
                SubmitBtn.Dispose ();
                SubmitBtn = null;
            }
        }
    }
}