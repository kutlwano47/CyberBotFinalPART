using System.Windows;
using CyberSecurityBotGUI.Classes;

namespace CyberSecurityBotGUI
{
    public partial class MainWindow : Window
    {
        KeywordManager keywordManager = new KeywordManager();

        ResponseManager responseManager = new ResponseManager();

        MemoryManager memoryManager = new MemoryManager();

        SentimentManager sentimentManager = new SentimentManager();

        SoundManager soundManager = new SoundManager();

        TaskManager taskManager = new TaskManager();

        QuizManager quizManager = new QuizManager();

        ActivityLogger activityLogger = new ActivityLogger();

        NLPManager nlpManager = new NLPManager();

        bool askedFavoriteTopic = false;

        bool quizRunning = false;

        public MainWindow()
        {
            InitializeComponent();

            soundManager.PlayGreeting();

            ChatArea.Text +=
                "🤖 Welcome to the Cyber Security Awareness Bot!\n\n";

            ChatArea.Text +=
                "I can help with:\n";

            ChatArea.Text +=
                "• Password Safety\n";

            ChatArea.Text +=
                "• Phishing\n";

            ChatArea.Text +=
                "• Malware\n";

            ChatArea.Text +=
                "• Privacy\n";

            ChatArea.Text +=
                "• Scams\n";

            ChatArea.Text +=
                "• Cybersecurity Quiz\n";

            ChatArea.Text +=
                "• Task Management\n";

            ChatArea.Text +=
                "• Activity Log\n\n";

            ChatArea.Text +=
                "What is your name?\n";
        }

        private void BotReply(string message)
        {
            ChatArea.Text += "\n🤖 Bot: " + message + "\n";
        }

        private void UserReply(string message)
        {
            ChatArea.Text += "\n👤 You: " + message + "\n";
        }

        
private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                BotReply("Please enter a message.");
                return;
            }

            UserReply(userMessage);

            activityLogger.AddLog("User typed: " + userMessage);

            // Ask for user name
            if (string.IsNullOrEmpty(memoryManager.UserName))
            {
                memoryManager.UserName = userMessage;
                BotReply("Nice to meet you " + memoryManager.UserName + "!");
                BotReply("What is your favourite cybersecurity topic?");
                askedFavoriteTopic = true;
                UserInput.Clear();
                return;
            }

            // Favourite topic
            if (askedFavoriteTopic)
            {
                memoryManager.FavoriteTopic = userMessage;
                BotReply("Great! I'll remember that you like " + memoryManager.FavoriteTopic + ".");
                activityLogger.AddLog("Favourite topic saved.");
                askedFavoriteTopic = false;
                UserInput.Clear();
                return;
            }

            // NLP Detection
            string intent = nlpManager.DetectIntent(userMessage);

            if (intent == "LOG")
            {
                BotReply(activityLogger.ShowLogs());
                UserInput.Clear();
                return;
            }

            if (intent == "QUIZ")
            {
                quizRunning = true;
                quizManager.CurrentQuestion = 0;
                quizManager.Score = 0;

                QuizQuestion q = quizManager.Questions[0];

                string text =
                    q.Question + "\n\n" +
                    string.Join("\n", q.Options);

                BotReply(text);

                activityLogger.AddLog("Quiz Started");

                UserInput.Clear();
                return;
            }

            // Quiz answers
            if (quizRunning)
            {
                QuizQuestion q =
                    quizManager.Questions[quizManager.CurrentQuestion];

                int answer = -1;

                if (userMessage == "a") answer = 0;
                if (userMessage == "b") answer = 1;
                if (userMessage == "c") answer = 2;
                if (userMessage == "d") answer = 3;

                if (answer == q.CorrectAnswer)
                {
                    quizManager.Score++;
                    BotReply("✅ Correct!\n" + q.Explanation);
                }
                else
                {
                    BotReply("❌ Incorrect.\n" + q.Explanation);
                }

                quizManager.CurrentQuestion++;

                if (quizManager.CurrentQuestion >= quizManager.Questions.Count)
                {
                    BotReply("Quiz Finished!");

                    BotReply("Final Score: "
                        + quizManager.Score
                        + "/"
                        + quizManager.Questions.Count);

                    activityLogger.AddLog("Quiz Completed");

                    quizRunning = false;
                }
                else
                {
                    QuizQuestion next =
                        quizManager.Questions[quizManager.CurrentQuestion];

                    BotReply(
                        next.Question +
                        "\n\n" +
                        string.Join("\n", next.Options));
                }

                UserInput.Clear();
                return;
            }

            // Sentiment
            string sentiment =
                sentimentManager.DetectSentiment(userMessage);

            if (sentiment == "worried")
            {
                BotReply("It's understandable to feel worried. Stay alert and avoid suspicious links.");
                UserInput.Clear();
                return;
            }

            if (sentiment == "curious")
            {
                BotReply("Curiosity helps you become cyber aware!");
                UserInput.Clear();
                return;
            }

            if (sentiment == "frustrated")
            {
                BotReply("Cybersecurity takes practice. Keep learning!");
                UserInput.Clear();
                return;
            }

            // Remember
            if (userMessage.Contains("remember"))
            {
                BotReply("I remember that your favourite topic is " + memoryManager.FavoriteTopic);
                UserInput.Clear();
                return;
            }

            // Tell me more
            if (userMessage.Contains("tell me more")
                || userMessage.Contains("another tip")
                || userMessage.Contains("explain more"))
            {
                BotReply("Since you like " + memoryManager.FavoriteTopic +
                    ", always stay alert online.");
                UserInput.Clear();
                return;
            }

            // Keyword detection
            foreach (var keyword in keywordManager.keywordResponses)
            {
                if (userMessage.Contains(keyword.Key))
                {
                    BotReply(keyword.Value);
                    UserInput.Clear();
                    return;
                }
            }

            BotReply("I'm not sure I understand. Could you rephrase that?");

            UserInput.Clear();
        }

        
private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            taskManager.AddTask(
                "Review Privacy Settings",
                "Check all social media privacy settings.",
                "7 days");

            activityLogger.AddLog("Task Added");

            BotReply("Task added successfully!");
        }

        private void ViewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            BotReply(taskManager.ViewTasks());

            activityLogger.AddLog("Viewed Tasks");
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            if (quizManager.Questions.Count == 0)
            {
                BotReply("No quiz questions available.");
                return;
            }

            quizRunning = true;

            quizManager.CurrentQuestion = 0;

            quizManager.Score = 0;

            QuizQuestion q = quizManager.Questions[0];

            BotReply(
                q.Question +
                "\n\n" +
                string.Join("\n", q.Options));

            activityLogger.AddLog("Quiz Started");
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            BotReply(activityLogger.ShowLogs());
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.Clear();
        }

        private void PhishingButton_Click(object sender, RoutedEventArgs e)
        {
            BotReply("Phishing is a cyberattack where criminals trick users into revealing personal information through fake emails or websites.");
        }

        private void MalwareButton_Click(object sender, RoutedEventArgs e)
        {
            BotReply("Malware is malicious software designed to damage systems, steal data, or spy on users.");
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            BotReply("Use strong passwords with uppercase letters, lowercase letters, numbers and symbols. Never reuse passwords.");
        }

        private void PrivacyButton_Click(object sender, RoutedEventArgs e)
        {
            BotReply("Protect your privacy by limiting personal information shared online and checking your account privacy settings regularly.");
        }

        private void ScamButton_Click(object sender, RoutedEventArgs e)
        {
            BotReply("Online scams often pretend to be trusted companies. Never click suspicious links or share sensitive information.");
        }

    }
}