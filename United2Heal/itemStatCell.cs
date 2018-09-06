using Foundation;
using System;
using UIKit;

namespace United2Heal
{
    public partial class itemStatCell : UITableViewCell
    {
        public itemStatCell (IntPtr handle) : base (handle)
        {
        }

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

                itemName.Text = itemData.itemName;
                itemQuantity.Text = itemData.itemCode + "x";
            }
        }

        internal void UpdateCell(Item item)
        {
            //itemName.Text = item.itemName;
            //itemQuantity.Text = item.itemCode;
        }
    }
}