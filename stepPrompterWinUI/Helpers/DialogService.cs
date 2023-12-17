using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using stepPrompterWinUI.Dialogs;
using stepPrompterWinUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static stepPrompterWinUI.Helpers.NavigationService;

namespace stepPrompterWinUI.Helpers
{

    public interface IDialogService
    {
        Task<ContentDialogResult> ShowEditStepDialog(Step step);
    }

    public class DialogService : IDialogService
    {
        private XamlRoot _xamlRoot;

        public DialogService(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

        public async Task<ContentDialogResult> ShowEditStepDialog(Step step)
        {
            var editDialog = new EditStepDialog(step)
            {
                XamlRoot = _xamlRoot
            };
            return await editDialog.ShowAsync();
        }
    }
}
