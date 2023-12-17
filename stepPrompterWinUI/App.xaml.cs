using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using stepPrompterWinUI;
using stepPrompterWinUI.Helpers;
using stepPrompterWinUI.Pages;
using stepPrompterWinUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace stepPrompterWinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public static INavigationService NavigationService { get; private set; }
        private static MainWindow m_window;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            NavigationService = new NavigationService(m_window.AppFrame);
            m_window.Activate();

            // Assuming XamlRoot is accessible via the MainWindow.
            // If not, you'll need to ensure you get the XamlRoot from an active window or another source.
            var dialogService = new DialogService(m_window.Content.XamlRoot);
            var createStepPageViewModel = new CreateStepPageViewModel(dialogService);

        }
    }
}