
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using stepPrompterWinUI;
using stepPrompterWinUI.Helpers;
using stepPrompterWinUI.Models;
using stepPrompterWinUI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace stepPrompterWinUI.ViewModels
{
    public record OpenNewTabMessage(Type PageType, string Header);
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<StepInfo> stepInfos;

        [ObservableProperty]
        private StepInfo selectedStepInfo;

        public HomePageViewModel()
        {
            StepInfos = new ObservableCollection<StepInfo>();
            // Populate your collection with StepInfo instances
        }

        [RelayCommand]
        private void LoadNew()
        {
            // Logic for loading new step
        }

        [RelayCommand]
        private void LoadSaved()
        {
            // Logic for loading saved steps
        }

        [RelayCommand]
        private void Create()
        {
            // Send a message to whoever is listening that we want to open a new tab
            WeakReferenceMessenger.Default.Send(new OpenNewTabMessage(typeof(CreateStepPage), "Create New Step"));
        }

        [RelayCommand]
        private void Delete()
        {
            // Logic for deleting a step
        }
    }
}
