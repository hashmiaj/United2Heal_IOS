using System;
using UIKit;
using System.Collections.Generic;
using Foundation;
namespace United2Heal
{
    public class ResultsTableControllerCat : BaseTableViewControllerCat
    {
        public List<Item> FilteredProducts { get; set; }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return FilteredProducts.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Item product = FilteredProducts[indexPath.Row];
            //var cell = tableView.DequeueReusableCell("cell_id") as itemCell;
            var cell = tableView.DequeueReusableCell("cat_cell_id", indexPath) as categoryCell;
            ConfigureCell(cell, product);
            return cell;
        }
    }
}
