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
            public int num1;
            public int num2;
        }

        static Flashcards[] GetQuestions(int size, bool division = false)
        {
            Flashcards[] questionSet = new Flashcards[size];

            if (division == true)
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
            Flashcards[] DivisionSet = GetQuestions(numQuestions, true);

            for (int i = 0; i < DivisionSet.Length; i++)
            {
                Console.Write($"\nQuestion {i + 1}. \n{DivisionSet[i].num1} / {DivisionSet[i].num2} = ");
                double userAnswer = Convert.ToDouble(Console.ReadLine());
                if (userAnswer == Convert.ToDouble(DivisionSet[i].num1 / DivisionSet[i].num2))
                {
                    Console.WriteLine("Correct.");
                    Score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. Correct answer is {DivisionSet[i].num1 / DivisionSet[i].num2}.");
                }
            }
        }
    }
}
