using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AS_CourseWork
{
    class Quiz
    {
        private static string currentTopic, currentDifficulty;

        private Quiz()
        {

        }

        public static string CurrentTopic { get => currentTopic; set => currentTopic = value; }
        public static string CurrentDifficulty { get => currentDifficulty; set => currentDifficulty = value; }

        public static List<MultipleChoice> GetMCQs()
        {
            List<MultipleChoice> question = new List<MultipleChoice>();
            List<MultipleChoice> randomisedQuestions = new List<MultipleChoice>();


            string path = "MultipleChoiceQuestions.csv";
            string[] questions = new string[File.ReadAllLines(path).Length];
            int questionNo = questions.Length;
            string[,] mcqs = new string[questionNo, 8];
            questions = File.ReadAllLines(path);

            string[] temp = new string[8];

            for (int i = 0; i < questionNo; i++)
            {
                temp = questions[i].Split(',');
               
                    MultipleChoice n = new MultipleChoice();
                    if (temp[6] == currentTopic)
                    {
                        n.QuestionText = temp[0];
                        n.possibleAns[0] = temp[1];
                        n.possibleAns[1] = temp[2];
                        n.possibleAns[2] = temp[3];
                        n.possibleAns[3] = temp[4];
                        n.Answer = temp[5];
                        question.Add(n);
                    }
            }

            while (randomisedQuestions.Count < question.Count)
            {
                Random r = new Random();
                int randomInt = r.Next(0, question.Count);
                while (randomisedQuestions.Contains(question[randomInt]))
                {
                    randomInt = r.Next(0, question.Count);
                }
                randomisedQuestions.Add(question[randomInt]);
            }
            
            return randomisedQuestions;
        }
    }
}
