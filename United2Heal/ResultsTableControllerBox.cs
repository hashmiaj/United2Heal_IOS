using System;
using UIKit;
using System.Collections.Generic;
using Foundation;
using United2Heal.Models;

namespace United2Heal
{
    public class ResultsTableControllerBox : BaseTableViewControllerBox
    {
        public List<BoxedItem> FilteredProducts { get; set; }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return FilteredProducts.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            BoxedItem product = FilteredProducts[indexPath.Row];
            var cell = tableView.DequeueReusableCell("box_cell_id", indexPath) as boxCell;
            ConfigureCell(cell, product);
            return cell;
        }
    }
}
