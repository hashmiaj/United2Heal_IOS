using System;

using Foundation;
using UIKit;

namespace United2Heal
{
    public partial class categoryViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("categoryViewCell");
        public static readonly UINib Nib;

        static categoryViewCell()
        {
            Nib = UINib.FromName("categoryViewCell", NSBundle.MainBundle);
        }

        protected categoryViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
