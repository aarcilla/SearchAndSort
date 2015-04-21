﻿using System;
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

        private Search search = new Search();
        private Sort sort = new Sort();

        private readonly Brush OkBrush = Brushes.Black;
        private readonly Brush ErrorBrush = Brushes.DarkRed;

        public MainWindow()
        {
            InitializeComponent();

            searchRadioButton.IsChecked = true;
        }

        #region Search/sort radio button event handlers

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

        #endregion


        #region Search button event handlers

        private void linearButton_Click(object sender, RoutedEventArgs e)
        {
            HandleSearch(search.Linear);
        }

        private void binaryButton_Click(object sender, RoutedEventArgs e)
        {
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

        #endregion


        #region Sort button event handlers

        private void selectionButton_Click(object sender, RoutedEventArgs e)
        {
            HandleSort(sort.Selection);
        }

        private void insertionButton_Click(object sender, RoutedEventArgs e)
        {
            HandleSort(sort.Insertion);
        }

        private void bubbleButton_Click(object sender, RoutedEventArgs e)
        {
            HandleSort(sort.Bubble);
        }

        private void mergeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void quickButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion


        #region Other event handlers

        private void descOrderCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
                sort.SortOrder = SortOrder.Desc;
            else
                sort.SortOrder = SortOrder.Asc;
        }

        private void copyAllOutputMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((string)outputLabel.Content);
        }

        private void copyAllStatisticsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((string)statisticsLabel.Content);
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
            if (string.IsNullOrWhiteSpace(inputBox.Text)
                || string.IsNullOrWhiteSpace(desiredNumBox.Text))
                return;

            int[] nums = inputHelpers.ParseSpaceDelimitedIntegers(inputBox.Text);

            int desiredNum;
            bool tryParseDesiredNum = Int32.TryParse(desiredNumBox.Text, out desiredNum);
            if (!tryParseDesiredNum)
            {
                outputLabel.Foreground = ErrorBrush;
                outputLabel.Content = "Specified desired number is not a valid integer.";
                return;
            }

            int? result = searchAlgorithm(nums, desiredNum);
            if (!result.HasValue)
            {
                outputLabel.Foreground = ErrorBrush;
                outputLabel.Content = string.Format("Desired number ({0}) not found.", desiredNum);
                return;
            }

            outputLabel.Foreground = OkBrush;
            outputLabel.Content = string.Format("Found {0} at index {1}.", desiredNum, result) + "\n";

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

            outputLabel.Content += numsStringWithDesiredNumDenoted.ToString();
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
            if (string.IsNullOrWhiteSpace(inputBox.Text))
                return;

            int[] nums = inputHelpers.ParseSpaceDelimitedIntegers(inputBox.Text);

            int[] numsSorted = sortAlgorithm(nums);

            StringBuilder numsStringSorted = new StringBuilder();
            foreach (int num in numsSorted)
            {
                numsStringSorted.Append(num);
                numsStringSorted.Append(" ");
            }

            outputLabel.Foreground = OkBrush;
            outputLabel.Content = numsStringSorted.ToString();
        }

        #endregion
    }
}
