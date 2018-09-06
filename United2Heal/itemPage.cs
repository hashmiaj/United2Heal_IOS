using Foundation;
using System;
using UIKit;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Collections.Generic;

namespace United2Heal
{
    public partial class itemPage : UIViewController
    {

        private itemPageViewModel BoxViewModel;
        private List<string> BoxNameList = new List<string>();
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

        public itemPage(IntPtr handle) : base(handle)
        {
        }

        public itemPage() : base("itemPage", null)
        {
        }

        partial void Submit_TouchUpInside(UIButton sender)
        {
            var alert = UIAlertController.Create(
                "Alert", "Are you sure you would like to add to this box?", UIAlertControllerStyle.Alert);


            alert.AddAction(UIAlertAction.Create("Submit", UIAlertActionStyle.Default, (UIAlertAction obj) =>
            {
                var pickerViewModel = new itemPageViewModel(BoxNameList);


                MySqlConnection sqlconn;
                string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";
                sqlconn = new MySqlConnection();
                sqlconn.ConnectionString = connsqlstring;
                sqlconn.Open();

                MySqlCommand sqlcmd;
                string queryName = "select ItemBoxID from u2hdb.ItemBox where ItemName = " + "'" + itemName.Text + "'";
                sqlcmd = new MySqlCommand(queryName, sqlconn);
                Object result = sqlcmd.ExecuteScalar();

                if (result == null)
                {
                    Random rdm = new Random();
                    int code = rdm.Next(50000, 60000);

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

                    string boxName = "";

                    if (BoxViewModel.SelectedBox == null)
                    {
                        boxName = BoxViewModel.BoxNames[0];
                    }
                    else
                    {
                        boxName = BoxViewModel.SelectedBox;
                    }
                    string insertQuery = "insert into u2hdb.ItemBox (ItemBoxID, BoxID, ItemID, ItemQuantity, BoxName, ItemName) values " +
                        "( '" + code.ToString() + "', '" + boxID + "', '" + itemCode.Text + "', '" + quantity + "', '" + boxName + "', '" + itemName.Text + "')";
                    
                    sqlcmd = new MySqlCommand(insertQuery, sqlconn);

                    sqlcmd.ExecuteNonQuery();

                    sqlconn.Close();
                }
                else
                {
                    string queryQuantity = "select ItemQuantity from u2hdb.ItemBox where ItemBoxID = " + "'" + result + "'";

                    sqlcmd = new MySqlCommand(queryQuantity, sqlconn);
                    string quantity = sqlcmd.ExecuteScalar().ToString();

                    if(quantity.Length == 0)
                    {
                        quantity = "1";
                    }

                    int quant = Int32.Parse(quantity);
                    string text = itemQuantField.Text;
                    text.Trim();

                    int current = Int32.Parse(text);

                    quant = quant + current;



                    string updateQuery = "update u2hdb.ItemBox set ItemQuantity = " + "'" + quant.ToString() + "'" + 
                        " where ItemBoxID = " + "'" + result + "'";

                    sqlcmd = new MySqlCommand(updateQuery, sqlconn);
                    sqlcmd.ExecuteNonQuery();
                }


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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            itemQuantField.AutocorrectionType = UITextAutocorrectionType.No;
            itemQuantField.KeyboardType = UIKeyboardType.Default;
            itemQuantField.ReturnKeyType = UIReturnKeyType.Done;
            itemQuantField.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5

            View.AddGestureRecognizer(g);

            itemQuantField.Text = "1";
            itemQuantField = new UITextField { KeyboardType = UIKeyboardType.NumberPad };
            NavigationItem.Title = "United 2 Heal";
            //Here is where we set the actual barcodeLable text
            itemCode.Text = itemCodeText;
            itemName.Text = itemNameText;
            itemCategory.Text = itemCategoryText;
            //itemBox.Text = itemBoxText;
            //And here is where we set the addLable text
            //addLabel.Text = addLabelText;


            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";

            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                string queryBoxName = "select BoxName from u2hdb.BoxTable where isOpen = 1 && CategoryName = '" + itemCategory.Text + "'";

                using (MySqlCommand command = new MySqlCommand(queryBoxName, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BoxNameList.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                string queryBoxID = "select BoxID from u2hdb.BoxTable where isOpen = 1 && CategoryName = " + "'" + itemCategory.Text + "'";

                using (MySqlCommand command = new MySqlCommand(queryBoxID, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BoxIDList.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }


            BoxViewModel = new itemPageViewModel(BoxNameList);

            BoxViewModel.BoxChanged += (sender, e) =>
            {
                string box = BoxViewModel.SelectedBox;
                int index = 0;

                for (int i = 0; i < BoxNameList.Count; i++)
                {
                    if(box.Equals(BoxNameList[i]))
                    {
                        index = i;
                    }
                }

                boxID = BoxIDList[index];

            };

            BoxPicker.Model = BoxViewModel;


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}