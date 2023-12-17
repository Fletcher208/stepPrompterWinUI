using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using stepPrompterWinUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace stepPrompterWinUI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StepPage : Page
    {
        private StepInfo StepInfo { get; set; }

        public StepPage(StepInfo stepInfo)
        {
            InitializeComponent();
            StepInfo = stepInfo;
            // Now you can use StepInfo to populate the UI elements on this page
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            // Navigation logic for "Back"
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            // Navigation logic for "Next"
        }

        private void TaskCompletedCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            // Logic for handling the checkbox change
        }

        private void SummaryBtn_Click(object sender, RoutedEventArgs e)
        {
            // Logic to show summary
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Logic to save the current state
        }
    }
}
