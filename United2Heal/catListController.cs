using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using United2Heal.Models;

namespace United2Heal
{
    public partial class catListController : UITableViewController
    {
        readonly List<BoxedItem> itemList;
        UISearchController searchController;
        ResultsTableControllerCat resultsTableController;
        bool searchControllerWasActive;
        bool searchControllerSearchFieldWasFirstResponder;

        public catListController (IntPtr handle) : base (handle)
        {
            Title = "Group List";

            itemList = new List<BoxedItem>();
            List<String> columnCategory = new List<String>();

            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";


            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                String queryCategory = "select distinct GroupName from u2hdb.ItemBox where School = '" + GlobalVariables.SchoolName + "' Order by GroupName";
                using (MySqlCommand command = new MySqlCommand(queryCategory, connection)) 
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnCategory.Add(reader["GroupName"].ToString());;
                        }
                        reader.Close();
                    }
                }
                connection.Close(); 
            }

            for (int i = 0; i < columnCategory.Count; i++)
            {
                itemList.Add(new BoxedItem()
                {
                    ItemName = "",
                    ItemID = "1",
                    ItemBoxGroup = columnCategory[i]
                });
            }

        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            resultsTableController = new ResultsTableControllerCat
            {
                FilteredProducts = new List<BoxedItem>()
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


        List<BoxedItem> PerformSearch(string searchString)
        {
            searchString = searchString.Trim();
            string[] searchItems = string.IsNullOrEmpty(searchString)
                ? new string[0]
                : searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var filteredProducts = new List<BoxedItem>();

            foreach (var item in searchItems)
            {
                int code = Int32.MinValue;
                Int32.TryParse(item, out code);

                // double number = Double.MinValue;
                // Double.TryParse(item, out number);

                IEnumerable<BoxedItem> query =
                    from p in itemList
                        where p.ItemBoxGroup.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0
                               orderby p.ItemBoxGroup
                    select p;
                
                filteredProducts.AddRange(query);
            }

            return filteredProducts.Distinct().ToList();
        }

        [Export("updateSearchResultsForSearchController:")]
        public virtual void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            var tableController = (ResultsTableControllerCat)searchController.SearchResultsController;
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
            BoxedItem selectedItem = (tableView == TableView) ? itemList[indexPath.Row] : resultsTableController.FilteredProducts[indexPath.Row];

            boxListController controller = this.Storyboard.InstantiateViewController("boxListStory") as boxListController;
            controller.SelectedBoxGroup = selectedItem.ItemBoxGroup;
            this.NavigationController.PushViewController(controller, true);

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            BoxedItem item = itemList[indexPath.Row];

            var theCell = TableView.DequeueReusableCell((NSString)"cat_cell_id", indexPath) as categoryCell;
            theCell.ItemData = item;
            return theCell;

        }
    }
}