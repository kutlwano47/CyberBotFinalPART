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

        bool askedFavoriteTopic = false;

        public MainWindow()
        {
            InitializeComponent();

            soundManager.PlayGreeting();

            ChatArea.Text += " Bot: Welcome to the Cyber Bot!\n What is your name";

           
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.ToLower();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                ChatArea.Text += "🤖 Bot: Please enter a message.\n";
                return;
            }

            ChatArea.Text += "\n👤 You: " + userMessage + "\n";

            // USER NAME
            if (string.IsNullOrEmpty(memoryManager.UserName))
            {
                memoryManager.UserName = userMessage;

                ChatArea.Text += $"🤖 Bot: Welcome {memoryManager.UserName}!\n";



                ChatArea.Text += "🤖 Bot: What is your favourite cybersecurity topic?\n PHISHING\n MELWARE\n PASSWAORD\n SOCIAL ENGINEERING\n PUBLIC WI-FI\n PRIVACY\n SCAM";

                askedFavoriteTopic = true;

                UserInput.Clear();

                return;
            }

            // FAVORITE TOPIC
            if (askedFavoriteTopic)
            {
                memoryManager.FavoriteTopic = userMessage;

                ChatArea.Text += $"🤖 Bot: Great! I'll remember that you are interested in {memoryManager.FavoriteTopic}.\n";

                foreach (var keyword in keywordManager.keywordResponses)
                {
                    if (userMessage.Contains(keyword.Key))
                    {
                        ChatArea.Text += "🤖 Bot: " + keyword.Value + "\n";
                    }
                }

                askedFavoriteTopic = false;

                UserInput.Clear();

                return;
            }

            // SENTIMENT DETECTION
            string sentiment = sentimentManager.DetectSentiment(userMessage);

            if (sentiment == "worried")
            {
                ChatArea.Text += "🤖 Bot: It's understandable to feel worried about cybersecurity threats.\n";

                ChatArea.Text += "🤖 Bot: Always stay alert and avoid suspicious links.\n";

                UserInput.Clear();

                return;
            }

            else if (sentiment == "frustrated")
            {
                ChatArea.Text += "🤖 Bot: Cybersecurity can feel overwhelming sometimes, but learning step-by-step helps.\n";

                UserInput.Clear();

                return;
            }

            else if (sentiment == "curious")
            {
                ChatArea.Text += "🤖 Bot: Curiosity is great! Learning cybersecurity helps keep you safe online.\n";

                UserInput.Clear();

                return;
            }

            // RANDOM PHISHING TIPS
            if (userMessage.Contains("phishing tip"))
            {
                ChatArea.Text += "🤖 Bot: " + responseManager.GetRandomPhishingTip() + "\n";

                UserInput.Clear();

                return;
            }

            // RANDOM PASSWORD TIPS
            if (userMessage.Contains("password tip"))
            {
                ChatArea.Text += "🤖 Bot: " + responseManager.GetRandomPasswordTip() + "\n";

                UserInput.Clear();

                return;
            }

            // MEMORY RECALL
            if (userMessage.Contains("remember"))
            {
                ChatArea.Text += $"🤖 Bot: I remember that your favourite topic is {memoryManager.FavoriteTopic}.\n";

                UserInput.Clear();

                return;
            }

            // CONVERSATION FLOW
            if (userMessage.Contains("tell me more")
                || userMessage.Contains("another tip")
                || userMessage.Contains("explain more"))
            {
                ChatArea.Text += $"🤖 Bot: Since you are interested in {memoryManager.FavoriteTopic}, always stay alert online and avoid suspicious links.\n";

                UserInput.Clear();

                return;
            }

            // KEYWORD RESPONSES
            bool found = false;

            foreach (var keyword in keywordManager.keywordResponses)
            {
                if (userMessage.Contains(keyword.Key))
                {
                    ChatArea.Text += "🤖 Bot: " + keyword.Value + "\n";

                    found = true;

                    break;
                }
            }

            // DEFAULT RESPONSE
            if (!found)
            {
                ChatArea.Text += "🤖 Bot: I’m not sure I understand. Can you try rephrasing?\n";
            }

            UserInput.Clear();
        }

        private void PhishingButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.Text += "\n🤖 Bot: Phishing is a cyberattack where scammers trick users into revealing sensitive information.\n";
        }

        private void MalwareButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.Text += "\n🤖 Bot: Malware is harmful software designed to damage systems or steal information.\n";
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.Text += "\n🤖 Bot: Always use strong and unique passwords with symbols and numbers.\n";
        }

        private void PrivacyButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.Text += "\n🤖 Bot: Protect your privacy by limiting personal information shared online.\n";
        }

        private void ScamButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.Text += "\n🤖 Bot: Be cautious of online scams and suspicious links.\n";
        }
    }
}