using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using ObjCRuntime;
using United2Heal.Models;

namespace United2Heal
{
    public partial class itemListController : UITableViewController
    {
        readonly List<Item> itemList;
        UISearchController searchController;
        ResultsTableController resultsTableController;
        bool searchControllerWasActive;
        bool searchControllerSearchFieldWasFirstResponder;


        public itemListController()
        {
        }

        public itemListController(IntPtr handle) : base(handle)
        {
            itemList = new List<Item>();

            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";

            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                string Query = "Select * From u2hdb.ItemTable Order by ItemName";

                using (MySqlCommand command = new MySqlCommand(Query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new Item()
                            {
                                ItemID = reader.GetString(0),
                                ItemName = reader.GetString(1)
                            });

                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            resultsTableController = new ResultsTableController
            {
                FilteredProducts = new List<Item>()
            };

            searchController = new UISearchController(resultsTableController)
            {
                WeakDelegate = this,
                DimsBackgroundDuringPresentation = false,
                WeakSearchResultsUpdater = this
            };

            searchController.SearchBar.SizeToFit();
            TableView.TableHeaderView = searchController.SearchBar;

            resultsTableController.TableView.WeakDelegate = this;
            searchController.SearchBar.WeakDelegate = this;

            DefinesPresentationContext = true;

            if (searchControllerWasActive)
            {
                searchController.Active = searchControllerWasActive;
                searchControllerWasActive = false;

                if (searchControllerSearchFieldWasFirstResponder)
                {
                    searchController.SearchBar.BecomeFirstResponder();
                    searchControllerSearchFieldWasFirstResponder = false;
                }
            }
        }


        List<Item> PerformSearch(string searchString)
        {
            searchString = searchString.Trim();
            string[] searchItems = string.IsNullOrEmpty(searchString)
                ? new string[0]
                : searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var filteredProducts = new List<Item>();

            foreach (var item in searchItems)
            {
                int code = Int32.MinValue;
                Int32.TryParse(item, out code);

                // double number = Double.MinValue;
                // Double.TryParse(item, out number);

                IEnumerable<Item> query =
                    from p in itemList
                    where p.ItemName.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0
                           || p.ItemID == code.ToString()
                    orderby p.ItemName
                    select p;

                filteredProducts.AddRange(query);
            }

            return filteredProducts.Distinct().ToList();
        }

        [Export("updateSearchResultsForSearchController:")]
        public virtual void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            var tableController = (ResultsTableController)searchController.SearchResultsController;
            tableController.FilteredProducts = PerformSearch(searchController.SearchBar.Text);
            tableController.TableView.ReloadData();
        }

        [Export("searchBarSearchButtonClicked:")]
        public virtual void SearchButtonClicked(UISearchBar searchBar)
        {
            searchBar.ResignFirstResponder();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return itemList.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Item selectedItem = (tableView == TableView) ? itemList[indexPath.Row] : resultsTableController.FilteredProducts[indexPath.Row];

            itemPage controller = this.Storyboard.InstantiateViewController("itemStory") as itemPage;
            this.NavigationController.PushViewController(controller, true);
            controller.ItemNameText = selectedItem.ItemName;
            controller.itemCodeText = selectedItem.ItemID;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Item item = itemList[indexPath.Row];

            var theCell = TableView.DequeueReusableCell((NSString)"cell_id", indexPath) as itemCell;
            theCell.ItemData = item;
            return theCell;

            /*
            var cell = tableView.DequeueReusableCell("cell_id") as itemCell;
            var data = itemList[indexPath.Row];
            cell.ItemData = data;
            return cell;
            */
        }
    }
}