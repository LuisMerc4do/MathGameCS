using System;
using System.Runtime.Versioning;
using MathGameTutorial;
using System.Timers;
using System.Drawing;
namespace MathGameTutorial
{
    public class MathGame
    {
        private int points;
        private System.Timers.Timer _timer;
        public int Points { get { return points; } set { points = value; } }
        public System.Timers.Timer TotalTime { get { return _timer; } }
        private double totalTime;

        public MathGame()
        {
            points = 0;
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = true;
        }


        private static Random rnd = new Random();
        public int RandomNumberGenerator()
        {
            int randomNumber = rnd.Next(1, 10);
            return randomNumber;
        }
        public int RandomNumberGeneratorTwo()
        {
            int randomNumberTwo = rnd.Next(1, 10);
            return randomNumberTwo;
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            totalTime += _timer.Interval / 1000.0; // Update total time in seconds
        }
        public void AdditionGame(int difficultyLevel)
        {
            bool gameIsOver = false;
            int totalPoints = 0;
            totalTime = 0;
            if (difficultyLevel != 1)
            {
                difficultyLevel += 1;
            }
            _timer.Start();
            bool smashed = false;
            bool impressive = false;
            while (!gameIsOver)
            {
                int numberOne = RandomNumberGenerator() * difficultyLevel;
                int numberTwo = RandomNumberGeneratorTwo() * difficultyLevel;
                System.Console.WriteLine($"Sum of: {numberOne} + {numberTwo}");
                int inputResult;
                
                if (int.TryParse(Console.ReadLine(), out inputResult))
                {
                    if (inputResult == numberOne + numberTwo)
                    {
                        totalPoints = totalPoints + 1;
                        if (totalPoints >= 15 && totalPoints <= 30 && !smashed)
                        {
                            Console.WriteLine("Okay you smashed it, incrementing the difficulty level");
                            difficultyLevel += 1;
                            smashed = true;
                        }
                        if (totalPoints >= 30 && !impressive)
                        {
                            Console.WriteLine("Wow, that is impressive, incrementing the difficulty level");
                            difficultyLevel += 2;
                            impressive = true;
                        }
                        continue;
                    }
                    else
                    {
                        _timer.Stop();
                        System.Console.WriteLine($"You Lost! Total Points: {totalPoints}");
                        System.Console.WriteLine($"Time taken: {totalTime:0.00} seconds");
                        gameIsOver = true;
                    }
                    
                    
                }
                else
                {
                    System.Console.WriteLine($"Not an integer, You lost! Total Points: {totalPoints}");
                }
            }
        }
        public void SubtractionGame(int difficultyLevel)
        {
            bool gameIsOver = false;
            int totalPoints = 0;
            totalTime = 0;
            if (difficultyLevel != 1)
            {
                difficultyLevel += 1;
            }
            while (!gameIsOver)
            {
                int numberOne = RandomNumberGenerator() * difficultyLevel;
                int numberTwo = RandomNumberGeneratorTwo() * difficultyLevel;
                System.Console.WriteLine($"Subtraction of: {numberOne} - {numberTwo}");
                int inputResult;
                if (int.TryParse(Console.ReadLine(), out inputResult))
                {
                    _timer.Stop();
                    if (inputResult == numberOne - numberTwo)
                    {
                        totalPoints = totalPoints + 1;
                        continue;
                    }
                    else
                    {
                        System.Console.WriteLine($"You Lost! Total Points: {totalPoints}");
                        System.Console.WriteLine($"Time taken: {totalTime:0.00} seconds");
                        gameIsOver = true;
                    }
                }
                else
                {
                    System.Console.WriteLine($"Not an integer, You lost! Total Points: {totalPoints}");
                }
            }
        }
        public void MultiplicationGame(int difficultyLevel)
        {
            bool gameIsOver = false;
            int totalPoints = 0;
            totalTime = 0;
            if (difficultyLevel != 1)
            {
                difficultyLevel += 1;
            }
            while (!gameIsOver)
            {
                int numberOne = RandomNumberGenerator() * difficultyLevel;
                int numberTwo = RandomNumberGeneratorTwo() * difficultyLevel;
                System.Console.WriteLine($"Multiplication of: {numberOne} * {numberTwo}");
                int inputResult;
                if (int.TryParse(Console.ReadLine(), out inputResult))
                {
                    _timer.Stop();
                    if (inputResult == numberOne * numberTwo)
                    {
                        totalPoints = totalPoints + 1;
                        continue;
                    }
                    else
                    {
                        System.Console.WriteLine($"You Lost! Total Points: {totalPoints}");
                        System.Console.WriteLine($"Time taken: {totalTime:0.00} seconds");
                        gameIsOver = true;
                    }
                }
                else
                {
                    System.Console.WriteLine($"Not an integer, You lost! Total Points: {totalPoints}");
                }
            }
        }
        public void DivisionGame(int difficultyLevel)
        {
            bool gameIsOver = false;
            int totalPoints = 0;
            totalTime = 0;
            if (difficultyLevel != 1)
            {
                difficultyLevel += 1;
            }
            while (!gameIsOver)
            {
                int numberOne;
                int numberTwo;
                do
                {
                    numberOne = RandomNumberGenerator() * difficultyLevel;
                    numberTwo = RandomNumberGeneratorTwo() * difficultyLevel;
                } while (numberTwo == 0 || numberOne % numberTwo != 0); // Ensure integer division
                _timer.Start();
                System.Console.WriteLine($"Division of: {numberOne} / {numberTwo}");
                int inputResult;
                if (int.TryParse(Console.ReadLine(), out inputResult))
                {
                    _timer.Stop();
                    if (inputResult == numberOne - numberTwo)
                    {
                        totalPoints = totalPoints + 1;
                        continue;
                    }
                    else
                    {
                        _timer.Stop();
                        System.Console.WriteLine($"You Lost! Total Points: {totalPoints}");
                        System.Console.WriteLine($"Time taken: {totalTime:0.00} seconds");
                        gameIsOver = true;
                    }
                }
                else
                {
                    System.Console.WriteLine($"Not an integer, You lost! Total Points: {totalPoints}");
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            MathGame mathGame = new MathGame();
            string menuSelection = "";
            do
            {
                System.Console.WriteLine("Welcome to the Math Game.");
                System.Console.WriteLine("Please select an game mode:");
                System.Console.WriteLine("1.Addition Game");
                System.Console.WriteLine("2.Subtraction Game");
                System.Console.WriteLine("3.Multiplication Game");
                System.Console.WriteLine("4.Division Game");
                System.Console.WriteLine("5.Exit");
                int selectedOption;
                bool validInput = int.TryParse(Console.ReadLine(), out selectedOption);
                if (validInput && selectedOption > 0 && selectedOption < 6)
                {
                    menuSelection = selectedOption.ToString();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    // Restart the loop to prompt the user again
                    continue;
                }
                System.Console.WriteLine("Please Select the difficulty level of your game:");
                System.Console.WriteLine("1.Easy");
                System.Console.WriteLine("2.Hard");
                System.Console.WriteLine("3.God Mode");
                selectedOption = 0;
                int levelSelection = 0;
                bool validInputTwo = int.TryParse(Console.ReadLine(), out selectedOption);
                if (validInputTwo && selectedOption > 0 && selectedOption < 4)
                {
                    levelSelection = selectedOption;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    // Restart the loop to prompt the user again
                    continue;
                }
                switch (menuSelection)
                {
                    case "1":
                        mathGame.AdditionGame(levelSelection);
                        break;
                    case "2":
                        mathGame.SubtractionGame(levelSelection);
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        System.Console.WriteLine("Please insert an option between 1 and 5.");
                        break;
                }
            } while (menuSelection != "5");
        }
    }
}