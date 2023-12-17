using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using stepPrompterWinUI.Pages;
using System.Security.AccessControl;
using stepPrompterWinUI.Models;
using stepPrompterWinUI.Helpers;
using CommunityToolkit.Mvvm.Messaging;
using stepPrompterWinUI.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace stepPrompterWinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public static MainWindow m_window { get; private set; }
        public Frame AppFrame => this.ContentFrame;

        public MainWindow()
        {
            InitializeComponent();
            m_window = this;

            // Register to receive OpenNewTabMessage messages
            WeakReferenceMessenger.Default.Register<OpenNewTabMessage>(this, (r, m) =>
            {
                // When a message is received, open the new tab
                ((MainWindow)r).OpenNewTab(m.PageType, m.Header);
            });

            // Subscribe to the Closed event
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            // Unregister the message when the window is closed to prevent memory leaks
            WeakReferenceMessenger.Default.Unregister<OpenNewTabMessage>(this);
        }

        private void MainTabView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is TabViewItem tab)
            {
                // Assuming the tab header is the name of the page to navigate to
                var pageName = tab.Header.ToString();
                Type pageType = Type.GetType($"stepPrompterWinUI.Pages.{pageName}Page");
                if (pageType != null)
                {
                    ContentFrame.Navigate(pageType);
                }
                else
                {
                    ContentFrame.Content = new TextBlock { Text = "" };
                }
            }
        }


        private void MainTabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Item);
            MainTabView.SelectedItem = MainTabView.TabItems.FirstOrDefault(item => (item as TabViewItem).Header.ToString() == "Home") as TabViewItem;
        }

        public void OpenNewTab(Type pageType, string header)
        {
            var newPage = (Page)Activator.CreateInstance(pageType);
            var newTab = new TabViewItem
            {
                Header = header,
                Content = newPage,
                IsClosable = true
            };

            MainTabView.TabItems.Add(newTab);
            MainTabView.SelectedItem = newTab;
        }

    }
}
