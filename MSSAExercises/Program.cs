using System;

namespace MathGames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programming Exercise 12 | Math Games");
            Console.WriteLine("EX 3B - 3C - DPerez - 09/23/2020");
            /*
             * four "sets" of flash cards: addition, subtraction, multiplication, and division
             * beginning with, ask user the type of problem they want to practice and number of problems.
             * echo problem type and number of problems to the user
             */
            Console.WriteLine("\nWelcome to Math Games!");
            Console.WriteLine("Which type of problem would you like to practice?");
            Console.WriteLine("\tAddition, enter 1");
            Console.WriteLine("\tSubtraction, enter 2");
            Console.WriteLine("\tMultiplication, enter 3");
            Console.WriteLine("\tDivision, enter 4");
            Console.Write("\nEnter your selection: ");

            int problemType = Convert.ToInt32(Console.ReadLine());
            while (problemType < 1 || problemType > 4)
            {
                Console.Write("\nInvalid input! Enter a number ranging from 1 to 4: ");
                problemType = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("\nHow many questions would you like to receive (max of 12): ");
            int practiceAmount = Convert.ToInt32(Console.ReadLine());
            while (practiceAmount < 1 || practiceAmount > 12)
            {
                Console.Write("\nInvalid input! Enter a number ranging from 1 to 12: ");
                practiceAmount = Convert.ToInt32(Console.ReadLine());
            }

            if (problemType == 1)
            {
                Console.WriteLine($"\nProblem type: Addition | Number of questions: {practiceAmount}.");
                ProblemSets.AdditionQuestions(practiceAmount);
            }
            else if (problemType == 2)
            {
                Console.WriteLine($"\nProblem type: Subtraction | Number of questions: {practiceAmount}.");
                ProblemSets.SubtractionQuestions(practiceAmount);
            }
            else if (problemType == 3)
            {
                Console.WriteLine($"\nProblem type: Multiplication | Number of questions: {practiceAmount}.");
                ProblemSets.MultiplicationQuestions(practiceAmount);
            }
            else if (problemType == 4)
            {
                Console.WriteLine($"\nProblem type: Division | Number of questions: {practiceAmount}.");
                ProblemSets.DivisionQuestions(practiceAmount);
            }

            Console.WriteLine($"Your score was {ProblemSets.Score} / {practiceAmount}. You got");
        }
    }
}
