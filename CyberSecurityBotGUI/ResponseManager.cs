using System;
using System;
using System.Collections.Generic;

namespace CyberSecurityBotGUI.Classes
{
    public class ResponseManager
    {
        Random random = new Random();

        public List<string> phishingTips = new List<string>()
        {
            "Never click suspicious email links.",
            "Always verify the sender's email address.",
            "Scammers often pretend to be trusted companies.",
            "Avoid sharing personal information online."
        };

        public List<string> passwordTips = new List<string>()
        {
            "Use strong passwords with symbols and numbers.",
            "Never use the same password twice.",
            "Enable two-factor authentication for extra security.",
            "Avoid using personal details in passwords."
        };

        public string GetRandomPhishingTip()
        {
            return phishingTips[random.Next(phishingTips.Count)];
        }

        public string GetRandomPasswordTip()
        {
            return passwordTips[random.Next(passwordTips.Count)];
        }
    }
}