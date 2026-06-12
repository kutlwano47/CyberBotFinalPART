using System.Collections.Generic;

namespace CyberSecurityBotGUI.Classes
{
    public class KeywordManager
    {
        public Dictionary<string, string> keywordResponses =
            new Dictionary<string, string>()
        {
            {
                "phishing",
                "Phishing uses fake emails or messages to trick people INTO revealing sensitive information."
            },

            {
                "malware",
                "Malware is malicious software that damages or steals data from your device."
            },

            {
                "password",
                "Password attacks happen when hackers try to steal or guess your passwords."
            },

            {
                "social engineering",
                "Social engineering manipulates people into giving away confidential information."
            },

            {
                "public wi-fi",
                "Public Wi-Fi networks can expose your data to cybercriminals if unsecured."
            },

            {
                "privacy",
                "Always review your privacy settings and avoid sharing sensitive information online."
            },

            {
                "scam",
                "Scammers often pretend to be trusted organisations to steal your information."
            }
        };
    }
}