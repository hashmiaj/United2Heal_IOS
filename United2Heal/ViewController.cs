using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using MySql.Data.MySqlClient;
using UIKit;
using United2Heal.Models;
using ZXing;
using ZXing.Mobile;

namespace United2Heal
{
    public partial class ViewController : UIViewController
    {

        private GroupPickerViewModel GroupViewModel;
        private List<string> GroupNameList = new List<string>();
        private string GroupName = "";

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.


        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            PasswordField.AutocorrectionType = UITextAutocorrectionType.No;
            PasswordField.KeyboardType = UIKeyboardType.Default;
            PasswordField.ReturnKeyType = UIReturnKeyType.Done;
            PasswordField.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            PasswordField.ShouldReturn = delegate
            {
                PasswordField.ResignFirstResponder();
                return true;
            };

            SelectGroupLabel.Hidden = true;
            PasswordLabel.Hidden = true;
            PasswordField.Hidden = true;
            SubmitButton.Hidden = true;
            GroupPicker.Hidden = true;
            GoBackButton.Hidden = true;


            FadeAnimation(SelectGroupLabel, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(PasswordLabel, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(PasswordField, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(SubmitButton, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(GroupPicker, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(GoBackButton, isIn: false, duration: 1, onFinished: null);
        }


        partial void VCUButton_TouchUpInside(UIButton sender)
        {
            GlobalVariables.SchoolName = "VCU";

            FadeAnimation(VCUButton, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(GMUButton, isIn: false, duration: 1, onFinished: null);

            GetPickerData();

            FadeAnimation(SelectGroupLabel, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(PasswordLabel, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(PasswordField, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(SubmitButton, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(GroupPicker, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(GoBackButton, isIn: true, duration: 1, onFinished: null);

            SelectGroupLabel.Hidden = false;
            PasswordLabel.Hidden = false;
            PasswordField.Hidden = false;
            SubmitButton.Hidden = false;
            GroupPicker.Hidden = false;
            GoBackButton.Hidden = false;

            ChooseLabel.Text = "Enter Password and Select Group";

        }
        partial void GMUButton_TouchUpInside(UIButton sender)
        {
            GlobalVariables.SchoolName = "GMU";

            FadeAnimation(VCUButton, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(GMUButton, isIn: false, duration: 1, onFinished: null);

            GetPickerData();

            FadeAnimation(SelectGroupLabel, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(PasswordLabel, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(PasswordField, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(SubmitButton, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(GroupPicker, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(GoBackButton, isIn: true, duration: 1, onFinished: null);

            SelectGroupLabel.Hidden = false;
            PasswordLabel.Hidden = false;
            PasswordField.Hidden = false;
            SubmitButton.Hidden = false;
            GroupPicker.Hidden = false;
            GoBackButton.Hidden = false;

            ChooseLabel.Text = "Enter Password and Select Group";

        }

        public async void GetPickerData()
        {
            GroupNameList.Clear();

            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";

            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                string queryBoxName = "select distinct GroupName from u2hdb.BoxTable where isOpen = '1' && School = '" + GlobalVariables.SchoolName + "'Order by GroupName";

                using (MySqlCommand command = new MySqlCommand(queryBoxName, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GroupNameList.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            GroupViewModel = new GroupPickerViewModel(GroupNameList);
            GroupPicker.Model = GroupViewModel;

        }
        partial void SubmitButton_TouchUpInside(UIButton sender)
        {
            GlobalVariables.GroupName = GroupViewModel.SelectedGroup;

            if(GroupViewModel.SelectedGroup == null)
            {
                GlobalVariables.GroupName = GroupNameList[0];
            }

            string connsqlstring = "Server=united2heal.cxsnwexuvrto.us-east-1.rds.amazonaws.com;Port=3306;database=u2hdb;User Id=united2heal;Password=ilovevcu123;charset=utf8";
            string Password = "";


            using (MySqlConnection connection = new MySqlConnection(connsqlstring))
            {
                connection.Open();
                string QueryPassword = "SELECT Password FROM u2hdb.PasswordTable where School = '" + GlobalVariables.SchoolName + "'";

                using (MySqlCommand command = new MySqlCommand(QueryPassword, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Password = reader.GetString(0);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            if(PasswordField.Text.Trim() == string.Empty)
            {
                //Create Alert
                var OkayAlert = UIAlertController.Create("Wrong Password!", "You've entered the incorrect password, please try again.", UIAlertControllerStyle.Alert);

                //Add Action
                OkayAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(OkayAlert, true, null);
            }

            if(string.Equals(PasswordField.Text.Trim(), Password))
            {
                FadeAnimation(LaunchView, isIn: false, duration: 1, onFinished: null);
            }
            else
            {
                //Create Alert
                var OkayAlert = UIAlertController.Create("Wrong Password!", "You've entered the incorrect password, please try again.", UIAlertControllerStyle.Alert);

                //Add Action
                OkayAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(OkayAlert, true, null);
            }
            GroupLabel.Text = "Group: " + GlobalVariables.GroupName;
            SchoolLabel.Text = GlobalVariables.SchoolName;
        }

        partial void GoBackButton_TouchUpInside(UIButton sender)
        {
            SelectGroupLabel.Hidden = true;
            PasswordLabel.Hidden = true;
            PasswordField.Hidden = true;
            SubmitButton.Hidden = true;
            GroupPicker.Hidden = true;
            GoBackButton.Hidden = true;

            FadeAnimation(SelectGroupLabel, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(PasswordLabel, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(PasswordField, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(SubmitButton, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(GroupPicker, isIn: false, duration: 1, onFinished: null);
            FadeAnimation(GoBackButton, isIn: false, duration: 1, onFinished: null);

            FadeAnimation(VCUButton, isIn: true, duration: 1, onFinished: null);
            FadeAnimation(GMUButton, isIn: true, duration: 1, onFinished: null);

            ChooseLabel.Text = "Choose School";
        }

        partial void AddNewItemBtn_TouchUpInside(UIButton sender)
        {
            //United2Heal.addItem page = new United2Heal.addItem();
            //this.NavigationController.PushViewController(page, true);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            //var itemsViewController = segue.DestinationViewController as ItemController;
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

        //Sets camera resolution. Not sure what it really does lol 
        CameraResolution HandleCameraResolutionSelectorDelegate(List<CameraResolution> availableResolutions)
        {
            //Don't know if this will ever be null or empty
            if (availableResolutions == null || availableResolutions.Count < 1)
                return new CameraResolution() { Width = 800, Height = 600 };

            //Debugging revealed that the last element in the list
            //expresses the highest resolution. This could probably be more thorough.
            return availableResolutions[availableResolutions.Count - 1];
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
