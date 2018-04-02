using System;
using UIKit;
namespace United2Heal
{
    public class BaseTableViewControllerCat : UITableViewController
    {
        protected const string cellIdentifier = "cat_cell_id";

        public BaseTableViewControllerCat()
        {
        }

        public BaseTableViewControllerCat(IntPtr handle) : base(handle)
        {
        }

        protected void ConfigureCell(UITableViewCell cell, Item product)
        {
            cell.TextLabel.Text = product.itemName;
            //string detailedStr = string.Format("{0:C} | {1}", product.itemCode, product.itemCategory);
            //cell.DetailTextLabel.Text = detailedStr;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.RegisterNibForCellReuse(UINib.FromName("categoryViewCell", null), cellIdentifier);
        }
    }
}
