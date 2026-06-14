using System;

namespace CyberSecurityBotGUI
{
    public class NLPManager
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            if (input.Contains("task") || input.Contains("reminder"))
                return "TASK";

            if (input.Contains("quiz") || input.Contains("game"))
                return "QUIZ";

            if (input.Contains("activity") || input.Contains("log"))
                return "LOG";

            if (input.Contains("password"))
                return "PASSWORD";

            if (input.Contains("phishing"))
                return "PHISHING";

            if (input.Contains("privacy"))
                return "PRIVACY";

            if (input.Contains("malware"))
                return "MALWARE";

            return "UNKNOWN";
        }
    }
}