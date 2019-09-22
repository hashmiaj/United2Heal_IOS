using System;
using System.Collections.Generic;
using UIKit;

namespace United2Heal
{
    internal class GroupPickerViewModel : UIPickerViewModel
    {
        public List<string> GroupNames;

        public string SelectedGroup { get; private set; }

        public event EventHandler GroupChanged;

        public GroupPickerViewModel(List<string> BoxNumbers)
        {
            this.GroupNames = BoxNumbers;
        }

        public override System.nint GetRowsInComponent(UIPickerView pickerView, System.nint component)
        {
            return GroupNames.Count;
        }

        public override System.nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public void SetFirstSelected(UIPickerView pickerView, System.nint row, System.nint component)
        {
            string Group = GroupNames[(int)row];
        }

        public override string GetTitle(UIPickerView pickerView, System.nint row, System.nint component)
        {
            return GroupNames[(int)row];
        }

        public override void Selected(UIPickerView pickerView, System.nint row, System.nint compononet)
        {
            string Box = GroupNames[(int)row];

            SelectedGroup = Box;

            GroupChanged?.Invoke(null, null);
        }
    }
}
