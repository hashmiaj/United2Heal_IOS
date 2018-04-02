using Foundation;
using System;
using UIKit;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace United2Heal
{
    public partial class itemController : UIViewController
    {

        partial void SubmitBtn_TouchUpInside(UIButton sender)
        {
            var alert = UIAlertController.Create(
                "Alert", "Are you sure you would like to add to this box?", UIAlertControllerStyle.Alert);


            alert.AddAction(UIAlertAction.Create("Submit", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
                MySqlConnection sqlconn;
                string connsqlstring = "Server=dbunited2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";
                sqlconn = new MySqlConnection();
                sqlconn.ConnectionString = connsqlstring;
                sqlconn.Open();




                var finishedAlert = UIAlertController.Create(
                    "Done!", "You have just inserted the item " + itemName.Text + " to box " + itemBoxText, UIAlertControllerStyle.Alert);


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

        /*
         * These strings are created so that they can be accessed 
         * by the ViewController. In the ViewController.cs there
         * are comments on where they are being accessed and 
         * changed. So if you add anything to the itemController.xib
         * and you need to access it from the ViewController then just 
         * add a string and set it below in the ViewDidLoad().
        */


        public string switchText
        {
            get;
            set;
        }

        public string itemCodeText
        {
            get;
            set;
        }

        public string itemCategoryText
        {
            get;
            set;
        }

        public string itemBoxText
        {
            get;
            set;
        }

        public string addLabelText
        {
            get;
            set;
        }

        public string itemNameText
        {
            get;
            set;
        }

        public string itemQuantityText
        {
            get;
            set;
        }

        //Here is how the label changes when the switch is toggled

        public itemController() : base("ItemController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            itemQuantField = new UITextField { KeyboardType = UIKeyboardType.NumberPad };
            NavigationItem.Title = "United 2 Heal";
            //Here is where we set the actual barcodeLable text
            itemCode.Text = itemCodeText;
            itemName.Text = itemNameText;
            itemCategory.Text = itemCategoryText;
            itemBox.Text = itemBoxText;
            //And here is where we set the addLable text
            //addLabel.Text = addLabelText;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}