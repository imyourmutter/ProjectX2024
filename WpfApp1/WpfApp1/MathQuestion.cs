using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace WpfApp3
{
    public class MathQuestion
    {
        public string QuestionText { get; private set; }
        public double CorrectAnswer { get; private set; }

        // יוצר שאלה עם פעולה חשבונית אקראית
        public MathQuestion(int grade, Random rnd)
        {
            if(grade < 1)
            {
                QuestionText = "No grade selected!";
            } else
            {
                GenerateRandomQuestion(grade, rnd);
            }
        }

        // יצירת שאלה חשבונית אקראית
        private void GenerateRandomQuestion(int grade, Random rnd)
        {
            int num1 = rnd.Next(1, 10); // מספרים אקראיים בין 1 ל-10
            int num2 = rnd.Next(1, 10);

            switch (grade)
            {
                case 1: // חיבור
                    QuestionText = $"{num1} + {num2} = ?";
                    CorrectAnswer = num1 + num2;
                    break;
                case 2: // חיסור
                    QuestionText = $"{num1} - {num2} = ?";
                    CorrectAnswer = num1 - num2;
                    break;
                case 3: // כפל
                    QuestionText = $"{num1} * {num2} = ?";
                    CorrectAnswer = num1 * num2;
                    break;
                case 4: // חילוק
                        // ודא שלא נחלק באפס
                    num2 = num2 == 0 ? 1 : num2;
                    QuestionText = $"{num1} / {num2} = ?";
                    double num1Copy = (double)num1;
                    double num2Copy = (double)num2;
                    CorrectAnswer = ((int)((num1Copy / num2Copy) * 100.0)) / 100.0;
                    break;
            }
        }

        // בדיקת תשובה
        public bool CheckAnswer(double answer)
        {
            return answer == CorrectAnswer;
        }

        // הצגת השאלה
        public void DisplayQuestion()
        {
            Console.WriteLine(QuestionText);
        }
    }
}
