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
        string category = "";

        public override void ViewDidLoad()
        {


            base.ViewDidLoad();

            itemNameField.AutocorrectionType = UITextAutocorrectionType.No;
            itemNameField.KeyboardType = UIKeyboardType.Default;
            itemNameField.ReturnKeyType = UIReturnKeyType.Done;
            itemNameField.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            itemCodeField.AutocorrectionType = UITextAutocorrectionType.No;
            itemCodeField.KeyboardType = UIKeyboardType.Default;
            itemCodeField.ReturnKeyType = UIReturnKeyType.Done;
            itemCodeField.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; 


            View.AddGestureRecognizer(g);
            //itemCodeField = new UITextField { KeyboardType = UIKeyboardType.NumberPad };
            NavigationItem.Title = "Add new item";

            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";

            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                string queryCategory = "select distinct CategoryName from u2hdb.ItemTable";

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
                category = categoryViewModel.SelectedCategory;
            };

            categoryPicker.Model = categoryViewModel;

        }
        

        partial void SubmitBtn_TouchUpInside(UIButton sender)
        {
            var categoryViewModel = new CategoryViewModel(columnCategory);

            MySqlConnection sqlconn;
            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";
            sqlconn = new MySqlConnection();
            sqlconn.ConnectionString = connsqlstring;
            sqlconn.Open();
            string query = "insert into u2hdb.ItemTable (ItemID, ItemName, CategoryName) " +
                "values(" + "'" + itemCodeField.Text + "', '" + itemNameField.Text + "', '" + 
                                 category + "')";
            
            MySqlCommand sqlcmd = new MySqlCommand(query, sqlconn);
            sqlcmd.ExecuteNonQuery();


            sqlconn.Close();

            //itemPage controller = this.Storyboard.InstantiateViewController("itemStory") as itemPage;
            this.NavigationController.PopToRootViewController(true);
            //this.NavigationController.PushViewController(controller, true);
            //controller.itemNameText = itemNameField.Text;
            //controller.itemCodeText = itemCodeField.Text;
            //controller.itemCategoryText = category;

        }

        partial void GenerateBtn_TouchUpInside(UIButton sender)
        {
            Random rdm = new Random();
            int code = rdm.Next(10000, 35000);

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