using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static stepPrompterWinUI.Helpers.NavigationService;

namespace stepPrompterWinUI.Helpers
{
   
    public interface INavigationService
    {
        void NavigateTo(Type pageType, object parameter = null);
    }

    public class NavigationService : INavigationService
    {
        private Frame _contentFrame;

        public NavigationService(Frame contentFrame)
        {
            _contentFrame = contentFrame;
        }

        public void NavigateTo(Type pageType, object parameter = null)
        {
            _contentFrame.Navigate(pageType, parameter);
        }
    }

}
