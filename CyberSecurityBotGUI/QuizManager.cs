using System.Collections.Generic;

namespace CyberSecurityBotGUI
{
    public class QuizManager
    {
        public List<QuizQuestion> Questions = new List<QuizQuestion>();

        public int CurrentQuestion = 0;

        public int Score = 0;

        public QuizManager()
        {
            Questions.Add(new QuizQuestion(
                "What is phishing?",
                new string[] {
                    "A. Antivirus",
                    "B. Fake email scam",
                    "C. Firewall",
                    "D. VPN"
                },
                1,
                "Phishing uses fake emails or websites to steal information."
            ));

            Questions.Add(new QuizQuestion(
                "Strong passwords should contain:",
                new string[] {
                    "A. Your name",
                    "B. Birthday",
                    "C. Letters, numbers and symbols",
                    "D. Phone number"
                },
                2,
                "Strong passwords should be unique and difficult to guess."
            ));

            Questions.Add(new QuizQuestion(
                "True or False: You should share passwords with friends.",
                new string[] {
                    "A. True",
                    "B. False"
                },
                1,
                "Never share your passwords."
            ));

            Questions.Add(new QuizQuestion(
                "What does 2FA stand for?",
                new string[] {
                    "A. Two-Factor Authentication",
                    "B. Two File Access",
                    "C. Two Fast Accounts",
                    "D. Total File Access"
                },
                0,
                "2FA adds another layer of security."
            ));

            Questions.Add(new QuizQuestion(
                "Which is safest?",
                new string[] {
                    "A. password123",
                    "B. 123456",
                    "C. P@ssw0rd!",
                    "D. abc123"
                },
                2,
                "Use strong complex passwords."
            ));

            Questions.Add(new QuizQuestion(
                "A firewall helps:",
                new string[] {
                    "A. Cook food",
                    "B. Protect networks",
                    "C. Charge batteries",
                    "D. Delete files"
                },
                1,
                "Firewalls protect computers from unauthorized access."
            ));

            Questions.Add(new QuizQuestion(
                "True or False: HTTPS websites are generally safer.",
                new string[] {
                    "A. True",
                    "B. False"
                },
                0,
                "HTTPS encrypts communication."
            ));

            Questions.Add(new QuizQuestion(
                "What should you do with suspicious emails?",
                new string[] {
                    "A. Open them",
                    "B. Reply",
                    "C. Report/Delete",
                    "D. Forward"
                },
                2,
                "Report phishing emails."
            ));

            Questions.Add(new QuizQuestion(
                "VPN stands for:",
                new string[] {
                    "A. Virtual Private Network",
                    "B. Visual Password Number",
                    "C. Virus Protection Network",
                    "D. Virtual Public Number"
                },
                0,
                "VPN encrypts internet traffic."
            ));

            Questions.Add(new QuizQuestion(
                "Updating software helps:",
                new string[] {
                    "A. Hack faster",
                    "B. Fix security vulnerabilities",
                    "C. Slow PC",
                    "D. Delete files"
                },
                1,
                "Updates patch security holes."
            ));
        }
    }
}