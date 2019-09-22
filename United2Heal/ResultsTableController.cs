using System;
using UIKit;
using System.Collections.Generic;
using Foundation;
using United2Heal.Models;
namespace United2Heal
{
    public class ResultsTableController : BaseTableViewController
    {
        public List<Item> FilteredProducts { get; set; }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return FilteredProducts.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Item product = FilteredProducts[indexPath.Row];
            var cell = tableView.DequeueReusableCell("cell_id", indexPath) as itemCell;
            ConfigureCell(cell, product);
            return cell;
        }
    }
}
