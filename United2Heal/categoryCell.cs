using Foundation;
using System;
using UIKit;

namespace United2Heal
{
    public partial class categoryCell : UITableViewCell
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

                itemCategory.Text = itemData.itemCategory;
            }
        }

        public categoryCell(IntPtr handle) : base(handle)
        {

        }
        internal void UpdateCell(Item item)
        {
            //itemNameLbl.Text = item.itemName;
            //itemNumberLbl.Text = item.itemNumber; 
        }
    }
}