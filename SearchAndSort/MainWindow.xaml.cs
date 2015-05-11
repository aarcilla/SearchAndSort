using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private Search search = new Search();
        private Sort sort = new Sort();

        private string lastUsedSearchOrSort = "None";

        private readonly Brush OkBrush = Brushes.Black;
        private readonly Brush ErrorBrush = Brushes.DarkRed;

        private readonly string StatusBarDefaultText = "Ready.";

        public MainWindow()
        {
            InitializeComponent();

            searchRadioButton.IsChecked = true;
            disableSortCheckCheckBox.IsChecked = false;
            noSortCheckAscendingRadioButton.IsChecked = true;
            statusBarText.Text = StatusBarDefaultText;
        }


        #region Search button event handlers

        private void linearButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = "Linear Search";
            HandleSearch(search.Linear);
        }

        private void binaryButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = "Binary Search";
            try
            {
                bool disableSortCheck = disableSortCheckCheckBox.IsChecked.Value;
                bool noSortCheckIsDescending = noSortCheckDescendingRadioButton.IsChecked.Value;

                // Instead of directly passing the Search.Binary() method through,
                // encapsulate it within another lambda delegate to be passed through
                // so that 'checkIfSorted' parameter is handled and it adheres to the
                // delegate 'searchAlgorithm' argument input requirements
                HandleSearch((nums, des) => search.Binary(nums, des, !disableSortCheck, noSortCheckIsDescending));
            }
            catch (SearchAndSort.Exceptions.NotInOrderException)
            {
                outputTextBlock.Foreground = ErrorBrush;
                outputTextBlock.Text = "Provided array of integers not sorted.";
            }
        }

        #endregion


        #region Sort button event handlers

        private void selectionButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = "Selection Sort";
            HandleSort(sort.Selection);
        }

        private void insertionButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = "Insertion Sort";
            HandleSort(sort.Insertion);
        }

        private void bubbleButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = "Bubble Sort";
            HandleSort(sort.Bubble);
        }

        private void mergeButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = "Merge Sort";
            HandleSort(sort.Merge);
        }

        private void quickButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = "Quicksort";
            HandleSort(sort.Quick);
        }

        private void heapButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = "Heapsort";
            HandleSort(sort.Heap);
        }

        private void dotNetButton_Click(object sender, RoutedEventArgs e)
        {
            lastUsedSearchOrSort = ".NET Sort";
            HandleSort(sort.DotNet);
        }

        #endregion


        #region Other event handlers

        private void descOrderCheckBox_Click(object sender, RoutedEventArgs e)
        {
            sort.SortOrder = (sender as CheckBox).IsChecked.Value ? SortOrder.Desc: SortOrder.Asc;
        }

        private void copyAllOutputMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(outputTextBlock.Text);
        }

        private void copyAllStatisticsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(statisticsTextBlock.Text);
        }

        private void inputNumbers_MouseEnter(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Spaces, commas, semi-colons, and ampersands as delimiters are allowed.";
        }

        private void binaryButton_MouseEnter(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Numbers must be in ascending or descending order before search.";
        }

        private void statusBarDefault_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarText.Text = StatusBarDefaultText;
        }

        private void disableSortCheckCheckBox_MouseEnter(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Only check if you're certain the inserted numbers are sorted, otherwise results may be inaccurate.";
        }

        private void inputBoxClear_Click(object sender, RoutedEventArgs e)
        {
            inputBox.Text = string.Empty;
        }
        
        #endregion


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
            statisticsTextBlock.Text = string.Format("{0}\n", lastUsedSearchOrSort);

            if (string.IsNullOrWhiteSpace(inputBox.Text)
                || string.IsNullOrWhiteSpace(desiredNumBox.Text))
            {
                outputTextBlock.Foreground = ErrorBrush;
                outputTextBlock.Text = "Either the numbers textbox or desired number textbox is empty.";
                return;
            }

            int[] nums = inputHelpers.ParseDelimitedIntegers(inputBox.Text);
            statisticsTextBlock.Text += string.Format("{0} numbers\n", nums.Length);

            int desiredNum;
            bool tryParseDesiredNum = Int32.TryParse(desiredNumBox.Text, out desiredNum);
            if (!tryParseDesiredNum)
            {
                outputTextBlock.Foreground = ErrorBrush;
                outputTextBlock.Text = "Specified desired number is not a valid integer.";
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            int? result = searchAlgorithm(nums, desiredNum);
            stopwatch.Stop();

            statisticsTextBlock.Text +=
                string.Format("{0} ticks\n", stopwatch.ElapsedTicks);

            if (!result.HasValue)
            {
                outputTextBlock.Foreground = ErrorBrush;
                outputTextBlock.Text = string.Format("Desired number ({0}) not found.", desiredNum);
                return;
            }

            outputTextBlock.Foreground = OkBrush;
            outputTextBlock.Text = string.Format("Found {0} at index {1} (position {2}).", desiredNum, result, (result + 1)) + "\n";

            // Build a string of the input array with the desired number 
            // surrounded by square parentheses to highlight/visualise its position
            var numsStringWithDesiredNumDenoted = new StringBuilder();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == result.Value)
                    numsStringWithDesiredNumDenoted.Append(string.Format("[{0}] ", nums[i]));
                else
                    numsStringWithDesiredNumDenoted.Append(string.Format("{0} ", nums[i]));
            }

            outputTextBlock.Text += numsStringWithDesiredNumDenoted.ToString();
        }

        /// <summary>
        /// Helper method that performs common tasks of the sort event handlers,
        /// including validation, parsing, and appropriate output.
        /// </summary>
        /// <param name="sortAlgorithm">
        /// Delegate that represents the desired sort algorithm, including an
        /// input parameter for array of integers to be sorted (1st int[])
        /// and an output parameter for the aforementioned array now sorted.
        /// </param>
        private void HandleSort(Func<int[], int[]> sortAlgorithm)
        {
            statisticsTextBlock.Text = string.Format("{0}\n", lastUsedSearchOrSort);

            if (string.IsNullOrWhiteSpace(inputBox.Text))
            {
                outputTextBlock.Foreground = ErrorBrush;
                outputTextBlock.Text = "The numbers textbox is empty.";

                return;
            }

            int[] nums = inputHelpers.ParseDelimitedIntegers(inputBox.Text);
            statisticsTextBlock.Text += string.Format("{0} numbers\n", nums.Length);
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortAlgorithm(nums);
            stopwatch.Stop();

            statisticsTextBlock.Text += 
                string.Format("{0} ticks", stopwatch.ElapsedTicks);

            StringBuilder numsStringSorted = new StringBuilder();
            foreach (int num in nums)
            {
                numsStringSorted.Append(num);
                numsStringSorted.Append(" ");
            }

            outputTextBlock.Foreground = OkBrush;
            outputTextBlock.Text = numsStringSorted.ToString();
        }

        #endregion
    }
}
