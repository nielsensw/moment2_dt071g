using System;
using System.Globalization;

namespace moment2sn
{

    // Class for A New Day
    public class NewDay
    {
        // Variables
        public int c;
        public int y;
        public int m;
        public int d;

        // Method to calculate date into wekkday name
        public void calcDay()
        {
            // Code done with instructions provided by Mikael Hasselmalm MIUN
            int wd = (d + ((13 * (m + 1)) / 5) + y + (y / 4) + (c / 4) + 5 * c) % 7;

            // Switch method, to write out weekday name depending on true case
            switch (wd)
            {
                case 0:
                    Console.WriteLine("Lördag");
                    break;
                case 1:
                    Console.WriteLine("Söndag");
                    break;
                case 2:
                    Console.WriteLine("Måndag");
                    break;
                case 3:
                    Console.WriteLine("Tisdag");
                    break;
                case 4:
                    Console.WriteLine("Onsdag");
                    break;
                case 5:
                    Console.WriteLine("Torsdag");
                    break;
                case 6:
                    Console.WriteLine("Fredag");
                    break;
            }

        }
    }

    class Program
    {


        static void Main()
        {
        // Start here
        Start:
         
            // new instance of the class - object
            NewDay newDay = new NewDay();
            try
            {

                Console.WriteLine("Calculate the weekday of a date \n");
                // Lets user input day, month and year - takes inputs and applies to method properties
                Console.Write("Write day: ");
                newDay.d = Convert.ToInt32(Console.ReadLine());
                Console.Write("Write month: ");
                newDay.m = Convert.ToInt32(Console.ReadLine());
                Console.Write("Write year: ");
                int fullYear = Convert.ToInt32(Console.ReadLine());
                newDay.c = fullYear / 100;
                newDay.y = fullYear % 100;


                var cultureInfo = new CultureInfo("de-DE");
                DateTimeStyles styles;
                styles = DateTimeStyles.None;
                DateTime result;
                string dateStr = "" + newDay.d + "/" + newDay.m + "/" + fullYear + "";
                // Checking if the collected input gives a valid date
                if (DateTime.TryParse(dateStr, cultureInfo, styles, out result))
                {

                    // Calls the method from the class to calculate
                    newDay.calcDay();

                }
                else
                {
                    // Clear console
                    Console.Clear();

                    Console.WriteLine("You didnt provide a valid date \n");
                    // Start over
                    goto Start;
                }


            }
            // Catches format error (If its not integer) and writes out error message
            catch (FormatException e)
            {
                // Catch - to avoid crash and write out error
                Console.WriteLine(e.Message);

            }

            // Catches all other error and writes error message
            catch (Exception e)
            {
                // Catch - to avoid crash and write out error
                Console.WriteLine(e.Message);

            }
        }
    }
}


