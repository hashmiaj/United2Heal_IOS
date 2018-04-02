using Foundation;
using System;
using UIKit;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace United2Heal
{
    public partial class categoryPage : UIViewController
    {
        public categoryPage (IntPtr handle) : base (handle)
        {
        }

        partial void SubmitBtn_TouchUpInside(UIButton sender)
        {
            var alert = UIAlertController.Create(
                "Alert", "Are you sure you want to close this Box? Once the box is closed it cannot be reopened.", UIAlertControllerStyle.Alert);


            alert.AddAction(UIAlertAction.Create("Submit", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
                MySqlConnection sqlconn;
                string connsqlstring = "Server=dbunited2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";
                sqlconn = new MySqlConnection();
                sqlconn.ConnectionString = connsqlstring;
                sqlconn.Open();
                char box = categoryBox.Text.Trim().ToCharArray()[0];
                box++;
                string strBox = "" + box;

                string query = "SET SQL_SAFE_UPDATES=0;UPDATE u2hdb.itemTable SET itemBox = " + "'" + strBox + "' " + "WHERE itemCategory= " + "'" + categoryName.Text + "'";

                MySqlCommand sqlcmd = new MySqlCommand(query, sqlconn);
                sqlcmd.ExecuteNonQuery();

                var finishedAlert = UIAlertController.Create(
                    "Done!", "You have just closed Box: " + categoryBox.Text + " in Category: " + categoryName.Text, UIAlertControllerStyle.Alert);

                categoryBox.Text = strBox;

                sqlconn.Close();
                finishedAlert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (UIAlertAction OBJ) =>
                {

                }));

                PresentViewController(finishedAlert, true, null);

            }));

            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {

            }));


            PresentViewController(alert, true, null);
            // ShowViewController(alert, null);
        }

        public categoryPage() : base("categoryPage", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            categoryBox.Text = categoryBoxText;
            categoryName.Text = categoryNameText;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public string categoryNameText
        {
            get;
            set;
        }

        public string categoryBoxText
        {
            get;
            set;
        }
    }
}