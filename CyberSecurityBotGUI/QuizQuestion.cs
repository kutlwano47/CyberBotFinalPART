namespace CyberSecurityBotGUI
{
    public class QuizQuestion
    {
        public string Question { get; set; }

        public string[] Options { get; set; }

        public int CorrectAnswer { get; set; }

        public string Explanation { get; set; }

        public QuizQuestion(string question, string[] options, int correctAnswer, string explanation)
        {
            Question = question;
            Options = options;
            CorrectAnswer = correctAnswer;
            Explanation = explanation;
        }
    }
}