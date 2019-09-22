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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ItemNameField.AutocorrectionType = UITextAutocorrectionType.No;
            ItemNameField.KeyboardType = UIKeyboardType.Default;
            ItemNameField.ReturnKeyType = UIReturnKeyType.Done;
            ItemNameField.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false;

            ItemNameField.ShouldReturn = delegate
            {
                ItemNameField.ResignFirstResponder();
                return true;
            };


            View.AddGestureRecognizer(g);
            NavigationItem.Title = "Add new item";
        }
        

        partial void SubmitBtn_TouchUpInside(UIButton sender)
        {
            if(ItemNameField.Text.Trim() == string.Empty)
            {
                //Create Alert
                var OkayAlert = UIAlertController.Create("No name!", "You've submitted an item without a name. Please enter an item name and try again.", UIAlertControllerStyle.Alert);

                //Add Action
                OkayAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(OkayAlert, true, null);

                return;
            }

            MySqlConnection sqlconn;
            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";
            sqlconn = new MySqlConnection();
            sqlconn.ConnectionString = connsqlstring;
            sqlconn.Open();

            string QueryCheckName = "Select ItemName From u2hdb.ItemTable where ItemName = '" + ItemNameField.Text + "'";
            MySqlCommand CheckNamecmd = new MySqlCommand(QueryCheckName, sqlconn);
            Object CurrentName = CheckNamecmd.ExecuteScalar();
            string CheckName = "";
            if(CurrentName != null)
            {
                CheckName = CurrentName.ToString().Trim();
            }

            if (ItemNameField.Text.Trim().Equals(CheckName))
            {
                //Create Alert
                var OkayAlert = UIAlertController.Create("Duplicate name!", "You've submitted an item with a name that is already in the database! " +
                	"Please search for this item in the item list.", UIAlertControllerStyle.Alert);

                //Add Action
                OkayAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(OkayAlert, true, null);

                return;
            }


            string QueryMaxID = "SELECT MAX(ItemId) FROM u2hdb.ItemTable";
            MySqlCommand MaxIDCmd = new MySqlCommand(QueryMaxID, sqlconn);
            MaxIDCmd = new MySqlCommand(QueryMaxID, sqlconn);
            Object MaxID = MaxIDCmd.ExecuteScalar();
            string GetID = MaxID.ToString();

            int code = Int32.Parse(GetID) + 1;

            string query = "insert into u2hdb.ItemTable (ItemID, ItemName) " +
                "values(" + "'" + code + "', '" + ItemNameField.Text + "')";
            
            MySqlCommand sqlcmd = new MySqlCommand(query, sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

            //Create Alert
            var Finish = UIAlertController.Create("Done!", "You've just added this item to the Item List. " + 
                Environment.NewLine + ItemNameField.Text, UIAlertControllerStyle.Alert);

            //Add Action
            Finish.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (UIAlertAction OBJ) =>
            {
                this.NavigationController.PopToRootViewController(true);
            }));

            // Present Alert
            PresentViewController(Finish, true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}