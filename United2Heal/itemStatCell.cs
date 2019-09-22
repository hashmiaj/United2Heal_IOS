using Foundation;
using System;
using UIKit;
using United2Heal.Models;

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

                ItemName.Text = itemData.ItemName;
                itemQuantity.Text = itemData.ItemID + "x";
            }
        }

        internal void UpdateCell(Item item)
        {
            //ItemName.Text = item.ItemName;
            //itemQuantity.Text = item.itemCode;
        }
    }
}