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
        private InputHelpers inputHelpers = new InputHelpers();

        private readonly Brush OkBrush = Brushes.Black;
        private readonly Brush ErrorBrush = Brushes.DarkRed;

        public MainWindow()
        {
            InitializeComponent();

            searchRadioButton.IsChecked = true;
        }

        private void searchRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            searchAlgorithmsPanel.IsEnabled = true;
            sortAlgorithmsPanel.IsEnabled = false;

            searchOnlyInput.IsEnabled = true;
        }

        private void sortRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            searchAlgorithmsPanel.IsEnabled = false;
            sortAlgorithmsPanel.IsEnabled = true;

            searchOnlyInput.IsEnabled = false;
        }

        private void linearButton_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            HandleSearch(search.Linear);
        }

        private void binaryButton_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();

            try
            {
                // Instead of directly passing the Search.Binary() method through,
                // encapsulate it within another lambda delegate to be passed through
                // so that 'checkIfSorted' parameter is handled and it adheres to the
                // delegate 'searchAlgorithm' argument input requirements
                HandleSearch((nums, des) => search.Binary(nums, des, true));
            }
            catch (SearchAndSort.Exceptions.NotInOrderException ex)
            {
                outputLabel.Foreground = ErrorBrush;
                outputLabel.Content = "Provided array of integers not sorted.";
            }
        }


        #region Helper methods

        /// <summary>
        /// Helper method that performs common tasks of the search event handlers,
        /// including validation, parsing and appropriate output.
        /// </summary>
        /// <param name="searchAlgorithm">
        /// Delegate that represents the desired search algorithm,
        /// including input parameters for array of integers (int[]) 
        /// and desired integer to be found (int), as well as an output parameter
        /// for array index of desired integer.
        /// </param>
        private void HandleSearch(Func<int[], int, int?> searchAlgorithm)
        {
            if (string.IsNullOrWhiteSpace(inputBox.Text)
                || string.IsNullOrWhiteSpace(desiredNumBox.Text))
                return;

            int[] nums = inputHelpers.ParseSpaceDelimitedIntegers(inputBox.Text);

            int desiredNum;
            bool tryParseDesiredNum = Int32.TryParse(desiredNumBox.Text, out desiredNum);

            if (tryParseDesiredNum)
            {
                Search search = new Search();
                int? result = searchAlgorithm(nums, desiredNum);

                if (result.HasValue)
                {
                    outputLabel.Foreground = OkBrush;
                    outputLabel.Content = string.Format("Found {0} at index {1}.", desiredNum, result) + "\n";

                    var numsStringWithDesiredNumDenoted = new StringBuilder();
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (i == result.Value)
                            numsStringWithDesiredNumDenoted.Append(string.Format("[{0}] ", nums[i]));
                        else
                            numsStringWithDesiredNumDenoted.Append(string.Format("{0} ", nums[i]));
                    }

                    outputLabel.Content += numsStringWithDesiredNumDenoted.ToString();
                }
                else
                {
                    outputLabel.Foreground = ErrorBrush;
                    outputLabel.Content = string.Format("Desired number ({0}) not found.", desiredNum);
                }
            }
            else
            {
                outputLabel.Foreground = ErrorBrush;
                outputLabel.Content = "Specified desired number is not a valid integer.";
            }
        }

        #endregion
    }
}
