using Foundation;
using System;
using UIKit;
using United2Heal.Models;

namespace United2Heal
{
    public partial class itemCell : UITableViewCell
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

                ItemName.Text = itemData.ItemName;
                itemCode.Text = itemData.ItemID;
            }
        }

        public itemCell(IntPtr handle) : base(handle)
        {

        }
        internal void UpdateCell(Item item)
        {
            //ItemNameLbl.Text = item.ItemName;
            //itemNumberLbl.Text = item.itemNumber;
            itemCode.Text = item.ItemID;
        }
    }
}