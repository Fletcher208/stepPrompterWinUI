using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using stepPrompterWinUI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace stepPrompterWinUI.Models
{

    public class StepInfo
    {
        public string StepName { get; set; }
        public List<Step> Steps { get; set; } = new List<Step>();
    }

    public class Step : ObservableObject
    {
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public List<SubStep> Descriptions { get; set; } = new List<SubStep>();
    }

    public class SubStep : ObservableObject
    {
        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private string notes;
        public string Notes
        {
            get => notes;
            set => SetProperty(ref notes, value);
        }

        private bool isChecked;
        [JsonProperty("Completed")]
        public bool IsChecked
        {
            get => isChecked;
            set => SetProperty(ref isChecked, value);
        }
    }


    public class StepEventArgs : EventArgs
    {
        public StepInfo StepInfo { get; set; }
    }
}
