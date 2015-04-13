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
    }
}
