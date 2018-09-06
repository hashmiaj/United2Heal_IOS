using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
namespace United2Heal
{
    public partial class boxListController : UITableViewController
    {

        readonly List<Item> itemList;
        UISearchController searchController;
        ResultsTableControllerBox resultsTableController;
        bool searchControllerWasActive;
        bool searchControllerSearchFieldWasFirstResponder;

        public string SelectedCategory
        {
            get;
            set;
        }

        public boxListController (IntPtr handle) : base (handle)
        {
            itemList = new List<Item>();
        }

        public void loadList()
        {
            List<String> columnBox = new List<String>();

            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";


            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                String queryCategory = "select distinct BoxName from u2hdb.ItemBox where CategoryName = "
                    + "'" + SelectedCategory + "'";
                using (MySqlCommand command = new MySqlCommand(queryCategory, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnBox.Add(reader["BoxName"].ToString()); ;
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            for (int i = 0; i < columnBox.Count; i++)
            {
                itemList.Add(new Item()
                {
                    itemName = "",
                    itemCode = "1",
                    itemBox = columnBox[i]
                });
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if(SelectedCategory != null)
            {
                loadList();
            }

            resultsTableController = new ResultsTableControllerBox
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
                        where p.itemBox.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0
                               orderby p.itemBox
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
            Item selectedItem = (tableView == TableView) ? itemList[indexPath.Row] : resultsTableController.FilteredProducts[indexPath.Row];

            boxStatsListPage controller = this.Storyboard.InstantiateViewController("statsStory") as boxStatsListPage;
            controller.SelectedCategory = this.SelectedCategory;
            controller.SelectedBox = selectedItem.itemBox;
            this.NavigationController.PushViewController(controller, true);

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Item item = itemList[indexPath.Row];

            var theCell = TableView.DequeueReusableCell((NSString)"box_cell_id", indexPath) as boxCell;
            theCell.ItemData = item;
            return theCell;

        }
    }
}