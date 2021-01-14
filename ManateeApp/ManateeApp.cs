/* ManateeApp.cs
 * This is the client program that uses the
 *  ManateeSighting class. Users are prompted
 *  for location, date, and sightings. The
 *  ManateeSighting class is tested using
 *  this class by calling many of the
 *  methods and properties.
 */
using System;
using static System.Console;
namespace ManateeApp
{
    public class ManateeApp
    {
        static void Main(string[] args)
        {
            string location;
            int sightingcnt;
            string[] dArray = new string[20];
            int[] manateeCnt = new int[20];
            char enterMoreData = 'Y';
            ManateeSighting m;

            do
            {
                sightingcnt = GetData(out location, dArray, manateeCnt);
                m = new ManateeSighting(location, dArray, manateeCnt, sightingcnt);
                Clear();
                WriteLine(m);
                Write("\n\n\n\nDo you want to enter more " +
                        "data - (Enter y or n)? ");
                if (char.TryParse(ReadLine(), out enterMoreData) == false)
                    WriteLine("Invalid data entered - No " +
                                "recorded for your response ");
            }
            while (enterMoreData == 'Y' || enterMoreData == 'y');
        }

        public static int GetData(out string location, string[] dArray, int[] manateeCnt)
        {
            int i, loopCnt;
            Clear();
            Write("Location: ");
            location = ReadLine();
            Write("How many records for {0}? ", location);
            string inValue = ReadLine();
            if (int.TryParse(inValue, out loopCnt) == false)
                WriteLine("Invalid data entered - " +
                        "0 recorded for number of records");
            for (i = 0; i < loopCnt; i++)
            {
                Write("\nDate (mm/dd/yyyy): ");
                dArray[i] = ReadLine();
                if (dArray[i] == "")
                {
                    WriteLine("No date entered - " +
                                "Unknown recorded " +
                                "for sightings");
                    dArray[i] = "Unknown";
                }
                Write("Number of Sightings: ");
                inValue = ReadLine();
                if (int.TryParse(inValue, out manateeCnt[i]) == false)
                    WriteLine("Invalid data entered - 0 " +
                                "recorded for manatee sightings ");
            }

            return i;
        }
    }

}
