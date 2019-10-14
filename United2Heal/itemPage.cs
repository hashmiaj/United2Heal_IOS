using Foundation;
using System;
using UIKit;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Collections.Generic;
using United2Heal.Models;
using CoreGraphics;

namespace United2Heal
{
    public partial class itemPage : UIViewController
    {

        private itemPageViewModel BoxViewModel;
        private List<string> BoxNumberList = new List<string>();
        private List<string> BoxIDList = new List<string>();
        private string boxID = "";


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

        public string ItemNameText
        {
            get;
            set;
        }

        public string itemQuantityText
        {
            get;
            set;
        }

        public itemPage(IntPtr handle) : base(handle)
        {
        }

        public itemPage() : base("itemPage", null)
        {
        }

        partial void Submit_TouchUpInside(UIButton sender)
        {
            string BoxNumber = BoxViewModel.SelectedBox;
            if(BoxNumber == null)
            {
                BoxNumber = BoxNumberList[0];
            }

            string QuantityFieldText = itemQuantField.Text;
            if (string.IsNullOrEmpty(QuantityFieldText))
            {
                QuantityFieldText = "1";
            }


            var formatter = new NSDateFormatter();
            formatter.DateStyle = NSDateFormatterStyle.Short;
            string ExpirationDate = formatter.ToString(ExpirationPicker.Date);

            if(!ExpirationSwitch.On)
            {
                ExpirationDate = "None";
            }

            var alert = UIAlertController.Create(
                "Ready to Submit?", "Are you sure you would like to add the item to this box?" + Environment.NewLine + Environment.NewLine +
                "Item Name" + Environment.NewLine + "'" + ItemName.Text + "'" + Environment.NewLine + Environment.NewLine +
                "Item Code" + Environment.NewLine + "'" + itemCode.Text + "'" + Environment.NewLine + Environment.NewLine +
                "Item Quantity" + Environment.NewLine + "'" + QuantityFieldText + "'" + Environment.NewLine + Environment.NewLine +
                "Item Expiration Date" + Environment.NewLine + "'" + ExpirationDate + "'" + Environment.NewLine + Environment.NewLine +
                "Item Box" + Environment.NewLine + "'" + BoxNumber + "'", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {

            }));


            alert.AddAction(UIAlertAction.Create("Submit", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
                MySqlConnection sqlconn;
                string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";
                sqlconn = new MySqlConnection();
                sqlconn.ConnectionString = connsqlstring;
                sqlconn.Open();

                MySqlCommand sqlcmd;
                //string queryName = "select ItemBoxID, GroupName, BoxNumber, School, ExpirationDate from u2hdb.ItemBox where ItemName = " + "'" + ItemName.Text + "'";
                string queryName = "select ItemBoxID, GroupName, BoxNumber, School, ExpirationDate from u2hdb.ItemBox " +
                    "where ItemName = '" + ItemName.Text + "' AND GroupName = '" + GlobalVariables.GroupName + "'" +
                    " AND BoxNumber = '" + BoxNumber + "' AND ExpirationDate = '" + ExpirationDate + "' AND " +
                    "School = '" + GlobalVariables.SchoolName + "'";
                sqlcmd = new MySqlCommand(queryName, sqlconn);

                string result = "";
                string groupname = "";
                string boxnumber = "";
                string school = "";
                string expdate = "";

                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = reader.GetString(0);
                        groupname = reader.GetString(1);
                        boxnumber = reader.GetString(2);
                        school = reader.GetString(3);
                        expdate = reader.GetString(4);
                    }
                }

                if (result == null)
                {
                    string QueryMaxID = "SELECT Max(ItemBoxID + 0) from u2hdb.ItemBox";
                    sqlcmd = new MySqlCommand(QueryMaxID, sqlconn);
                    Object MaxID = sqlcmd.ExecuteScalar();
                    string GetID = MaxID.ToString();

                    int code = Int32.Parse(GetID) + 1;

                    int quantity = 0;

                    if(itemQuantField.Text.Length == 0)
                    {
                        quantity = 1;
                    }
                    else
                    {
                        string quant = itemQuantField.Text;
                        quant.Trim();
                        quantity = Int32.Parse(quant);
                    }

                    string insertQuery = "insert into u2hdb.ItemBox (ItemBoxID, ItemID, GroupName, BoxNumber, ItemName, ItemQuantity, ExpirationDate, School) values " +
                        "( '" + code.ToString() + "', '" + itemCode.Text + "', '" + GlobalVariables.GroupName + "', '" + BoxNumber + 
                        "', '" + ItemName.Text + "', '" + quantity + "', '" + ExpirationDate + "', '" + GlobalVariables.SchoolName + "')";
                    
                    sqlcmd = new MySqlCommand(insertQuery, sqlconn);

                    sqlcmd.ExecuteNonQuery();

                    sqlconn.Close();
                }
                else if (school != GlobalVariables.SchoolName || groupname != GlobalVariables.GroupName || boxnumber != BoxNumber || expdate != ExpirationDate)
                {
                    string QueryMaxID = "SELECT Max(ItemBoxID + 0) from u2hdb.ItemBox";
                    sqlcmd = new MySqlCommand(QueryMaxID, sqlconn);
                    Object MaxID = sqlcmd.ExecuteScalar();
                    string GetID = MaxID.ToString();

                    int code = Int32.Parse(GetID) + 1;

                    int quantity = 0;

                    if (itemQuantField.Text.Length == 0)
                    {
                        quantity = 1;
                    }
                    else
                    {
                        string quant = itemQuantField.Text;
                        quant.Trim();
                        quantity = Int32.Parse(quant);
                    }

                    string insertQuery = "insert into u2hdb.ItemBox (ItemBoxID, ItemID, GroupName, BoxNumber, ItemName, ItemQuantity, ExpirationDate, School) values " +
                        "( '" + code.ToString() + "', '" + itemCode.Text + "', '" + GlobalVariables.GroupName + "', '" + BoxNumber +
                        "', '" + ItemName.Text + "', '" + quantity + "', '" + ExpirationDate + "', '" + GlobalVariables.SchoolName + "')";

                    sqlcmd = new MySqlCommand(insertQuery, sqlconn);

                    sqlcmd.ExecuteNonQuery();

                    sqlconn.Close();
                }

