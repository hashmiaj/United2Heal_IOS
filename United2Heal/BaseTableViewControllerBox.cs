using System;
using UIKit;
using United2Heal.Models;
namespace United2Heal
{
    public class BaseTableViewControllerBox : UITableViewController
    {
        protected const string cellIdentifier = "box_cell_id";

        public BaseTableViewControllerBox()
        {
        }

        public BaseTableViewControllerBox(IntPtr handle) : base(handle)
        {
        }

        protected void ConfigureCell(UITableViewCell cell, BoxedItem product)
        {
            cell.TextLabel.Text = product.ItemName;
            //string detailedStr = string.Format("{0:C} | {1}", product.itemCode, product.itemCategory);
            //cell.DetailTextLabel.Text = detailedStr;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.RegisterNibForCellReuse(UINib.FromName("boxViewCell", null), cellIdentifier);
        }
    }
}
