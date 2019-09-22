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
    public partial class boxListController : UITableViewController
    {

        readonly List<BoxedItem> itemList;
        UISearchController searchController;
        ResultsTableControllerBox resultsTableController;
        bool searchControllerWasActive;
        bool searchControllerSearchFieldWasFirstResponder;

        public string SelectedBoxGroup
        {
            get;
            set;
        }

        public boxListController (IntPtr handle) : base (handle)
        {
            itemList = new List<BoxedItem>();
        }

        public void loadList()
        {
            List<String> columnBox = new List<String>();

            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";


            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                String queryCategory = "select distinct BoxNumber from u2hdb.ItemBox where GroupName = "
                    + "'" + SelectedBoxGroup + "' && School = '" + GlobalVariables.SchoolName + "' ORDER BY BoxNumber + 0 ASC";
                using (MySqlCommand command = new MySqlCommand(queryCategory, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnBox.Add(reader["BoxNumber"].ToString()); ;
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            for (int i = 0; i < columnBox.Count; i++)
            {
                itemList.Add(new BoxedItem()
                {
                    ItemName = "",
                    ItemID = "1",
                    ItemBoxNumber = columnBox[i]
                });
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if(SelectedBoxGroup != null)
            {
                loadList();
            }

            resultsTableController = new ResultsTableControllerBox
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
                        where p.ItemBoxNumber.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0
                               orderby p.ItemBoxNumber
                    select p;

                filteredProducts.AddRange(query);
            }

            return filteredProducts.Distinct().ToList();
        }

        [Export("updateSearchResultsForSearchController:")]
        public virtual void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            var tableController = (ResultsTableControllerBox)searchController.SearchResultsController;
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

            boxStatsListPage controller = this.Storyboard.InstantiateViewController("statsStory") as boxStatsListPage;
            controller.SelectedBoxGroup = this.SelectedBoxGroup;
            controller.SelectedBoxNumber = selectedItem.ItemBoxNumber;
            this.NavigationController.PushViewController(controller, true);

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            BoxedItem item = itemList[indexPath.Row];

            var theCell = TableView.DequeueReusableCell((NSString)"box_cell_id", indexPath) as boxCell;
            theCell.ItemData = item;
            return theCell;

        }
    }
}