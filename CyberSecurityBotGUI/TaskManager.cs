using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBotGUI
{
    public class TaskManager
    {
        public List<TaskItem> Tasks = new List<TaskItem>();

        public void AddTask(string title, string description, string reminder)
        {
            Tasks.Add(new TaskItem(title, description, reminder));
        }

        public string ViewTasks()
        {
            if (Tasks.Count == 0)
            {
                return "No tasks available.";
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Tasks.Count; i++)
            {
                sb.AppendLine($"Task {i + 1}");
                sb.AppendLine(Tasks[i].ToString());
                sb.AppendLine("-----------------------");
            }

            return sb.ToString();
        }

        public void CompleteTask(int index)
        {
            if (index >= 0 && index < Tasks.Count)
            {
                Tasks[index].Completed = true;
            }
        }

        public void DeleteTask(int index)
        {
            if (index >= 0 && index < Tasks.Count)
            {
                Tasks.RemoveAt(index);
            }
        }
    }
}