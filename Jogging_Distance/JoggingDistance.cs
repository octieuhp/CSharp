/* JoggingDistance.cs
 * This application calculates the jogging distance.
 * User are asked to enter the number of
 * strides ran during the firt and last minute
 * and total jogging time. A 2.5 stride is used
 * for calculation
 */

using System;
using static System.Console;

namespace Jogging_Distance
{
    class JoggingDistance
    {
        static void Main(string[] args)
        {
            int initialStrideCount, finalStrideCount, hrs, mins, totalMinutes;
            double numberOfStepsPerMin, distanceTraveled;
            DisplayInstructions();
            initialStrideCount = GetNumberStrides("first");
            finalStrideCount = GetNumberStrides("last");
            InputJoggingTime(out hrs, out mins);
            totalMinutes = CalculateTime(hrs, mins);
            numberOfStepsPerMin = CalculateAvgSteps(initialStrideCount, finalStrideCount);
            distanceTraveled = CalculateDistance(numberOfStepsPerMin, totalMinutes);
            DisplayResults(numberOfStepsPerMin, hrs, mins, distanceTraveled);
            ReadKey();
        }

        static void DisplayInstructions()
        {
            WriteLine("How many miles did you jog?");
            WriteLine("Distance (in miles) will be calculated");
            WriteLine("base on stride and numer of steps");
            WriteLine("taken per minute. \n");
            WriteLine("You will asked to enter ");
            WriteLine("your initial and ending strides...");
            WriteLine("OR how many step you took the ");
            WriteLine("first minute and how many ");
            WriteLine("step during last minute.");
            WriteLine("Average stride is calculated ");
            WriteLine("from those entries.\n");
            WriteLine("Calculations are based on a ");
            WriteLine("2.5 feet stride-each step is 2.5 feet long.");
            WriteLine();
            WriteLine("\n You will also bee asked ");
            WriteLine("to enter the length ");
            WriteLine("of time (hours and minutes)");
            WriteLine("you jogged.");
            WriteLine();
            WriteLine("Press any key when you are ready to begin!"); ;
            ReadKey();
            Clear();         
        }

        static int GetNumberStrides(string when)
        {
            string inputValue;
            int numberOfSteps;
            Write("Enter number of steps taken " +
                "during {0} minute: ", when);
            inputValue = ReadLine();
            numberOfSteps = int.Parse(inputValue);
            return numberOfSteps;
        }

        static int CalculateTime(int hrs, int mins)
        {
            return hrs * 60 + mins;
        }
        static double CalculateAvgSteps(int initialStrideCount, int finalStrideCount)
        {
            return (initialStrideCount + finalStrideCount) / 2.0;
        }
        static void InputJoggingTime(out int hrs, out int mins)
        {
            string inputValue;
            WriteLine("\nHow much time did you spend jogging?");
            Write("Hours: ");
            inputValue = ReadLine();
            hrs = int.Parse(inputValue);
            Write("Minutes: ");
            inputValue = ReadLine();
            mins = int.Parse(inputValue);
        }

        static double CalculateDistance(double numberOfStepsPerMin, int totalMinutes)
        {
            const double STRIDE = 2.5;
            const int FEET_PER_MILE = 5280;
            return numberOfStepsPerMin * STRIDE * totalMinutes / FEET_PER_MILE;
        }

        static void DisplayResults(double numberOfStepPerMin, int hrs, int mins, double distanceTraveled)
        {
            Clear();
            WriteLine("{0,35}", "Jogging Distance Calculator");
            WriteLine();
            WriteLine("{0, -50} {1} Feet Per Step", "Stride:", 2.5);
            WriteLine("{0, -25} {1} Steps", "Strides Per " + "Minute: ", numberOfStepPerMin);
            WriteLine("{0, -25} {1} Hour(s) and {2} Minute(s)", "Jogging Time:", hrs, mins);
            WriteLine("{0,-25} {1:f2} Miles", "Distance Traveled:", distanceTraveled);
        }
    }
}