                else if (school == GlobalVariables.SchoolName && groupname == GlobalVariables.GroupName && boxnumber == BoxNumber && expdate == ExpirationDate)
                {
                    string queryQuantity = "select ItemQuantity from u2hdb.ItemBox where ItemBoxID = " + "'" + result + "'";

                    sqlcmd = new MySqlCommand(queryQuantity, sqlconn);
                    string quantity = sqlcmd.ExecuteScalar().ToString();

                    string text = itemQuantField.Text;

                    if (text.Length == 0)
                    {
                        text = "1";
                    }

                    int quant = Int32.Parse(quantity);
                    text.Trim();

                    int current = Int32.Parse(text);

                    quant = quant + current;

                    string updateQuery = "update u2hdb.ItemBox set ItemQuantity = " + "'" + quant.ToString() + "'" + 
                        " where ItemBoxID = " + "'" + result + "'";

                    sqlcmd = new MySqlCommand(updateQuery, sqlconn);
                    sqlcmd.ExecuteNonQuery();
                }

                var finishedAlert = UIAlertController.Create(
                "Done!", "You've just added the following item to a box" + Environment.NewLine + Environment.NewLine +
                "Item Name" + Environment.NewLine + "'" + ItemName.Text + "'" + Environment.NewLine + Environment.NewLine +
                "Item Code" + Environment.NewLine + "'" + itemCode.Text + "'" + Environment.NewLine + Environment.NewLine +
                "Item Quantity" + Environment.NewLine + "'" + QuantityFieldText + "'" + Environment.NewLine + Environment.NewLine +
                "Item Expiration Date" + Environment.NewLine + "'" + ExpirationDate + "'" + Environment.NewLine + Environment.NewLine +
                "Item Box" + Environment.NewLine + "'" + BoxNumber + "'", UIAlertControllerStyle.Alert);

                sqlconn.Close();
                finishedAlert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (UIAlertAction OBJ) =>
                {
                    this.NavigationController.PopToRootViewController(true);

                }));

                PresentViewController(finishedAlert, true, null);



            }));


            PresentViewController(alert, true, null);
            // ShowViewController(alert, null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ExpirationPicker.Hidden = true;

            //itemQuantField.AutocorrectionType = UITextAutocorrectionType.No;
            //itemQuantField.KeyboardType = UIKeyboardType.Default;
            //itemQuantField.ReturnKeyType = UIReturnKeyType.Done;
            //itemQuantField.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            itemQuantField.ShouldReturn = delegate
            {
                itemQuantField.ResignFirstResponder();
                return true;
            };

            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5

            View.AddGestureRecognizer(g);

            NavigationItem.Title = "United 2 Heal";
            itemCode.Text = itemCodeText;
            ItemName.Text = ItemNameText;
            //itemBox.Text = itemBoxText;
            //And here is where we set the addLable text
            //addLabel.Text = addLabelText;


            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";

            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                string queryBoxName = "select BoxNumber from u2hdb.BoxTable where isOpen = 1 && GroupName = '" + GlobalVariables.GroupName + "'" +
                	" && School = '" + GlobalVariables.SchoolName + "' Order by BoxNumber + 0 ASC";

                using (MySqlCommand command = new MySqlCommand(queryBoxName, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BoxNumberList.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            BoxViewModel = new itemPageViewModel(BoxNumberList);
            BoxPicker.Model = BoxViewModel;
        }

        partial void ExpirationSwitchValueChanged(UISwitch sender)
        {
            bool value = ExpirationSwitch.On;

            if(value)
            {
                ExpirationLabel.Hidden = true;
                ExpirationPicker.Hidden = false;
            }
            else
            {
                ExpirationLabel.Hidden = false;
                ExpirationPicker.Hidden = true;
            }
        }

        public static void FadeAnimation(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = CGAffineTransform.MakeIdentity();
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut, () => {
                view.Alpha = isIn ? maxAlpha : minAlpha;
            }, onFinished);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}