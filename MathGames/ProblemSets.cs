using System;
using System.Collections.Generic;
using System.Text;

namespace MathGames
{
    class ProblemSets
    {
        private int _score;

        public static int Score { get; set; }

        static Random r = new Random();

        struct Flashcards
        {
            public double num1;
            public double num2;
        }

        static Flashcards[] GetQuestions(int size, bool division = false)
        {
            Flashcards[] questionSet = new Flashcards[size];

            if (division == true) // Division questions will not contain 0s.
            {
                for (int i = 0; i < size; i++)
                {
                    questionSet[i] = new Flashcards
                    {
                        num1 = r.Next(1,13),
                        num2 = r.Next(1,13)
                    };

                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    questionSet[i] = new Flashcards
                    {
                        num1 = r.Next(13),
                        num2 = r.Next(13)
                    };

                }
            }
            return questionSet;
        }

        public static void AdditionQuestions(int numQuestions)
        {
            Flashcards[] additionSet = GetQuestions(numQuestions);

            for (int i = 0; i < additionSet.Length; i++)
            {
                Console.Write($"\nQuestion {i + 1}. \n{additionSet[i].num1} + {additionSet[i].num2} = ");
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                if (userAnswer == additionSet[i].num1 + additionSet[i].num2)
                {
                    Console.WriteLine("Correct.");
                    Score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. Correct answer is {additionSet[i].num1 + additionSet[i].num2}.");
                }
            }
        }

        public static void MultiplicationQuestions(int numQuestions)
        {
            Flashcards[] multiSet = GetQuestions(numQuestions);

            for (int i = 0; i < multiSet.Length; i++)
            {
                Console.Write($"\nQuestion {i + 1}. \n{multiSet[i].num1} * {multiSet[i].num2} = ");
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                if (userAnswer == multiSet[i].num1 * multiSet[i].num2)
                {
                    Console.WriteLine("Correct.");
                    Score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. Correct answer is {multiSet[i].num1 * multiSet[i].num2}.");
                }
            }
        }

        public static void SubtractionQuestions(int numQuestions)
        {
            Flashcards[] SubtractSet = GetQuestions(numQuestions);

            for (int i = 0; i < SubtractSet.Length; i++)
            {
                if (SubtractSet[i].num1 < SubtractSet[i].num2) // Swap numbers if the left number is less than the left.
                {
                    SubtractSet[i].num1 += SubtractSet[i].num2;
                    SubtractSet[i].num2 = SubtractSet[i].num1 - SubtractSet[i].num2;
                    SubtractSet[i].num1 -= SubtractSet[i].num2;
                }

                Console.Write($"\nQuestion {i + 1}. \n{SubtractSet[i].num1} - {SubtractSet[i].num2} = ");
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                if (userAnswer == SubtractSet[i].num1 - SubtractSet[i].num2)
                {
                    Console.WriteLine("Correct.");
                    Score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. Correct answer is {SubtractSet[i].num1 - SubtractSet[i].num2}.");
                }
            }
        }

        public static void DivisionQuestions(int numQuestions)
        {
            Flashcards[] DivSet = GetQuestions(numQuestions, true);

            for (int i = 0; i < DivSet.Length; i++)
            {
                Console.Write($"\nQuestion {i + 1}. \n{DivSet[i].num1} / {DivSet[i].num2} = ");
                double userAnswer = Convert.ToDouble(Console.ReadLine());
                if (userAnswer == Math.Round((DivSet[i].num1 / DivSet[i].num2), 2))
                {
                    Console.WriteLine("Correct.");
                    Score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. Correct answer is {Math.Round((DivSet[i].num1 / DivSet[i].num2),2)}.");
                }
            }
        }
    }
}
