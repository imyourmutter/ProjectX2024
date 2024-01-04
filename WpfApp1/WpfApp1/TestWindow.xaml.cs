using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace WpfApp3
{
    public partial class TestWindow : Window
    {
        private MathTest mathTest;
        private string name;
        private int currentQuestionIndex = 0;
        private int correctAnswers = 0;


        public TestWindow()
        {

        }

        public TestWindow(int grade, string name)
        {
            InitializeComponent();
            mathTest = new MathTest(10, grade); // יצירת מבחן חדש עם 10 שאלות
            this.name = name;
            DisplayNextQuestion();
        }

        private void DisplayNextQuestion()
        {
            if (currentQuestionIndex < mathTest.Questions.Length)
            {
                var currentQuestion = mathTest.Questions[currentQuestionIndex];
                questionTextBlock.Text = currentQuestion.QuestionText; // הצגת השאלה
                progressTextBlock.Text = $"{currentQuestionIndex + 1} / {mathTest.Questions.Length}"; // עדכון התקדמות
                answerTextBox.Clear(); // ניקוי תיבת התשובה
            }
            else
            {
                // טיפול בסיום המבחן
                MessageBox.Show($"Hey {name}, Congrats! You came correct in {correctAnswers} from {mathTest.Questions.Length} total.");
                this.Close(); // סגירת החלון
            }
        }

        string curr = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private void PlaySuccessSound()
        {
            var successFile = new Uri(Path.Combine(Directory.GetParent(curr).Parent.FullName, "success-1-6297.mp3"), UriKind.RelativeOrAbsolute);
            var player = new MediaPlayer();

            player.Open(successFile);
            player.Play();
        }

        private void PlayFailureSound()
        {
            var failureFile = new Uri(Path.Combine(Directory.GetParent(curr).Parent.FullName, "wahwahwahwaaaahahahahahaha-94669.mp3"), UriKind.RelativeOrAbsolute);
            var player = new MediaPlayer();

            player.Open(failureFile);
            player.Play();
        }

        private void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(answerTextBox.Text, out double userAnswer))
            {
                if (mathTest.Questions[currentQuestionIndex].CheckAnswer(userAnswer))
                {
                    correctAnswers++;
                    resultTextBlock.Text = "Correct!";
                    PlaySuccessSound();
                }
                else
                {
                    resultTextBlock.Text = "Incorrect!";
                    PlayFailureSound();
                }

                currentQuestionIndex++; // עבור לשאלה הבאה
                DisplayNextQuestion();
            }
            else
            {
                MessageBox.Show("אנא הכנס מספר תקין.");
            }
        }
    }
}