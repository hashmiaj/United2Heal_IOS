using System;

using Foundation;
using UIKit;

namespace United2Heal
{
    public partial class itemCellX : UITableViewCell
    {
        public static readonly NSString Key = new NSString("itemCellX");
        public static readonly UINib Nib;
        private Item itemData;
        public itemCellX(IntPtr handle) : base(handle)
        {

        }

        static itemCellX()
        {
            Nib = UINib.FromName("itemCellX", NSBundle.MainBundle);
        }

        public Item ItemData
        {
            get
            {
                return itemData;
            }
            set
            {
                itemData = value;

                itemName.Text = itemData.itemName;
                itemCategory.Text = itemData.itemCategory;
                itemCode.Text = itemData.itemCode;
            }
        }
    }
}
