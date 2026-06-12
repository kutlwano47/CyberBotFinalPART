namespace CyberSecurityBotGUI
{
    public class TaskItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Reminder { get; set; }

        public bool Completed { get; set; }

        public TaskItem(string title, string description, string reminder)
        {
            Title = title;
            Description = description;
            Reminder = reminder;
            Completed = false;
        }

        public override string ToString()
        {
            string status = Completed ? "✅ Completed" : "⏳ Pending";

            return $"{Title}\n{Description}\nReminder: {Reminder}\nStatus: {status}";
        }
    }
}