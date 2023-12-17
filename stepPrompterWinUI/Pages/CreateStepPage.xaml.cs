using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Newtonsoft.Json;
using stepPrompterWinUI.Dialogs;
using stepPrompterWinUI.Helpers;
using stepPrompterWinUI.Models;
using stepPrompterWinUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace stepPrompterWinUI.Pages
{
    public sealed partial class CreateStepPage : Page
    {
        //public ObservableCollection<SubStep> SubSteps { get; } = new ObservableCollection<SubStep>();
        //public ObservableCollection<StepInfo> StepsCollection { get; } = new ObservableCollection<StepInfo>();
        //private int currentStepIndex = -1;
        //private StepInfo _selectedStep;
        //public StepInfo SelectedStep
        //{
        //    get => _selectedStep;
        //    set
        //    {
        //        if (_selectedStep != value)
        //        {
        //            _selectedStep = value;
        //            // Add any additional logic you want to execute when the selection changes
        //            // For example, updating UI elements or enabling/disabling buttons
        //            OnPropertyChanged(nameof(SelectedStep));
        //            PopulateEditingFields(_selectedStep);
        //        }
        //    }
        //}

        public CreateStepPageViewModel ViewModel { get; private set; }

        public CreateStepPage()
        {
            InitializeComponent();

            // Assuming you have a way to access XamlRoot, such as through a property on the page or window.
            var dialogService = new DialogService(this.XamlRoot);
            ViewModel = new CreateStepPageViewModel(dialogService);

            this.DataContext = ViewModel;
        }

        // Don't forget to unsubscribe from the event when the Page is unloaded




        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //private void AddSubStepButton_Click(object sender, RoutedEventArgs e)
        //{
        //    SubSteps.Add(new SubStep());
        //}

        //private void AddStepButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var newStep = new Step
        //    {
        //        Title = StepTitleTextBox.Text,
        //        Descriptions = SubSteps.ToList()
        //    };

        //    StepsCollection.Add(new StepInfo
        //    {
        //        StepName = newStep.Title, // FileName is a placeholder for your unique identifier
        //        Steps = new List<Step> { newStep }
        //    });

        //    ClearInputFields();
        //    ShowMessage("Step added successfully.");
        //}

        //private async void EditStepButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var button = (Button)sender;
        //    var stepInfo = (StepInfo)button.DataContext;

        //    // Scroll the item into view to ensure it's realized
        //    StepsListView.ScrollIntoView(stepInfo);

        //    // Wait for the UI to update
        //    await Task.Delay(100); // You may need to adjust this delay

        //    // Now attempt to retrieve the ListViewItem
        //    var listViewItem = StepsListView.ContainerFromItem(stepInfo) as ListViewItem;

        //    // Ensure the ListViewItem is not null and the item is realized
        //    if (listViewItem != null)
        //    {
        //        // Now attempt to find the EditingPanel within the ListViewItem
        //        var editingPanel = FindChildControl<StackPanel>(listViewItem, "EditingPanel");
        //        if (editingPanel != null)
        //        {
        //            editingPanel.Visibility = Visibility.Visible;
        //        }
        //        else
        //        {
        //            // Handle the case where the EditingPanel is not found
        //        }
        //    }
        //}



        //private void UpdateStepButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Get the button that was clicked and its DataContext
        //    var button = (Button)sender;
        //    var stepInfo = (StepInfo)button.DataContext;

        //    // Assuming the button is within the EditingPanel
        //    var editingPanel = (StackPanel)button.Parent;
        //    if (editingPanel != null)
        //    {
        //        // Hide the editing panel
        //        editingPanel.Visibility = Visibility.Collapsed;

        //        // Update the step in the ObservableCollection
        //        // The UI will automatically reflect the changes due to data binding
        //    }
        //}

        //private async void SaveAllStepsButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var json = JsonConvert.SerializeObject(StepsCollection, Formatting.Indented);
        //    var success = await SaveJsonToFile(json);
        //    ShowMessage(success ? "Steps saved successfully." : "Failed to save steps.");
        //}

        //private T FindChildControl<T>(DependencyObject parent, string controlName) where T : DependencyObject
        //{
        //    // Confirm parent and controlName are valid.
        //    if (parent == null || string.IsNullOrEmpty(controlName))
        //    {
        //        return null;
        //    }

        //    int count = VisualTreeHelper.GetChildrenCount(parent);
        //    for (int i = 0; i < count; i++)
        //    {
        //        // Get the child
        //        var child = VisualTreeHelper.GetChild(parent, i);
        //        // If the child is not of the request child type child
        //        if (child is not T typedChild)
        //        {
        //            // Recursively drill down the tree
        //            T foundChild = FindChildControl<T>(child, controlName);
        //            if (foundChild != null)
        //            {
        //                return foundChild;
        //            }
        //        }
        //        else if (!string.IsNullOrEmpty(controlName))
        //        {
        //            var frameworkElement = child as FrameworkElement;
        //            // If the child's name is set for search
        //            if (frameworkElement != null && frameworkElement.Name == controlName)
        //            {
        //                // if the child's name is of the requested name
        //                return typedChild;
        //            }
        //        }
        //        else
        //        {
        //            // child element found.
        //            return typedChild;
        //        }
        //    }

        //    return null; // Not found
        //}

        //private T FindParentOfType<T>(DependencyObject child) where T : DependencyObject
        //{
        //    T parent = null;

        //    while (child != null && !(child is T))
        //    {
        //        child = VisualTreeHelper.GetParent(child);
        //    }

        //    if (child != null)
        //    {
        //        parent = (T)child;
        //    }

        //    return parent;
        //}

        //private async Task<bool> SaveJsonToFile(string json)
        //{
        //    var savePicker = new FileSavePicker
        //    {
        //        SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
        //        FileTypeChoices = { { "JSON File", new List<string>() { ".json" } } },
        //        SuggestedFileName = "StepsCollection"
        //    };

        //    IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(MainWindow.m_window);
        //    WinRT.Interop.InitializeWithWindow.Initialize(savePicker, hwnd);

        //    StorageFile file = await savePicker.PickSaveFileAsync();
        //    if (file != null)
        //    {
        //        await FileIO.WriteTextAsync(file, json);
        //        return true;
        //    }
        //    return false;
        //}

        //private void ClearInputFields()
        //{
        //    StepTitleTextBox.Text = string.Empty;
        //    SubSteps.Clear();
        //}

        //private async void ShowMessage(string message)
        //{
        //    var dialog = new ContentDialog
        //    {
        //        Title = "Information",
        //        Content = message,
        //        CloseButtonText = "Ok",
        //        XamlRoot = this.XamlRoot

        //    };
        //    await dialog.ShowAsync();
        //}

        //private void LoadSteps()
        //{
        //    // Load steps from your data source here
        //    // This example initializes with an empty collection
        //    // Deserialize your data into StepsCollection if available
        //}

        //private void NavigateThroughSteps(int newIndex)
        //{
        //    if (newIndex >= 0 && newIndex < StepsCollection.Count)
        //    {
        //        currentStepIndex = newIndex;
        //        var stepInfo = StepsCollection[currentStepIndex];
        //        PopulateEditingFields(stepInfo);
        //    }
        //}

        //private void PopulateEditingFields(StepInfo stepInfo)
        //{
        //    if (stepInfo != null)
        //    {
        //        // Update your editing fields with the information from the selected step
        //        StepTitleTextBox.Text = stepInfo.StepName; // or another appropriate field
        //        SubSteps.Clear();
        //        foreach (var subStep in stepInfo.Steps[0].Descriptions)
        //        {
        //            SubSteps.Add(subStep);
        //        }
        //    }
        //}
    }
}
