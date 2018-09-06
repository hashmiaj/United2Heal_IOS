﻿using System;
using System.Collections.Generic;
using UIKit;
namespace United2Heal
{
    internal class itemPageViewModel : UIPickerViewModel
    {
        public List<string> BoxNames;

        public string SelectedBox { get; private set; }

        public event EventHandler BoxChanged;

        public itemPageViewModel(List<string> BoxNames)
        {
            this.BoxNames = BoxNames;
        }

        public override System.nint GetRowsInComponent(UIPickerView pickerView, System.nint component)
        {
            return BoxNames.Count;
        }

        public override System.nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public void SetFirstSelected(UIPickerView pickerView, System.nint row, System.nint component)
        {
            string Box = BoxNames[(int)row];
        }

        public override string GetTitle(UIPickerView pickerView, System.nint row, System.nint component)
        {
            return BoxNames[(int)row];
        }

        public override void Selected(UIPickerView pickerView, System.nint row, System.nint compononet)
        {
            string Box = BoxNames[(int)row];

            SelectedBox = Box;

            BoxChanged?.Invoke(null, null);
        }
    }
}