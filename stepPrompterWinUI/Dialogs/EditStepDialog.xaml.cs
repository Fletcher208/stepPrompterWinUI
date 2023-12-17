using Microsoft.UI.Xaml.Controls;
using stepPrompterWinUI.Models;
using System.Threading.Tasks;
using System;

namespace stepPrompterWinUI.Dialogs
{
    public sealed partial class EditStepDialog : ContentDialog
    {
        public Step Step { get; set; }

        public EditStepDialog(Step step)
        {
            InitializeComponent();
            Step = step;
        }

        public async Task<ContentDialogResult> ShowEditStepDialog(Step step)
        {
            var dialog = new EditStepDialog(step)
            {
                // Set any required properties for the dialog here
            };
            return await dialog.ShowAsync();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Assuming the StepInfo's properties are bound to dialog controls with TwoWay binding mode,
            // the StepInfo object will be updated automatically when you interact with the UI.
            // No additional code is needed here unless you need to perform validation or other operations before closing the dialog.
        }
    }
}
