using System;
using Foundation;
using UIKit;
using United2Heal.Models;

namespace United2Heal
{
    public partial class boxCell : UITableViewCell
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

                boxNumber.Text = itemData.ItemBoxNumber;
            }
        }

        protected boxCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
