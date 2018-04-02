using Foundation;
using System;
using UIKit;

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

                itemName.Text = itemData.itemName;
                itemCategory.Text = itemData.itemCategory;
                itemCode.Text = itemData.itemCode;
            }
        }

        public itemCell(IntPtr handle) : base(handle)
        {

        }
        internal void UpdateCell(Item item)
        {
            //itemNameLbl.Text = item.itemName;
            //itemNumberLbl.Text = item.itemNumber;
            itemCode.Text = item.itemCode;
        }
    }
}