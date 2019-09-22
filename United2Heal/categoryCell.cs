using Foundation;
using System;
using UIKit;
using United2Heal.Models;

namespace United2Heal
{
    public partial class categoryCell : UITableViewCell
    {
        private BoxedItem itemData;

        public BoxedItem ItemData
        {
            get
            {
                return itemData;
            }
            set
            {
                itemData = value;

                itemCategory.Text = itemData.ItemBoxGroup;
            }
        }

        public categoryCell(IntPtr handle) : base(handle)
        {

        }
        internal void UpdateCell(Item item)
        {
            //ItemNameLbl.Text = item.ItemName;
            //itemNumberLbl.Text = item.itemNumber; 
        }
    }
}