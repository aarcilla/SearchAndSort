using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchAndSort
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            searchRadioButton.IsChecked = true;
        }

        private void searchRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            foreach (UIElement control in searchAlgorithmsPanel.Children)
            {
                if (control is Button)
                {
                    ((Button)control).IsEnabled = true;
                }
            }

            foreach (UIElement control in sortAlgorithmsPanel.Children)
            {
                if (control is Button)
                {
                    ((Button)control).IsEnabled = false;
                }
            }

            foreach (UIElement control in searchOnlyInput.Children)
            {
                control.IsEnabled = true;
            }
        }

        private void sortRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            foreach (UIElement control in searchAlgorithmsPanel.Children)
            {
                if (control is Button)
                {
                    ((Button)control).IsEnabled = false;
                }
            }

            foreach (UIElement control in sortAlgorithmsPanel.Children)
            {
                if (control is Button)
                {
                    ((Button)control).IsEnabled = true;
                }
            }

            foreach (UIElement control in searchOnlyInput.Children)
            {
                control.IsEnabled = false;
            }
        }

        private void linearButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputBox.Text)
                || string.IsNullOrWhiteSpace(desiredNumBox.Text))
                return;

            int[] nums = ParseSpaceDelimitedIntegers(inputBox.Text);

            int desiredNum;
            bool tryParseDesiredNum = Int32.TryParse(desiredNumBox.Text, out desiredNum);

            if (tryParseDesiredNum)
            {
                Search search = new Search();
                int? result = search.Linear(nums, desiredNum);

                if (result.HasValue)
                {
                    outputLabel.Content = string.Format("Found {0} at index {1}", desiredNum, result.Value);
                }
                else
                {
                    outputLabel.Content = "Desired number not found.";
                }
            }
            else
            {
                outputLabel.Content = "Specified desired number is not an integer.";
            }
        }

        private void binaryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #region Helper methods

        private int[] ParseSpaceDelimitedIntegers(string numsString)
        {
            List<int> nums = new List<int>();

            var addToNumsList = new Action<string>((numAsString) =>
            {
                int num;
                bool tryParseNum = Int32.TryParse(numAsString, out num);

                if (tryParseNum)
                    nums.Add(num);
            });

            string currentNumAsString = string.Empty;
            int currentIndex = 0;
            while(currentIndex < numsString.Length) 
            {
                if (numsString.Substring(currentIndex, 1) == " ")
                {
                    addToNumsList(currentNumAsString);

                    currentNumAsString = string.Empty;

                }
                else
                {
                    currentNumAsString += numsString.Substring(currentIndex, 1);
                }

                currentIndex++;
            }

            // Add last number in space-delimited string
            if (!string.IsNullOrWhiteSpace(currentNumAsString))
            {
                addToNumsList(currentNumAsString);
            }

            return nums.ToArray();
        }

        #endregion
    }
}
