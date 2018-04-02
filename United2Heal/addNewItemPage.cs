using System;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql;
using System.Collections.Generic;
using UIKit;

namespace United2Heal
{
    public partial class addNewItemPage : UIViewController
    {
        public addNewItemPage (IntPtr handle) : base (handle)
        {
        }


        List<String> columnCategory = new List<String>();

        public override void ViewDidLoad()
        {


            base.ViewDidLoad();


            //itemCodeField = new UITextField { KeyboardType = UIKeyboardType.NumberPad };
            NavigationItem.Title = "Add new item";

            string connsqlstring = "Server=dbunited2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";

            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                string queryCategory = "select distinct itemCategory from u2hdb.itemTable";

                using (MySqlCommand command = new MySqlCommand(queryCategory, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnCategory.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }


            var categoryViewModel = new CategoryViewModel(columnCategory);


            categoryViewModel.CategoryChanged += (sender, e) =>
            {
                MySqlConnection sqlconn;
                sqlconn = new MySqlConnection();
                sqlconn.ConnectionString = connsqlstring;
                sqlconn.Open();
                string queryBox = "select itemBox from u2hdb.itemTable where itemCategory = " + "'" + categoryViewModel.SelectedCategory + "'";
                MySqlCommand sqlcmd = new MySqlCommand(queryBox, sqlconn);
                String result = sqlcmd.ExecuteScalar().ToString();
                sqlconn.Close();

                itemBox.Text = result;
            };

            categoryPicker.Model = categoryViewModel;


        }

        partial void GenerateBtn_TouchUpInside(UIButton sender)
        {
            Random rdm = new Random();
            int code = rdm.Next(10000, 15000);

            UITextField objTextBox = (UITextField)itemCodeField;
            string theText = objTextBox.Text;
            itemCodeField.Text = code.ToString();


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}