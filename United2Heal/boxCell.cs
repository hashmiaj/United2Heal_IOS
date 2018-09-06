using System;

using Foundation;
using UIKit;

namespace United2Heal
{
    public partial class boxCell : UITableViewCell
    {

        private Item itemData;

        public Item ItemData
        {
            get
            {
                return itemData;
            }
            set
            {
                itemData = value;

                boxName.Text = itemData.itemBox;
            }
        }

        protected boxCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
