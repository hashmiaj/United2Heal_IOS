using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace United2Heal
{
    public partial class boxStatsListPage : UITableViewController
    {
        public List<Item> itemList;

        public string SelectedCategory
        {
            get;
            set;
        }

        public string SelectedBox
        {
            get;
            set;
        }

        public boxStatsListPage (IntPtr handle) : base (handle)
        {
            itemList = new List<Item>();
        }

        public void LoadList()
        {
            itemList = new List<Item>();
            List<String> columnItemName = new List<String>();
            List<String> columnItemQuantity = new List<String>();

            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";


            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                String queryCategory = "select ItemName, ItemQuantity from u2hdb.ItemBox where CategoryName = " 
                    + "'" + SelectedCategory + "' AND BoxName = '" + SelectedBox + "'";
                using (MySqlCommand command = new MySqlCommand(queryCategory, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnItemName.Add(reader["ItemName"].ToString());
                            columnItemQuantity.Add(reader["ItemQuantity"].ToString());
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            for (int i = 0; i < columnItemName.Count; i++)
            {
                itemList.Add(new Item()
                {
                    itemName = columnItemName[i],
                    itemCode = columnItemQuantity[i]
                });
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if(SelectedCategory != null && SelectedBox != null)
            {
                LoadList();
            }

            //boxStatsTableView.Source = new BoxStatsTVS(itemList);
            boxStatsTableView.RowHeight = UITableView.AutomaticDimension;
            boxStatsTableView.EstimatedRowHeight = 40f;
            boxStatsTableView.ReloadData();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return itemList.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Item item = itemList[indexPath.Row];

            var theCell = TableView.DequeueReusableCell((NSString)"stats_cell_id", indexPath) as itemStatCell;
            theCell.ItemData = item;
            return theCell;

        }
    }
}