using Newtonsoft.Json;
using stepPrompterWinUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace stepPrompterWinUI.Helpers
{
    public static class StepFileImporter
    {
        private const string TitlePattern = @"^\d+\. .*";

        // Unified import function that decides the method based on file extension
        public static List<Step> ImportSteps(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            return extension switch
            {
                ".txt" => ImportStepsFromTextFile(filePath),
                ".json" => ImportStepsFromJsonFile(filePath),
                _ => throw new NotSupportedException("File format not supported.")
            };
        }

        private static List<Step> ImportStepsFromTextFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).ToList();
            return ParseSteps(lines);
        }

        private static List<Step> ImportStepsFromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Step>>(json);
        }

        private static List<Step> ParseSteps(List<string> lines)
        {
            var steps = new List<Step>();

            for (int i = 0; i < lines.Count; i++)
            {
                if (IsTitleLine(lines[i]))
                {
                    var step = new Step 
                    {
                        Title = lines[i],
                        Descriptions = new List<SubStep>()
                    };

                    int j = i + 1;
                    while (j < lines.Count && !IsTitleLine(lines[j]))
                    {
                        step.Descriptions.Add(new SubStep { Description = lines[j].Trim(), IsChecked = false });
                        j++;
                    }

                    steps.Add(step);
                    i = j - 1;
                }
            }

            return steps;
        }

        private static bool IsTitleLine(string line)
        {
            return Regex.IsMatch(line, TitlePattern);
        }
    }
}
