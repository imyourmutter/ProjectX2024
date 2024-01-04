using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class MathTest
    {
        public MathQuestion[] Questions { get; private set; }
        public int Score { get; private set; }
        private int currentQuestionIndex;
        private Random rnd;

        public MathTest(int numberOfQuestions, int grade)
        {
            Questions = new MathQuestion[numberOfQuestions];
            Score = 0;
            currentQuestionIndex = 0;
            rnd = new Random();

            // יצירת שאלות למבחן
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Questions[i] = new MathQuestion(grade, rnd); // יצירת שאלה חדשה עם פרמטר המחולל האקראי
            }
        }

        // מתן השאלה הנוכחית
        public MathQuestion GetCurrentQuestion()
        {
            if (currentQuestionIndex < Questions.Length)
            {
                return Questions[currentQuestionIndex];
            }
            else
            {
                return null; // אין יותר שאלות
            }
        }

        // קבלת תשובה ועדכון הניקוד
        public bool SubmitAnswer(double answer, bool nextQuestion)
        {
            if (currentQuestionIndex < Questions.Length)
            {
                var currentQuestion = Questions[currentQuestionIndex];
                if(nextQuestion) currentQuestionIndex++;

                if (currentQuestion.CheckAnswer(answer))
                {
                    Score++;
                    return true; // תשובה נכונה
                }
            }
            return false; // תשובה לא נכונה
        }
    }
}
