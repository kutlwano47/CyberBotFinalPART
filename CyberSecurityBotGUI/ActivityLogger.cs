using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBotGUI
{
    public class ActivityLogger
    {
        private List<string> logs = new List<string>();

        public void AddLog(string action)
        {
            logs.Add($"{DateTime.Now:G} - {action}");
        }

        public string ShowLogs()
        {
            if (logs.Count == 0)
            {
                return "No activity recorded yet.";
            }

            StringBuilder sb = new StringBuilder();

            int start = Math.Max(0, logs.Count - 10);

            for (int i = start; i < logs.Count; i++)
            {
                sb.AppendLine(logs[i]);
            }

            return sb.ToString();
        }
    }
}