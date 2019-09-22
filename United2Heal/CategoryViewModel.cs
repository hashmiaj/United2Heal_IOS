using System;
using System.Collections.Generic;
using UIKit;
namespace United2Heal
{
    internal class CategoryViewModel : UIPickerViewModel
    {
        private List<string> columnCategory;

        public string SelectedCategory { get; private set; }

        public event EventHandler CategoryChanged;

        public CategoryViewModel(List<string> columnCategory)
        {
            this.columnCategory = columnCategory;
        }

        public override System.nint GetRowsInComponent(UIPickerView pickerView, System.nint component)
        {
            return columnCategory.Count;
        }

        public override System.nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override string GetTitle(UIPickerView pickerView, System.nint row, System.nint component)
        {
            return columnCategory[(int)row];
        }

        public override void Selected(UIPickerView pickerView, System.nint row, System.nint compononet)
        {
            string category = columnCategory[(int)row];

            SelectedCategory = category;

            CategoryChanged?.Invoke(null, null);
        }

    }
}