namespace CyberSecurityBotGUI.Classes
{
    public class SentimentManager
    {
        public string DetectSentiment(string message)
        {
            message = message.ToLower();

            if (message.Contains("worried"))
            {
                return "worried";
            }

            else if (message.Contains("frustrated"))
            {
                return "frustrated";
            }

            else if (message.Contains("curious"))
            {
                return "curious";
            }

            return "";
        }
    }
}