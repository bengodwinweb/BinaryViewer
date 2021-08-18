using System.Linq;
using System.Windows.Controls;

namespace BinaryViewer.Wpf
{
    public class RadioMenuItem : MenuItem
    {
        public string GroupName { get; set; }

        protected override void OnClick()
        {
            // Ignore clicks if this item is already checked
            if (IsChecked)
            {
                return;
            }

            // Find the currently selected item and deselect it
            var itemsControl = Parent as ItemsControl;
            if (itemsControl != null)
            {
                var currentlySelected = itemsControl.Items.OfType<RadioMenuItem>().FirstOrDefault(x => x.GroupName == GroupName && x.IsChecked);
                if (currentlySelected != null)
                {
                    currentlySelected.IsChecked = false;
                }
            }

            // Set this item's selected value to true
            IsChecked = true;

            base.OnClick();
        }

        /// <summary>
        /// Hide IsCheckable, always true for this control
        /// </summary>
        private new bool IsCheckable { get; }
    }
}
