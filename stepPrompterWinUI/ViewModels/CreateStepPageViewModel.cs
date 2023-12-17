using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using stepPrompterWinUI.Dialogs;
using stepPrompterWinUI.Helpers;
using stepPrompterWinUI.Models;
using stepPrompterWinUI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stepPrompterWinUI.ViewModels
{
    public partial class CreateStepPageViewModel : ObservableObject
    {

        private readonly IDialogService _dialogService;

        public CreateStepPageViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public CreateStepPageViewModel()
        {
            
        }

        [ObservableProperty]
        private ObservableCollection<SubStep> subSteps = new();

        [ObservableProperty]
        private ObservableCollection<Step> stepsCollection = new();

        [ObservableProperty]
        private string stepTitle;

        [RelayCommand]
        private void AddSubStep()
        {
            SubSteps.Add(new SubStep());
        }

        [RelayCommand]
        private void AddStep()
        {
            // Create a new list of SubSteps from the existing SubSteps ObservableCollection
            var descriptions = SubSteps.Select(subStep => new SubStep
            {
                Description = subStep.Description,
                Notes = subStep.Notes,
                IsChecked = subStep.IsChecked
            }).ToList();

            // Create a new Step with the title and the list of descriptions
            var newStep = new Step
            {
                Title = StepTitle,
                Descriptions = descriptions
            };

            // Add the new Step to the StepsCollection
            StepsCollection.Add(newStep);

            // Reset the input fields
            StepTitle = string.Empty;
            SubSteps.Clear();
        }

        [RelayCommand]
        private async Task EditStepAsync(Step step)
        {
            var result = await _dialogService.ShowEditStepDialog(step);
            // Handle the result here
        }



        [RelayCommand]
        private void UpdateStep(StepInfo stepInfo)
        {
            // Logic to update the step
        }

        [RelayCommand]
        private async void SaveAllSteps()
        {
            // Logic to save all steps
        }
    }
}
